using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.NURBSComps
{
    public class DivideCurveComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DivideCurveComponent class.
        /// </summary>
        public DivideCurveComponent()
          : base("Divide Curve", "DivCurve",
              "Divide curve in points",
              "PCamp", "NURBS")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Curve to subdivide", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Steps", "N", "Steps to subdivide the curve in", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Subdivision points", GH_ParamAccess.list);
            pManager.AddNumberParameter("Parameters", "t", "Curve parameter at the subdivision", GH_ParamAccess.list);
            pManager.AddVectorParameter("Tangents", "T", "Curve tangents at the points", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Curve C = null;
            int N = 0;

            if (!DA.GetData(0, ref C)) return;
            if (!DA.GetData(1, ref N)) return;


            // Find parameters & points for divisions
            Point3d[] points;
            double[] parameters = C.DivideByCount(N, true, out points);

            // Find vectors for these parameters
            Vector3d[] tangents = new Vector3d[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                double p = parameters[i];

                Vector3d v = C.TangentAt(p);
                tangents[i] = v;
            }


            // Outputs
            DA.SetDataList(0, points);
            DA.SetDataList(1, parameters);
            DA.SetDataList(2, tangents);

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
            get { return new Guid("6E59C9D1-56B7-481F-8E51-E9EDFFABA345"); }
        }
    }
}