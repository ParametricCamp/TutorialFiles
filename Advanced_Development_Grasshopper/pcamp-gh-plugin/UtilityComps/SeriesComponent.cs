using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.UtilityComps
{
    public class SeriesComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SeriesComponent class.
        /// </summary>
        public SeriesComponent()
          : base("Series", "Series",
              "Creates a numerical series",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Start", "S", "First value in the series", GH_ParamAccess.item);
            pManager.AddNumberParameter("Step", "N", "Step size between numbers in the series", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Count", "C", "Number of element in the series", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Series", "S", "Numerical series", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Predefine empty variables to store inputs
            double start = 0;
            double step = 0;
            int count = 0;

            // Fetch the inputs
            if (!DA.GetData(0, ref start)) return;
            if (!DA.GetData(1, ref step)) return;
            if (!DA.GetData(2, ref count)) return;

            // Algorithm
            List<double> vals = new List<double>();

            for (int i = 0; i < count; i++)
            {
                double v = start + i * step;
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
            get { return new Guid("61DD9445-D39F-4B98-94FE-711713288BD1"); }
        }
    }
}