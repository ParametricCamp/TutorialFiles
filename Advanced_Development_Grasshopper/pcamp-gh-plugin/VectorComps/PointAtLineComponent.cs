using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class PointAtLineComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DeconstructPointComponent class.
        /// </summary>
        public PointAtLineComponent()
          : base("PointAtLine", "PointAtLine",
              "",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("L", "L", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("t", "t", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("P", "P", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Line line = Line.Unset;
            double t = 0;

            DA.GetData(0, ref line);
            DA.GetData(1, ref t);

            Point3d p = line.PointAt(t);

            DA.SetData(0, p);
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
            get { return new Guid("E8A86139-B1C1-43AC-A358-2D36BDF679FE"); }
        }
    }
}