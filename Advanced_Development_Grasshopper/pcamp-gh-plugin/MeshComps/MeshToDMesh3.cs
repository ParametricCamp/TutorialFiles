using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using g3;

namespace PCampGHPlugin.MeshComps
{
    public class MeshToDMesh3 : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public MeshToDMesh3()
          : base("Mesh To DMesh3", "M2DM3",
              "Converts a GH Mesh to a G3 DMesh3",
              "PCamp", "Mesh")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("mesh", "M", "GH Mesh", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("dmesh3", "DM3", "The converted DMesh3 object", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Mesh mesh = null;

            if (!DA.GetData(0, ref mesh)) return;

            DMesh3 dm3 = ConvertMesh(mesh);

            DA.SetData(0, dm3);
        }

        protected DMesh3 ConvertMesh(Mesh mesh)
        {
            // Create empty DMesh3
            DMesh3 dm = new DMesh3(true, true, true, true);

            // Copy all vertices
            for (int i = 0; i < mesh.Vertices.Count; i++)
            {
                Point3f v = mesh.Vertices[i];
                dm.AppendVertex(v.X, v.Y, v.Z);
            }

            // Copy all the faces
            for (int i = 0; i < mesh.Faces.Count; i++)
            {
                MeshFace mf = mesh.Faces.GetFace(i);
                if (mf.IsTriangle)
                {
                    dm.AppendTriangle(mf.A, mf.B, mf.C);
                }
            }

            return dm;
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
            get { return new Guid("068C6B4F-E2A8-4247-8D3B-F5AEF672F9A7"); }
        }
    }
}