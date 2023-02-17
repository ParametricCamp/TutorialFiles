using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class DeconstructPointComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DeconstructPointComponent class.
        /// </summary>
        public DeconstructPointComponent()
          : base("DeconstructPoint", "DeconstructPoint",
              "",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("P", "P", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("X", "X", "X component", GH_ParamAccess.item);
            pManager.AddNumberParameter("Y", "Y", "Y component", GH_ParamAccess.item);
            pManager.AddNumberParameter("Z", "Z", "Z component", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d p = Point3d.Unset;

            DA.GetData(0, ref p);

            DA.SetData(0, p.X);
            DA.SetData(1, p.Y);
            DA.SetData(2, p.Z);
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
            get { return new Guid("FDA5FC8B-A792-4244-9F0C-7E265783F74F"); }
        }
    }
}