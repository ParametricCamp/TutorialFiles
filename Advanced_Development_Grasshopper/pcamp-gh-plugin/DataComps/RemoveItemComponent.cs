using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.DataComps
{
    public class RemoveItemComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the RemoveItemComponent class.
        /// </summary>
        public RemoveItemComponent()
          : base("Remove Item", "RemItem",
              "Removes an item from a list",
              "PCamp", "Data")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("List", "L", "List to remove from", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Index", "i", "Index of element to remove", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("List", "L", "Clean list", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<object> L = new List<object>();
            int i = 0;

            if (!DA.GetDataList(0, L)) return;
            if (!DA.GetData(1, ref i)) return;

            // Sanity
            if (i < 0 || i > L.Count - 1)
            {
                this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Index out of bounds!");
                DA.SetDataList(0, L);
                return;
            }

            // Algorithm
            L.RemoveAt(i);

            // Outputs
            DA.SetDataList(0, L);
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
            get { return new Guid("B0309BCC-B44B-455F-992E-FF8C28C99A5F"); }
        }
    }
}