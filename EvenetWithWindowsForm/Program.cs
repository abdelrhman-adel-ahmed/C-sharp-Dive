using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvenetWithWindowsForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Random rand = new Random();
        static Button but2 = new Button { Text = "button 2" };

        [STAThread]

        static void Main()
        {
            var but1 = new Button { Text = "button 1" };
            TextBox text = new TextBox { Left = 90 };
            text.MouseHover += changethelocation;
            but1.Click += buttonGetClicked;
            but2.Click += buttonGetClicked;
            but2.MouseHover += ChangeLocation;
            but2.Top = 50;
            var form = new Form();
            form.Width = 600;
            form.Height = 600;

            form.Controls.Add(but1);
            form.Controls.Add(but2);
            form.Controls.Add(text);

            Application.Run(form);
        }
        static void buttonGetClicked(object sender, EventArgs args)
        {
            //just for the show :-)
            if (sender is Button)
            {
                Button b = sender as Button;
                MessageBox.Show($"{b.Text} was clicked");

            }
            MessageBox.Show(sender.ToString());
        }
        static void changethelocation(object sender,EventArgs args)
        {

        }
        static void ChangeLocation(object sender ,EventArgs args)
        {
            but2.Top = rand.Next() % 200;
            but2.Left = rand.Next() % 200;
        }
    }
}
