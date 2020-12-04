using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeometryKernel
{
    /// <summary>
    /// A class representing a Vector in three dimensions.
    /// </summary>
    public class Vector
    {
        // FIELDS / PROPERTIES
        // These properties belong to an INSTANCE of this class. 

        /// <summary>
        /// X coordinate
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
        /// Creates a zero (0, 0, 0) Vector.
        /// </summary>
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        /// <summary>
        /// Creates a MyVector from x, y, and z coordinates. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Creates a MyVector as a copy of other.
        /// </summary>
        /// <param name="other"></param>
        public Vector(Vector other)
        {
            this.X = other.X;
            this.Y = other.Y;
            this.Z = other.Z;
        }

        // INSTANCE METHODS
        // These methods act and work with INSTANCES of this class, 
        // and may use its INSTANCE properties. 

        /// <summary>
        /// Returns the length of this MyVector.
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            double len = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
            return len;
        }

        /// <summary>
        /// Flips the direction of this MyVector.
        /// </summary>
        public void Reverse()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }

        /// <summary>
        /// Scales this MyVector by a factor.
        /// </summary>
        /// <param name="factor"></param>
        public void Scale(double factor)
        {
            this.X *= factor;
            this.Y *= factor;
            this.Z *= factor;
        }

        /// <summary>
        /// Turns this into an unit vector. 
        /// </summary>
        public void Unitize()
        {
            double len = this.GetLength();  // notice how we use our own GetLength() method here...
            this.X /= len;
            this.Y /= len;
            this.Z /= len;
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

        // STATIC METHODS
        // These methods belong to the class itself, and cannot access properties of particular instances. 

        /// <summary>
        /// Returns a new MyVector that is the arithmetic addition of two other vectors. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector Addition(Vector a, Vector b)
        {
            Vector sum = new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            return sum;
        }

        /// <summary>
        /// Returns the dot product of two vectors. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static double DotProduct(Vector a, Vector b)
        {
            double dot = a.X * b.X + a.Y * b.Y + a.Z * b.Z;
            return dot;
        }

        /// <summary>
        /// Returns a new MyVector as the cross product of other two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector CrossProduct(Vector a, Vector b)
        {
            double x = a.Y * b.Z - a.Z * b.Y;
            double y = a.Z * b.X - a.X * b.Z;
            double z = a.X * b.Y - a.Y * b.X;

            Vector cross = new Vector(x, y, z);

            return cross;
        }

        /// <summary>
        /// Computes the angle between two MyVectors. It can optionally return the value in radians
        /// or degrees. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static double AngleBetween(Vector a, Vector b, bool degrees)
        {
            double dot = Vector.DotProduct(a, b);
            double lenA = a.GetLength();
            double lenB = b.GetLength();

            double ang = Math.Acos(dot / (lenA * lenB));  // angle in radians
            if (degrees)
            {
                // Convert the angle to degrees before returning
                ang = ang * 180.0 / Math.PI;
            }

            return ang;
        }

        /// <summary>
        /// Returns a new MyVector 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector BetweenPoints(Point from, Point to)
        {
            Vector v = new Vector(to.X - from.X, to.Y - from.Y, to.Z - from.Z);
            return v;
        }

    }
}
