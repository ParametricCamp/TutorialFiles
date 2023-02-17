using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.UtilityComps
{
    public class MassAdditionComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MassAdditionComponent class.
        /// </summary>
        public MassAdditionComponent()
          : base("Mass Addition", "MassAdd",
              "Adds a list of numbers",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Numbers", "I", "Numbers to add", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("R", "Result", "Result", GH_ParamAccess.item);
            pManager.AddNumberParameter("Pr", "Partial", "Partial Results", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<double> vals = new List<double>();

            if (!DA.GetDataList(0, vals)) return;

            // Algorithm
            double p = 0;
            List<double> partials = new List<double>();
            foreach (double v in vals)
            {
                p += v;
                partials.Add(p);
            }

            // Ouptuts
            DA.SetData(0, p);
            DA.SetDataList(1, partials);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Properties.Resources.pc_inv;

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("6573DA1C-A8F9-409A-B92E-88DF5AE177E2"); }
        }
    }
}