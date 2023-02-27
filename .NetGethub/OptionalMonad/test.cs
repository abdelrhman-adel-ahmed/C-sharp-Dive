using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalMonad
{
    internal class test
    {
        public static IEnumerable<string> Run()
        {
            foreach (var item in new List<String>())
            {
                yield return item;
            }
        }
    }
}
