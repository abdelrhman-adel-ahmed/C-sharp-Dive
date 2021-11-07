using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormFirst.usercontrols
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

    public delegate void CalenderVisibilityChangedEventHandler(object sender, CalenderVisabilityChangedEventArgs e);
}