using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin
{
    //   █████╗ ██████╗ ██████╗                                       
    //  ██╔══██╗██╔══██╗██╔══██╗                                      
    //  ███████║██║  ██║██║  ██║                                      
    //  ██╔══██║██║  ██║██║  ██║                                      
    //  ██║  ██║██████╔╝██████╔╝                                      
    //  ╚═╝  ╚═╝╚═════╝ ╚═════╝                                       
    //                                                                
    //  ████████╗██╗    ██╗ ██████╗                                   
    //  ╚══██╔══╝██║    ██║██╔═══██╗                                  
    //     ██║   ██║ █╗ ██║██║   ██║                                  
    //     ██║   ██║███╗██║██║   ██║                                  
    //     ██║   ╚███╔███╔╝╚██████╔╝                                  
    //     ╚═╝    ╚══╝╚══╝  ╚═════╝                                   
    //                                                                
    //  ███╗   ██╗██╗   ██╗███╗   ███╗██████╗ ███████╗██████╗ ███████╗
    //  ████╗  ██║██║   ██║████╗ ████║██╔══██╗██╔════╝██╔══██╗██╔════╝
    //  ██╔██╗ ██║██║   ██║██╔████╔██║██████╔╝█████╗  ██████╔╝███████╗
    //  ██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██╔══██╗╚════██║
    //  ██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██████╔╝███████╗██║  ██║███████║
    //  ╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝
    //                                                                


    public class AdditionComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the AddNumbersComponent class.
        /// </summary>
        public AdditionComponent()
          : base("Addition", "Addition",
              "Adds two numbers together",
              "PCamp", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("NumberA", "A", "First value to add", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("NumberB", "B", "Second value to add", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Result", "R", "Addition result", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Define placeholder varibles
            double a = 0;
            double b = 0;

            // Load values from inputs into those variables
            if (!DA.GetData(0, ref a)) return;
            if (!DA.GetData(1, ref b)) return;

            // The code that actually does the work
            double sum = a + b;

            // Outputs
            DA.SetData(0, sum);
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Properties.Resources.pc_inv;


        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("A4A6506E-6918-435C-930C-AAB1CB8F7998"); }
        }
    }
}