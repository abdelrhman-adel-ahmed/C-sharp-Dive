using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomeServerControls
{
    [ToolboxData("<{0}:CustomCalender runat=server></{0}:CustomCalender>")]
    public class CustomCalender:CompositeControl
    {
        TextBox textBox;
        ImageButton imageButton;
        Calendar calendar;

        protected override void CreateChildControls()
        {
            textBox = new TextBox();
            textBox.ID = "dateTextBox";
            textBox.Width = Unit.Pixel(80);

            imageButton = new ImageButton();
            imageButton.ID = "calenderImageButton";

            calendar = new Calendar();
            calendar.ID = "calenderControl";

            this.Controls.Add(textBox);
            this.Controls.Add(imageButton);
            this.Controls.Add(calendar);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            textBox.RenderControl(writer);
            imageButton.RenderControl(writer);
            calendar.RenderControl(writer);

        }
    }
}
