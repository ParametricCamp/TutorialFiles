using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.PreviewComps
{
    public class VectorPreviewComponent : GH_Component
    {
        // Global scope
        Line arrow;


        /// <summary>
        /// Initializes a new instance of the VectorPreviewComponent class.
        /// </summary>
        public VectorPreviewComponent()
          : base("Vector Preview", "VecPrev",
              "Renders a preview of this vector on the viewport",
              "PCamp", "Preview")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Anchor", "A", "Base point for the vector preview", GH_ParamAccess.item);
            pManager.AddVectorParameter("Vector", "V", "The actual vector", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            // Nothing to output here!
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Define placeholder varibles
            Point3d anchor = Point3d.Unset;
            Vector3d vector = Vector3d.Unset;

            // Load values from inputs into those variables
            if (!DA.GetData(0, ref anchor)) return;
            if (!DA.GetData(1, ref vector)) return;

            // Solver
            arrow = new Line(anchor, vector);
        }


        public override BoundingBox ClippingBox => BoundingBox.Union(base.ClippingBox, arrow.BoundingBox);

        //public override BoundingBox ClippingBox
        //{
        //    get
        //    {
        //        return BoundingBox.Union(base.ClippingBox, arrow.BoundingBox);
        //    }
        //}

        public override void DrawViewportWires(IGH_PreviewArgs args)
        {
            base.DrawViewportWires(args);

            args.Display.DrawArrow(arrow, System.Drawing.Color.Coral);

            double len = arrow.Length;
            Point2d location = new Point2d(25, Rhino.RhinoDoc.ActiveDoc.Views.ActiveView.Bounds.Height - 25);
            args.Display.Draw2dText(
              "Vector length: " + len.ToString(),
              System.Drawing.Color.Black,
              location,
              false);

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("33C1F55E-92AA-4756-A481-57A2510AB1FE"); }
        }
    }
}