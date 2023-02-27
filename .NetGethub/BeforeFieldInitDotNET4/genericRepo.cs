using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeFieldInitDotNET4
{
    public class genericRepo : IgenericRepo
    {
        string _path;
        public genericRepo(string path)
        {
            Console.WriteLine(path);
            _path = path;
        }

        public void RunRepo()
        {
            Console.WriteLine($"RunRepo path {_path}");
        }
    }
}
