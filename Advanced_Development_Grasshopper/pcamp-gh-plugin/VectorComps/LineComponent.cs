using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.VectorComps
{
    public class LineComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DeconstructPointComponent class.
        /// </summary>
        public LineComponent()
          : base("Line", "Line",
              "",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("A", "A", "", GH_ParamAccess.item);
            pManager.AddPointParameter("B", "B", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddLineParameter("L", "L", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d p0 = Point3d.Unset;
            Point3d p1 = Point3d.Unset;

            DA.GetData(0, ref p0);
            DA.GetData(1, ref p1);

            Line line = new Line(p0, p1);

            DA.SetData(0, line);
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
            get { return new Guid("963930DD-C871-41A6-B306-DAE3116E6232"); }
        }
    }
}