using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace PCampGHPlugin.Simulation
{
    public class ElasticChain : GH_Component
    {
        // Declare persistent variables
        List<Point3d> nodes = new List<Point3d>();
        List<Vector3d> vels = new List<Vector3d>();

        /// <summary>
        /// Initializes a new instance of the ElasticChain class.
        /// </summary>
        public ElasticChain()
          : base("ElasticChain", "ElasticChain",
              "Simulates the deformation of an elastic chain over time",
              "PCamp", "Simulation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "R", "Reset simulation", GH_ParamAccess.item);
            pManager.AddBooleanParameter("AutoUpdate", "AU", "Automatic updates?", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Interval", "I", "Autoupdate interval in millis", GH_ParamAccess.item);

            pManager.AddPointParameter("Anchor0", "A0", "First anchor point", GH_ParamAccess.item);
            pManager.AddPointParameter("Anchor1", "A1", "Second anchor point", GH_ParamAccess.item);
            pManager.AddIntegerParameter("NodeCount", "C", "Number of chain subdivisions", GH_ParamAccess.item);
            pManager.AddNumberParameter("Mass", "M", "Particle mass", GH_ParamAccess.item);
            pManager.AddVectorParameter("Gravity", "G", "Gravity force", GH_ParamAccess.item);
            pManager.AddNumberParameter("Stiffness", "S", "Spring stiffness factor", GH_ParamAccess.item);
            pManager.AddNumberParameter("Friction", "F", "Friction factor", GH_ParamAccess.item);
        }


        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Nodes", "N", "Chain Nodes", GH_ParamAccess.list);
            pManager.AddVectorParameter("Velocities", "V", "Volcity vectors", GH_ParamAccess.list);
            pManager.AddCurveParameter("Chain", "C", "Chain polyline", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Placeholder variables
            bool reset = false;
            bool autoupdate = false;
            int millis = 1000;
            
            Point3d anchor0 = Point3d.Unset;
            Point3d anchor1 = Point3d.Unset;
            int nodeCount = 10;
            double mass = 0;
            Vector3d gravity = Vector3d.Unset;
            double stiffness = 0;
            double friction = 0;

            // Retrieve inputs
            if (!DA.GetData(0, ref reset)) return;
            if (!DA.GetData(1, ref autoupdate)) return;
            if (!DA.GetData(2, ref millis)) return;
            if (!DA.GetData(3, ref anchor0)) return;
            if (!DA.GetData(4, ref anchor1)) return;
            if (!DA.GetData(5, ref nodeCount)) return;
            if (!DA.GetData(6, ref mass)) return;
            if (!DA.GetData(7, ref gravity)) return;
            if (!DA.GetData(8, ref stiffness)) return;
            if (!DA.GetData(9, ref friction)) return;

            // Solver
            // Algorithm
            if (reset)
            {
                nodes.Clear();
                vels.Clear();

                Line line = new Line(anchor0, anchor1);
                NurbsCurve lineCurve = line.ToNurbsCurve();

                Point3d[] pts;
                lineCurve.DivideByCount(nodeCount - 1, true, out pts);
                nodes.AddRange(pts);

                for (int i = 0; i < nodeCount; i++)
                {
                    vels.Add(new Vector3d(0, 0, 0));
                }
            }

            if (nodes.Count == 0) return;

            // Update the location of the anchors
            nodes[0] = anchor0;
            nodes[nodes.Count - 1] = anchor1;

            // Simulate forces for each node
            for (int i = 1; i < nodes.Count - 1; i++)
            {
                Point3d n = nodes[i];
                Vector3d v = vels[i];

                // Calculating all the forces
                Vector3d gravityForce = mass * gravity;
                Vector3d prevSpring = -stiffness * (n - nodes[i - 1]);
                Vector3d nextSpring = -stiffness * (n - nodes[i + 1]);

                // Aggregate all the forces
                Vector3d totalForce = gravityForce + prevSpring + nextSpring;

                // Update velocity
                v += totalForce;

                // Add friction
                v *= friction;

                // Update location of the node
                n += v;

                // Update values on the original lists
                nodes[i] = n;
                vels[i] = v;
            }

            // Outputs
            DA.SetDataList(0, nodes);
            DA.SetDataList(1, vels);
            DA.SetData(2, new Polyline(nodes));

            // Schedule a new solution
            if (autoupdate)
            {
                this.OnPingDocument().ScheduleSolution(millis, doc =>
                {
                    this.ExpireSolution(false);
                });
            }
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
            get { return new Guid("86D14780-FCDC-4E9F-95C4-86869500F326"); }
        }
    }
}