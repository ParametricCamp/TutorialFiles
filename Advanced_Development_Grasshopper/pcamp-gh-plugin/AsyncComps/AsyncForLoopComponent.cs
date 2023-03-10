using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using GrasshopperAsyncComponent;
using System.Windows.Forms;

namespace PCampGHPlugin.AsyncComps
{
    public class AsyncForLoopComponent : GH_AsyncComponent
    {
        /// <summary>
        /// Initializes a new instance of the AsyncForLoop class.
        /// </summary>
        public AsyncForLoopComponent()
          : base("AsyncForLoop", "AsyncForLoop",
              "AsyncForLoop",
              "PCamp", "Async")
        {
            BaseWorker = new ForLoopWorker();
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("I", "Iterations", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("M", "Message", "", GH_ParamAccess.item);
        }

  

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.pc_inv;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("7CC720C3-8645-4B6E-BD35-360450E7EF0A"); }
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "Cancel", (s, e) =>
            {
                RequestCancellation();
            });
        }


        private class ForLoopWorker : WorkerInstance
        {
            int numberOfIterations = -1;
            double finalResult = -1;

            public ForLoopWorker() : base(null) { }

            public override void GetData(IGH_DataAccess DA, GH_ComponentParamServer Params)
            {
                int _it = -1;
                DA.GetData(0, ref _it);

                numberOfIterations = _it;
            }

            public override void DoWork(Action<string, double> ReportProgress, Action Done)
            {
                // 👉 Checking for cancellation!
                if (CancellationToken.IsCancellationRequested) { return; }

                double result = -1;

                for (int i = 0; i <= numberOfIterations; i++)
                {
                    if (CancellationToken.IsCancellationRequested) { return; }

                    result = i;

                    ReportProgress(Id, i / (double)numberOfIterations);
                }

                finalResult = result;

                Done();
            }


            public override void SetData(IGH_DataAccess DA)
            {
                DA.SetData(0, finalResult);
            }

            public override WorkerInstance Duplicate() => new ForLoopWorker();

        }
    }
}