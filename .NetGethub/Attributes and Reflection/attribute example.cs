using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Attributes_and_Reflection
{
    [Serializable]
    class cow
    {
        public string name;
        public int weight;
    }
        
    class attribute_example
    {
        public static void run()
        {
            cow betsy = new cow { name = "betsy", weight = 120 };
            var memorystream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(memorystream, betsy);
            memorystream.Seek(0, SeekOrigin.Begin);
            var betsyclone = formatter.Deserialize(memorystream) as cow;
            Console.WriteLine(betsyclone.name);
            Console.WriteLine(betsyclone.weight);



        }
    }
}
