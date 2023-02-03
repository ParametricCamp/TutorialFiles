using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.Development
{
    public class CounterAutoUpdate : GH_Component
    {
        // Persistent fields
        int updates = 0;


        /// <summary>
        /// Initializes a new instance of the Counter class.
        /// </summary>
        public CounterAutoUpdate()
          : base("CounterAutoUpdate", "CounterAutoUpdate",
              "Count number of iterations with auto update",
              "PCamp", "Development")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Ticker", "T", "Generic input to tick the component", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Reset", "R", "Reset counter?", GH_ParamAccess.item);
            pManager.AddBooleanParameter("AutoUpdate", "AU", "Autoupdate?", GH_ParamAccess.item);
            pManager.AddIntegerParameter("UpdateInterval", "I", "AutoUpdate interval in milliseconds", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("Updates", "U", "Number of times this component has updated)", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Define placeholder varibles
            object obj = null;
            bool reset = false;
            bool autoupdate = false;
            int millis = 1000;

            // Load values from inputs into those variables
            if (!DA.GetData(0, ref obj)) return;
            if (!DA.GetData(1, ref reset)) return;
            if (!DA.GetData(2, ref autoupdate)) return;
            if (!DA.GetData(3, ref millis)) return;

            // Solver
            if (reset)
            {
                updates = 0;
            }
            updates++;

            // Outputs
            DA.SetData(0, updates);

            // Schedule a new update if necessary
            if (autoupdate)
            {
                this.OnPingDocument().ScheduleSolution(millis, doc =>
                {
                    this.ExpireSolution(false);
                });

                //this.OnPingDocument().ScheduleSolution(millis, ScheduleCallback);
            }
        }

        //private void ScheduleCallback(GH_Document doc)
        //{
        //    this.ExpireSolution(false);
        //}



        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("960fac90-5abb-4dbc-ab71-2422f3852d2a"); }
        }
    }
}