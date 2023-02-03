using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.UtilityComps
{
    public class StringConcatComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the StringConcatComponent class.
        /// </summary>
        public StringConcatComponent()
          : base("String Concatenation", "String Concat",
              "Concatenate two strings",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("String A", "A", "First string to concatenate", GH_ParamAccess.item);
            pManager.AddTextParameter("String B", "B", "Second string to concatenate", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Concat", "C", "Concatenated string", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Length", "L", "Length of the concatenated string", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Predefine empty storage variables
            string a = "";
            string b = "";

            // Fetch input data
            if (!DA.GetData(0, ref a)) return;
            if (!DA.GetData(1, ref b)) return;

            // Algorithm
            string concat = a + b;
            int len = concat.Length;

            // Outputs
            DA.SetData(0, concat);
            DA.SetData(1, len);
        }

        public override GH_Exposure Exposure => GH_Exposure.secondary;


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
            get { return new Guid("983A24F9-B513-4D4D-8317-5A5979FF4D82"); }
        }
    }
}