using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using PCampGHPlugin.Utils;

namespace PCampGHPlugin.UtilityComps
{
    public class PConsoleLogger : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PConsoleLogger class.
        /// </summary>
        public PConsoleLogger()
          : base("PConsoleLogger", "PConsoleLogger",
              "Description",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Update", "U", "", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Clear", "C", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Logs", "L", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool update = false;
            bool clear = false;

            if (!DA.GetData(0, ref update)) return;
            if (!DA.GetData(1, ref clear)) return;

            if (!update) return;

            if (clear) PConsole.Clear();

            List<string> logs = PConsole.Read();

            DA.SetDataList(0, logs);
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
            get { return new Guid("BF27F4F6-17C1-467B-A8C6-DBB0F3CCC4ED"); }
        }
    }
}