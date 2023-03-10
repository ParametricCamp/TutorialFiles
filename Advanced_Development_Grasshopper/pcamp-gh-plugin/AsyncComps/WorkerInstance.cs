using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrasshopperAsyncComponent
{

    // https://github.com/specklesystems/GrasshopperAsyncComponent/blob/main/LICENSE

    /// <summary>
    /// A class that holds the actual compute logic and encapsulates the state it needs. Every <see cref="GH_AsyncComponent"/> needs to have one.
    /// </summary>
    public abstract class WorkerInstance
  {

    /// <summary>
    /// The parent component. Useful for passing state back to the host component.
    /// </summary>
    public GH_Component Parent { get; set; }
    
    /// <summary>
    /// This token is set by the parent <see cref="GH_AsyncComponent"/>. 
    /// </summary>
    public CancellationToken CancellationToken { get; set; }

    /// <summary>
    /// This is set by the parent <see cref="GH_AsyncComponent"/>. You can set it yourself, but it's not really worth it.
    /// </summary>
    public string Id { get; set; }

    protected WorkerInstance(GH_Component _parent)
    {
      Parent = _parent;
    }

    /// <summary>
    /// This is a "factory" method. It should return a fresh instance of this class, but with all the necessary state that you might have passed on directly from your component.
    /// </summary>
    /// <returns></returns>
    public abstract WorkerInstance Duplicate();

    /// <summary>
    /// This method is where the actual calculation/computation/heavy lifting should be done. 
    /// <b>Make sure you always check as frequently as you can if <see cref="WorkerInstance.CancellationToken"/> is cancelled. For an example, see the <see cref="PrimeCalculatorWorker"/>.</b>
    /// </summary>
    /// <param name="ReportProgress">Call this to report progress up to the parent component.</param>
    /// <param name="Done">Call this when everything is <b>done</b>. It will tell the parent component that you're ready to <see cref="SetData(IGH_DataAccess)"/>.</param>
    public abstract void DoWork(Action<string, double> ReportProgress, Action Done);

    /// <summary>
    /// Write your data setting logic here. <b>Do not call this function directly from this class. It will be invoked by the parent <see cref="GH_AsyncComponent"/> after you've called `Done` in the <see cref="DoWork(Action{string}, Action{string, GH_RuntimeMessageLevel}, Action)"/> function.</b>
    /// </summary>
    /// <param name="DA"></param>
    public abstract void SetData(IGH_DataAccess DA);

    /// <summary>
    /// Write your data collection logic here. <b>Do not call this method directly. It will be invoked by the parent <see cref="GH_AsyncComponent"/>.</b>
    /// </summary>
    /// <param name="DA"></param>
    /// <param name="Params"></param>
    public abstract void GetData(IGH_DataAccess DA, GH_ComponentParamServer Params);
  }

}
