using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.UtilityComps
{
    public class DivisionComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the AddNumbersComponent class.
        /// </summary>
        public DivisionComponent()
          : base("Division", "Division",
              "",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("NumberA", "A", "", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("NumberB", "B", "", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Result", "R", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double a = 0;
            double b = 0;

            if (!DA.GetData(0, ref a)) return;
            if (!DA.GetData(1, ref b)) return;

            double sub = a / b;

            DA.SetData(0, sub);
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Properties.Resources.pc_inv;

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("00B5F20C-BA9D-4BC6-A205-9C1688182930"); }
        }
    }
}