using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class VectorAdditionComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the VectorLengthComponent class.
        /// </summary>
        public VectorAdditionComponent()
          : base("VectorAddition", "VectorAddition",
              "",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("A", "A", "", GH_ParamAccess.item);
            pManager.AddVectorParameter("B", "B", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddVectorParameter("V", "V", "", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Vector3d a = Vector3d.Unset;
            Vector3d b = Vector3d.Unset;

            DA.GetData(0, ref a);
            DA.GetData(1, ref b);

            Vector3d sum = a + b;

            DA.SetData(0, sum);
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
            get { return new Guid("6E8CFA9C-F93B-4654-8AF9-E71BAF2A7CCE"); }
        }
    }
}