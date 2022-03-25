using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutableAndImutableIndotNet
{
    class UnsealedImmutable
    {
        public int value { get; }

        public UnsealedImmutable(int value)
        {
            value = value;
        }

    }

    class drivedFromImmutable : UnsealedImmutable
    {
        public int otherValue { get; set; }
        public drivedFromImmutable(int value) : base(value)
        {
        }
        public override string ToString() => otherValue.ToString();
    }
}
