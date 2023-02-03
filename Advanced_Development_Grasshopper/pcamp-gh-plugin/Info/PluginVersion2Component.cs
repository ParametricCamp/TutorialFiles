using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.Info
{
    public class PluginVersion2Component : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PluginVersionComponent class.
        /// </summary>
        public PluginVersion2Component()
          : base("Plugin Version", "Version",
              "Returns PCamp plugin version (improved)",
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
            pManager.AddIntegerParameter("Major", "Ma", "", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Minor", "Mi", "", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Patch", "P", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Outputs
            DA.SetData(0, PCampGHPlugin.Utils.CustomPluginProperties.Version);
            DA.SetData(1, Utils.CustomPluginProperties.MAJOR_VERSION);
            DA.SetData(2, Utils.CustomPluginProperties.MINOR_VERSION);
            DA.SetData(3, Utils.CustomPluginProperties.PATCH_VERSION);
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
            get { return new Guid("6f56e076-9f64-45e9-a25a-a80602b4cee6"); }
        }
    }
}