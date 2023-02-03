using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.Info
{
    public class PluginVersionComponent_OBSOLETE : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PluginVersionComponent class.
        /// </summary>
        public PluginVersionComponent_OBSOLETE()
          : base("Plugin Version", "Version",
              "Returns PCamp plugin version",
              "PCamp", "Info")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            // Nothing here!
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Version", "V", "Plugin version (semantic).", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Outputs
            DA.SetData(0, PCampGHPlugin.Utils.CustomPluginProperties.Version);
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
            get { return new Guid("5368C463-878E-4703-8436-878C70D690D0"); }
        }

        public override GH_Exposure Exposure => GH_Exposure.hidden;
    }
}