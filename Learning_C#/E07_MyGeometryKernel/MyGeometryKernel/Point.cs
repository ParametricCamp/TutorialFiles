using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeometryKernel
{
    /// <summary>
    /// A class representing a Point in three-dimensional space. 
    /// </summary>
    public class Point
    {
        // FIELDS / PROPERTIES
        // These properties belong to an INSTANCE of this class. 

        /// <summary>
        /// X coordinate.
        /// </summary>
        public double X;

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public double Y;

        /// <summary>
        /// Z coordinate.
        /// </summary>
        public double Z;

        // CONSTRUCTORS
        // These special functions return INSTANCES or OBJECTS derived from this class. 

        /// <summary>
        /// Creates a MyPoint in the origin (0, 0, 0).
        /// </summary>
        public Point()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        /// <summary>
        /// Creates a MyPoint from x, y, and z coordinates. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Creates a MyPoint as a copy of other.
        /// </summary>
        /// <param name="other"></param>
        public Point(Point other)
        {
            this.X = other.X;
            this.Y = other.Y;
            this.Z = other.Z;
        }

        // INSTANCE METHODS
        // These methods act and work with INSTANCES of this class, 
        // and may use its INSTANCE properties. 

        /// <summary>
        /// Compute the distance from this MyPoint to another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double DistanceTo(Point other)
        {
            double dx = other.X - this.X;
            double dy = other.Y - this.Y;
            double dz = other.Z - this.Z;

            double d = Math.Sqrt(dx * dx + dy * dy + dz * dz);

            return d;
        }

        /// <summary>
        /// Returns a string representation of this object. Use the 'override' modifier to tell C#
        /// that you want to use this method to turn objects into strings, rather than the original
        /// one that comes by default with generic objects (you want to override it). 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ", " + this.Z + ")";
        }

    }
}
