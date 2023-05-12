using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using Rhino;
using Rhino.Geometry;

namespace PCampGHPlugin.AsyncComps
{
    public class AsyncForLoopComponent : GH_Component
    {
        private bool _shouldExpire = false;
        private string _message = "";

        /// <summary>
        /// Initializes a new instance of the AsyncForLoopComponent class.
        /// </summary>
        public AsyncForLoopComponent()
          : base("AsyncForLoop", "AsyncForLoop",
              "AsyncForLoop",
              "PCamp", "Async")
        {
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
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (_shouldExpire)
            {
                // This is the second time SI was invoked
                DA.SetData(0, _message);
                _shouldExpire = false;
                this.Message = "Done!";
                return;
            }

            int iterations = 0;
            if (!DA.GetData(0, ref iterations)) return;

            this.Message = "Computing...";
            AsyncForLoop(iterations);
        }

        private void AsyncForLoop(int it)
        {
            Task.Run(() =>
            {
                int iterations = 0;
                for (int i = 0; i < it; i++)
                {
                    double expensive = Math.Sqrt(Math.Sqrt(Math.Sqrt(Math.Sqrt(i))));
                    iterations = i;
                }

                _message = "Completed " + iterations + " iterations";

                _shouldExpire = true;

                RhinoApp.InvokeOnUiThread((Action)delegate { ExpireSolution(true); });
            });
        }


        protected override void ExpireDownStreamObjects()
        {
            if (_shouldExpire)
            {
                base.ExpireDownStreamObjects();
            }
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
            get { return new Guid("52860A70-8997-4785-BA87-9C15A5AC837B"); }
        }
    }
}