using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormFirst
{
    public class CalenderValueChangedEventArgs:EventArgs
    {

        private  DateTime _datetime;

        public CalenderValueChangedEventArgs(DateTime datetime)
        {
            _datetime = datetime;
        }

        public DateTime DateTime { get { return _datetime; } }

    }
}