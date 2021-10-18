using System;
using System.Collections.Generic;
using System.Text;

namespace first_test
{
   
    class scoter
    {
        public int mileage { get; set; }


        public static implicit operator carr(scoter s)
        {
            return new carr { mileage = s.mileage };
        }

    }

    class carr
    {
        public int mileage { get; set; }

    }

    public class Address
    {
        public ZipCode ZipCode { get; set; }
    }

    public class ZipCode
    {
        private readonly string _value;

        public ZipCode(string value)
        {
            // perform regex matching to verify XXXXX or XXXXX-XXXX format
            _value = value;
        }

        public override string ToString()
        {
            return Value;
        }
        public string Value
        {
            get { return _value; }
        }

        //I prefer explicit operators when converting from primitives, and implicit operators when converting to primitives

        public static implicit operator string(ZipCode zipCode)
        {
            return zipCode.Value;
        }

        public static explicit operator ZipCode(string value)
        {
            return new ZipCode(value);
        }
    }
}
