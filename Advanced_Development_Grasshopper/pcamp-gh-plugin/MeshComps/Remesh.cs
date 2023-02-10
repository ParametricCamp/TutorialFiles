using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using PCampGHPlugin.Utils;

using g3;
using System.Diagnostics;

namespace PCampGHPlugin.MeshComps
{
    public class Remesh : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Remesh()
          : base("Remesh", "Remesh",
              "Remeshes a DMesh3 object to a target edge length",
              "PCamp", "Mesh")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("dmesh3", "DM3", "Input DMesh3", GH_ParamAccess.item);
            pManager.AddNumberParameter("targetEdgeLength", "L", "Approximate target length for mesh edges", GH_ParamAccess.item);
            pManager.AddIntegerParameter("passes", "P", "Number of computation passes", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("dmesh3", "DM3", "Remeshed mesh", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DMesh3 dm = null;
            double targetLength = 0;
            int passes = 1;

            if (!DA.GetData(0, ref dm)) return;
            if (!DA.GetData(1, ref targetLength)) return;
            if (!DA.GetData(2, ref passes)) return;

            Stopwatch timer = new Stopwatch();

            timer.Start();
            DMesh3 remeshed = RemeshToTargetEdgeLength(dm, targetLength, passes);
            timer.Stop();

            string msg = "Remeshed the mesh to V:" + remeshed.VertexCount + ", F:" + remeshed.TriangleCount;
            msg += ", computed in " + timer.ElapsedMilliseconds + " ms";

            PConsole.WriteLine(msg);

            DA.SetData(0, remeshed);
        }

        protected DMesh3 RemeshToTargetEdgeLength(DMesh3 dmesh, double targetLength, int passes)
        {
            // Copy (avoid changes to the original obj reference)
            DMesh3 dm = new DMesh3(dmesh, true, true, true, true);

            // Remesh it
            Remesher r = new Remesher(dm);
            r.PreventNormalFlips = true;
            r.SetTargetEdgeLength(targetLength);
            for (int i = 0; i < passes; i++)
            {
                r.BasicRemeshPass();
            }

            // For some reason, the reduced mesh had invalid vertices.
            // This gets solved by re-creating a new mesh as a copy from the invalid one...
            // Need to do more research as to why this is not working...
            return new DMesh3(dm, true, true, true, true);
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
            get { return new Guid("D6E7F155-64C1-4606-95F7-7AAB434AC437"); }
        }
    }
}