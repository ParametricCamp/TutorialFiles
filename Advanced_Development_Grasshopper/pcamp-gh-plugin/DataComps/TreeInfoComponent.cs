using System;
using System.Collections.Generic;

using Rhino.Geometry;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

namespace PCampGHPlugin.DataComps
{
    public class TreeInfoComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the TreeInfoComponent class.
        /// </summary>
        public TreeInfoComponent()
          : base("Tree Info", "Tree Info",
              "Get info from the incoming data tree",
              "PCamp", "Data")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Tree", "T", "Input tree", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Topology", "Top", "Tree topology", GH_ParamAccess.item);
            pManager.AddTextParameter("Description", "D", "Description", GH_ParamAccess.list);
            pManager.AddPathParameter("Paths", "P", "Paths", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Branches", "B", "Branch count", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Items", "I", "Item count", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Structure<IGH_Goo> T = new GH_Structure<IGH_Goo>();

            DA.GetDataTree(0, out T);

            // Algorithm
            List<string> sentences = new List<string>();
            for (int i = 0; i < T.Branches.Count; i++)
            {
                List<IGH_Goo> branch = T.Branches[i];
                GH_Path path = T.Paths[i];
                string str = "Branch " + path.ToString() +
                  " contains " + branch.Count + " elements";
                sentences.Add(str);
            }

            DA.SetData(0, T.TopologyDescription);
            DA.SetDataList(1, sentences);
            DA.SetDataList(2, T.Paths);
            DA.SetData(3, T.Branches.Count);
            DA.SetData(4, T.DataCount);
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
            get { return new Guid("B33A0424-2E5C-4D5B-A949-6FBA03AA2832"); }
        }
    }
}