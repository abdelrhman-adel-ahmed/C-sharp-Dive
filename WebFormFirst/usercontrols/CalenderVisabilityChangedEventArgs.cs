using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormFirst
{
    public class CalenderVisabilityChangedEventArgs:EventArgs
    {
        private bool _isvisible;
        public CalenderVisabilityChangedEventArgs(bool isvisible)
        {
            this._isvisible = isvisible;
        }
        public bool IsVisibility
        {
            get { return _isvisible; }
        }
    }

}