using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeometryKernel
{
    public class Line
    {
        // FIELDS / PROPERTIES
        // These properties belong to an INSTANCE of this class. 

        // The coordinates of the start and end points. 
        public double StartX, StartY, StartZ;
        public double EndX, EndY, EndZ;

        // CONSTRUCTORS
        // These special functions return INSTANCES or OBJECTS derived from this class. 

        /// <summary>
        /// Create a MyLine object from two MyPoints. 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Line(Point start, Point end)
        {
            this.StartX = start.X;
            this.StartY = start.Y;
            this.StartZ = start.Z;
            this.EndX = end.X;
            this.EndY = end.Y;
            this.EndZ = end.Z;
        }

        /// <summary>
        /// Create a MyLine object from a MyPoint and a MyVector.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="direction"></param>
        public Line(Point start, Vector direction)
        {
            this.StartX = start.X;
            this.StartY = start.Y;
            this.StartZ = start.Z;
            this.EndX = start.X + direction.X;
            this.EndY = start.Y + direction.Y;
            this.EndZ = start.Z + direction.Z;
        }

        // INSTANCE METHODS
        // These methods act and work with INSTANCES of this class, 
        // and may use its INSTANCE properties. 

        /// <summary>
        /// Returns the length of this MyLine.
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            double dx = this.EndX - this.StartX;
            double dy = this.EndY - this.StartY;
            double dz = this.EndZ - this.StartZ;

            double len = Math.Sqrt(dx * dx + dy * dy + dz * dz);

            return len;
        }

        /// <summary>
        /// Returns a string representation of this object. Use the 'override' modifier to tell C#
        /// that you want to use this method to turn objects into strings, rather than the original
        /// one that comes by default with generic objects (you want to override it). 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Line (" + this.StartX + ", " + this.StartY + ", " + this.StartZ + ") to ("
                + this.EndX + ", " + this.EndY + ", " + this.EndZ + ")";
        }


    }
}
