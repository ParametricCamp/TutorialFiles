using Grasshopper.Kernel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace GrasshopperAsyncComponent
{
    // https://github.com/specklesystems/GrasshopperAsyncComponent/blob/main/LICENSE

    /// <summary>
    /// Inherit your component from this class to make all the async goodness available.
    /// </summary>
    public abstract class GH_AsyncComponent : GH_Component
  {
    public override Guid ComponentGuid => throw new Exception("ComponentGuid should be overriden in any descendant of GH_AsyncComponent!");

    //List<(string, GH_RuntimeMessageLevel)> Errors;

    Action<string, double> ReportProgress;

    public ConcurrentDictionary<string, double> ProgressReports;

    Action Done;

    Timer DisplayProgressTimer;

    int State = 0;

    int SetData = 0;

    public List<WorkerInstance> Workers;

    List<Task> Tasks;

    public readonly List<CancellationTokenSource> CancellationSources;

    /// <summary>
    /// Set this property inside the constructor of your derived component. 
    /// </summary>
    public WorkerInstance BaseWorker { get; set; }

    /// <summary>
    /// Optional: if you have opinions on how the default system task scheduler should treat your workers, set it here.
    /// </summary>
    public TaskCreationOptions? TaskCreationOptions { get; set; } = null;

    protected GH_AsyncComponent(string name, string nickname, string description, string category, string subCategory) : base(name, nickname, description, category, subCategory)
    {

      DisplayProgressTimer = new Timer(333) { AutoReset = false };
      DisplayProgressTimer.Elapsed += DisplayProgress;

      ReportProgress = (id, value) =>
      {
        ProgressReports[id] = value;
        if (!DisplayProgressTimer.Enabled)
        {
          DisplayProgressTimer.Start();
        }
      };

      Done = () =>
      {
        Interlocked.Increment(ref State);
        if (State == Workers.Count && SetData == 0)
        {
          Interlocked.Exchange(ref SetData, 1);

          // We need to reverse the workers list to set the outputs in the same order as the inputs. 
          Workers.Reverse();

          Rhino.RhinoApp.InvokeOnUiThread((Action)delegate
          {
            ExpireSolution(true);
          });
        }
      };

      ProgressReports = new ConcurrentDictionary<string, double>();

      Workers = new List<WorkerInstance>();
      CancellationSources = new List<CancellationTokenSource>();
      Tasks = new List<Task>();
    }

    public virtual void DisplayProgress(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (Workers.Count == 0 || ProgressReports.Values.Count == 0)
      {
        return;
      }

      if (Workers.Count == 1)
      {
        Message = ProgressReports.Values.Last().ToString("0.00%");
      }
      else
      {
        double total = 0;
        foreach (var kvp in ProgressReports)
        {
          total += kvp.Value;
        }

        Message = (total / Workers.Count).ToString("0.00%");
      }

      Rhino.RhinoApp.InvokeOnUiThread((Action)delegate
      {
        OnDisplayExpired(true);
      });
    }

    protected override void BeforeSolveInstance()
    {
      if (State != 0 && SetData == 1)
      {
        return;
      }

      Debug.WriteLine("Killing");

      foreach (var source in CancellationSources)
      {
        source.Cancel();
      }

      CancellationSources.Clear();
      Workers.Clear();
      ProgressReports.Clear();
      Tasks.Clear();

      Interlocked.Exchange(ref State, 0);
    }

    protected override void AfterSolveInstance()
    {
      System.Diagnostics.Debug.WriteLine("After solve instance was called " + State + " ? " + Workers.Count);
      // We need to start all the tasks as close as possible to each other.
      if (State == 0 && Tasks.Count > 0 && SetData == 0)
      {
        System.Diagnostics.Debug.WriteLine("After solve INVOKATIONM");
        foreach (var task in Tasks)
        {
          task.Start();
        }
      }
    }

    protected override void ExpireDownStreamObjects()
    {
      // Prevents the flash of null data until the new solution is ready
      if (SetData == 1)
      {
        base.ExpireDownStreamObjects();
      }
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
      //return;
      if (State == 0)
      {
        if (BaseWorker == null)
        {
          AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Worker class not provided.");
          return;
        }

        var currentWorker = BaseWorker.Duplicate();
        if (currentWorker == null)
        {
          AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Could not get a worker instance.");
          return;
        }

        // Let the worker collect data.
        currentWorker.GetData(DA, Params);

        // Create the task
        var tokenSource = new CancellationTokenSource();
        currentWorker.CancellationToken = tokenSource.Token;
        currentWorker.Id = $"Worker-{DA.Iteration}";

        var currentRun = TaskCreationOptions != null
          ? new Task(() => currentWorker.DoWork(ReportProgress, Done), tokenSource.Token, (TaskCreationOptions)TaskCreationOptions)
          : new Task(() => currentWorker.DoWork(ReportProgress, Done), tokenSource.Token);

        // Add cancellation source to our bag
        CancellationSources.Add(tokenSource);

        // Add the worker to our list
        Workers.Add(currentWorker);

        Tasks.Add(currentRun);

        return;
      }

      if (SetData == 0)
      {
        return;
      }

      if (Workers.Count > 0)
      {
        Interlocked.Decrement(ref State);
        Workers[State].SetData(DA);
      }

      if (State != 0)
      {
        return;
      }

      CancellationSources.Clear();
      Workers.Clear();
      ProgressReports.Clear();
      Tasks.Clear();

      Interlocked.Exchange(ref SetData, 0);

      Message = "Done";
      OnDisplayExpired(true);
    }

    public void RequestCancellation()
    {
      foreach (var source in CancellationSources)
      {
        source.Cancel();
      }

      CancellationSources.Clear();
      Workers.Clear();
      ProgressReports.Clear();
      Tasks.Clear();

      Interlocked.Exchange(ref State, 0);
      Interlocked.Exchange(ref SetData, 0);
      Message = "Cancelled";
      OnDisplayExpired(true);
    }

  }
}
