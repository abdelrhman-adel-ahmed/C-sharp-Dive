using System;
using System.Collections.Generic;
using System.Linq;

namespace benchMark
{
    public class User
    {
        public string Name { get; set; }
    }

    public class Sample
    {
        public readonly dynamic _valueDynamic = new User
        {
            Name = "zrbo"
        };
        public readonly User _value = new User
        {
            Name = "zrbo"
        };

        public string GetNameDynamic()
        {
            return _valueDynamic.Name;
        }

        public string GetName()
        {
            return _value.Name;
        }

        public List<string> GetNameInListDynamic()
        {
            return Enumerable.Range(0, 10000).Select(x => _valueDynamic.Name).Cast<string>().ToList();
        }

        public List<string> GetNameInList()
        {
            return Enumerable.Range(0, 10000).Select(x => _value.Name).ToList();
        }
    }
}