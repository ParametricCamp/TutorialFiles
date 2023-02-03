using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCampGHPlugin.Utils
{
    public static class PConsole
    {
        static List<string> lines = new List<string>();

        static public void WriteLine(string line)
        {
            lines.Add(line);
        }

        static public List<string> Read()
        {
            return lines;
        }

        static public void Clear()
        {
            lines.Clear();
        }

    }
}
