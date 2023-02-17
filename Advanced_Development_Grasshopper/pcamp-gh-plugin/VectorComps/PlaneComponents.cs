using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class PlaneComponents : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DeconstructPointComponent class.
        /// </summary>
        public PlaneComponents()
          : base("Plane", "Plane",
              "",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("O", "O", "", GH_ParamAccess.item);
            pManager.AddVectorParameter("X", "X", "", GH_ParamAccess.item);
            pManager.AddVectorParameter("Y", "Y", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddVectorParameter("P", "P", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d o = Point3d.Unset;
            Vector3d x = Vector3d.Unset;
            Vector3d y = Vector3d.Unset;

            DA.GetData(0, ref o);
            DA.GetData(1, ref x);
            DA.GetData(1, ref y);

            Plane pl = new Plane(o, x, y);

            DA.SetData(0, pl);
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
            get { return new Guid("17E9460A-7536-4F3E-877C-611670973694"); }
        }
    }
}