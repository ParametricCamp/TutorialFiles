using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.UtilityComps
{
    public class RangeComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the RangeComponent class.
        /// </summary>
        public RangeComponent()
          : base("Range", "Range",
              "Creates a numerical range",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntervalParameter("Domain", "D", "Numerical domain for the range", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Steps", "S", "Number of steps to divide the range in", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Range", "R", "Numerical range", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Empty collection variables
            Interval dom = new Interval();
            int steps = 0;

            // Fetch inputs
            if (!DA.GetData(0, ref dom)) return;
            if (!DA.GetData(1, ref steps)) return;

            // Algorithm
            double step = (dom.T1 - dom.T0) / steps;

            List<double> vals = new List<double>();

            for (int i = 0; i < steps + 1; i++)
            {
                double v = dom.T0 + i * step;
                vals.Add(v);
            }

            // Outputs
            DA.SetDataList(0, vals);
        }

        public override GH_Exposure Exposure => GH_Exposure.tertiary;


        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Properties.Resources.pc_inv;

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("E9E77AC9-4CE1-4574-97DE-C10F3AB71940"); }
        }
    }
}