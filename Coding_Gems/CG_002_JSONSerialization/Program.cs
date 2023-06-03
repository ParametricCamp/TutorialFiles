using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.Text.Json; // for non- .NET Framework

namespace JSONSerialization
{
    internal class Program
    {
        public class YouTuber
        {
            public string Name;
            public string Channel;
            public bool Active;
            public int Age;
            public List<string> Members;
        }

        static void Main(string[] args)
        {
            //string json = @"{
            //  'Name': 'Jose Luis',
            //  'Channel': 'ParametricCamp',
            //  'Active': true,
            //  'Age': 3,
            //  'Members': [
            //    'Richard',
            //    'Tim',
            //    'Victor',
            //    'Chandra',
            //    'Andres',
            //    'Nicholas'
            //  ]
            //}";

            string json = System.IO.File.ReadAllText(@"C:\Users\jlx\Desktop\parametriccamp.json");

            Console.WriteLine("Deserialized data:");
            YouTuber deserialized = JsonConvert.DeserializeObject<YouTuber>(json);
            Console.WriteLine(deserialized.Name);
            Console.WriteLine(deserialized.Channel);
            Console.WriteLine(deserialized.Active);
            Console.WriteLine(deserialized.Age);
            foreach (var member in deserialized.Members)
            {
                Console.WriteLine("Member: " + member);
            }

            Console.WriteLine("");
            Console.WriteLine("Serialized data");
            string serialized = JsonConvert.SerializeObject(deserialized);
            Console.WriteLine(serialized);

            Console.ReadKey();
        }
    }
}
