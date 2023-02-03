using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.Development
{
    public class Counter : GH_Component
    {
        // Persistent fields
        int updates = 0;

        /// <summary>
        /// Initializes a new instance of the Counter class.
        /// </summary>
        public Counter()
          : base("Counter", "Counter",
              "Count number of iterations",
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

            // Load values from inputs into those variables
            if (!DA.GetData(0, ref obj)) return;
            if (!DA.GetData(1, ref reset)) return;

            // Solver
            if (reset)
            {
                updates = 0;
            }
            updates++;

            // Outputs
            DA.SetData(0, updates);
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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("344D04E3-7DBB-4FF0-9F06-8187BB3E7FC2"); }
        }
    }
}