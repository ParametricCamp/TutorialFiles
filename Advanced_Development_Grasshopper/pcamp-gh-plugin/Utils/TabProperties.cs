using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Geometry;
using Grasshopper;
using Grasshopper.Kernel;


namespace PCampGHPlugin.Utils
{
    public class TabProperties : GH_AssemblyPriority
    {
        public override GH_LoadingInstruction PriorityLoad()
        {
            var server = Grasshopper.Instances.ComponentServer;

            server.AddCategoryShortName("PCamp", "PC");
            server.AddCategorySymbolName("PCamp", 'P');
            server.AddCategoryIcon("PCamp", Properties.Resources.pc);

            return GH_LoadingInstruction.Proceed;
        }
    }
}
