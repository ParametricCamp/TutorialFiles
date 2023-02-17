using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class ConstructVectorComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ConstructVectorComponent class.
        /// </summary>
        public ConstructVectorComponent()
          : base("Construct Vector", "New Vector",
              "Create a vector from components",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("X", "X", "X component", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Y", "Y", "Y component", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Z", "Z", "Z component", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddVectorParameter("Vector", "V", "Vector", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double x = 0,
                y = 0,
                z = 0;

            DA.GetData(0, ref x);
            DA.GetData(1, ref y);
            DA.GetData(2, ref z);

            Vector3d v = new Vector3d(x, y, z);

            DA.SetData(0, v);
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
            get { return new Guid("5CF5D15D-F2EA-4002-917B-1C28604572CF"); }
        }
    }
}