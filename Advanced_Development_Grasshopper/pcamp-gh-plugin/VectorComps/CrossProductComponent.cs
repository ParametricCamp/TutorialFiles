using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class CrossProductComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the VectorLengthComponent class.
        /// </summary>
        public CrossProductComponent()
          : base("CrossProduct", "CrossProduct",
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
            pManager.AddBooleanParameter("U", "U", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddVectorParameter("V", "V", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("L", "L", "", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Vector3d a = Vector3d.Unset;
            Vector3d b = Vector3d.Unset;
            bool u = false;

            DA.GetData(0, ref a);
            DA.GetData(1, ref b);
            DA.GetData(2, ref u);

            Vector3d cross = Vector3d.CrossProduct(a, b);

            if (u)
            {
                cross.Unitize();
            }

            DA.SetData(0, cross);
            DA.SetData(1, cross.Length);
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
            get { return new Guid("C9BB261B-79C6-447F-8E49-80873B969853"); }
        }
    }
}