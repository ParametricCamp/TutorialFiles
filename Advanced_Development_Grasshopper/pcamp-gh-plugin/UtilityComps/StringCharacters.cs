﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.UtilityComps
{
    public class StringCharactersComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the StringConcatComponent class.
        /// </summary>
        public StringCharactersComponent()
          : base("String Characters", "String Characters",
              "",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("String A", "A", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Result", "R", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string a = "";

            if (!DA.GetData(0, ref a)) return;

            List<char> characters = new List<char>();

            for (int i = 0; i < a.Length; i++)
            {
                characters.Add(a[i]);
            }

            DA.SetDataList(0, characters);
        }

        public override GH_Exposure Exposure => GH_Exposure.secondary;


        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Properties.Resources.pc_inv;

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("3E589FCD-9457-4C09-9917-68D73C4E42A0"); }
        }
    }
}