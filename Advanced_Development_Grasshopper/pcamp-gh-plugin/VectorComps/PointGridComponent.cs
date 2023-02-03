using System;
using System.Collections.Generic;

using Rhino.Geometry;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

namespace PCampGHPlugin.VectorComps
{
    public class PointGridComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PointGridComponent class.
        /// </summary>
        public PointGridComponent()
          : base("Point Grid", "PtGrid",
              "Creates a grid of points",
              "PCamp", "Vector")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Start", "S", "Starting point", GH_ParamAccess.item);
            pManager.AddIntegerParameter("CountX", "NX", "Elements in X", GH_ParamAccess.item);
            pManager.AddIntegerParameter("CountY", "NY", "Elements in Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("StepX", "DX", "Distande in X", GH_ParamAccess.item);
            pManager.AddNumberParameter("StepY", "DY", "Distande in Y", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Grid of points", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d S = Point3d.Unset;
            int NX = 0;
            int NY = 0;
            double DX = 0;
            double DY = 0;

            if (!DA.GetData(0, ref S)) return;
            if (!DA.GetData(1, ref NX)) return;
            if (!DA.GetData(2, ref NY)) return;
            if (!DA.GetData(3, ref DX)) return;
            if (!DA.GetData(4, ref DY)) return;


            // Algorithm
            GH_Structure<GH_Point> pts = new GH_Structure<GH_Point>();

            for (int j = 0; j < NY; j++)
            {
                double y = S.Y + DY * j;
                GH_Path path = new GH_Path(j);

                for (int i = 0; i < NX; i++)
                {
                    double x = S.X + DX * i;
                    Point3d p = new Point3d(x, y, S.Z);

                    pts.Append(new GH_Point(p), path);
                }
            }

            // Outputs
            DA.SetDataTree(0, pts);
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
            get { return new Guid("8BDA7E2A-908D-4EEA-A71C-76B844B087B7"); }
        }
    }
}