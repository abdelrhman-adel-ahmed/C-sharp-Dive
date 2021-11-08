using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    //delegate is a class so we can declare it outside a class !
    public delegate void CalenderVisibilityChangedEventHandler(object sender, CalenderVisabilityChangedEventArgs e);

    public partial class calenderControl : System.Web.UI.UserControl
    {
        
        public event EventHandler<CalenderVisabilityChangedEventArgs> CalenderVisibliyChanged;
        public event EventHandler<CalenderValueChangedEventArgs> CalenderChanged;
        //public event CalenderVisibilityChangedEventHandler CalenderVisibliyChanged;

        protected virtual void OnCalenderVisibilityChanged(CalenderVisabilityChangedEventArgs e)
        {
            if(CalenderVisibliyChanged!=null)
                CalenderVisibliyChanged(this,e);
        }
        protected virtual void OnCalenderChanged(CalenderValueChangedEventArgs e)
        {
            if (CalenderChanged != null)
                CalenderChanged(this, e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;

                //event args object
                CalenderVisabilityChangedEventArgs CalenderEventArgs = new CalenderVisabilityChangedEventArgs(false);
                //make sure that we have subscribers
                //if (CalenderVisibliyChanged!=null)
                //    CalenderVisibliyChanged(this, CalenderEventArgs);
                //or 
                OnCalenderVisibilityChanged(CalenderEventArgs);
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
                CalenderVisabilityChangedEventArgs CalenderEventArgs = new CalenderVisabilityChangedEventArgs(false);
                OnCalenderVisibilityChanged(CalenderEventArgs);
            }
            else
            {
                Calendar1.Visible = true;
                CalenderVisabilityChangedEventArgs CalenderEventArgs = new CalenderVisabilityChangedEventArgs(true);
                OnCalenderVisibilityChanged(CalenderEventArgs);
            }
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
            //visability changed event
            CalenderVisabilityChangedEventArgs CalenderEventArgs = new CalenderVisabilityChangedEventArgs(false);
            OnCalenderVisibilityChanged(CalenderEventArgs);
            //calender value changed event
            CalenderValueChangedEventArgs calenderchangedEventArgs = new CalenderValueChangedEventArgs(Calendar1.SelectedDate);
            OnCalenderChanged(calenderchangedEventArgs);
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
                e.Day.IsSelectable = false;
        }

       protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //add properties to access it in any webform that uses the calendercontrol
        public string SelectedDate
        {
            get
            {
                return TextBox1.Text;
            }
            set
            {
                TextBox1.Text = value;
            }
        }

    }
}