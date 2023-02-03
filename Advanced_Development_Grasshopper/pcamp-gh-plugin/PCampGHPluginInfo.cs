using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace PCampGHPlugin
{
    public class PCampGHPluginInfo : GH_AssemblyInfo
    {
        public override string Name => "PCampGHPlugin";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "A general toolbox of components to do stuff, mostly for educational purposes.";

        public override Guid Id => new Guid("695E3BB6-F3BA-41B1-8942-F3161FDB1CDF");

        //Return a string identifying you or your company.
        public override string AuthorName => "Jose Luis Garcia del Castillo @ ParametriCamp";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "http://youtube.com/ParametricCamp";
    }
}