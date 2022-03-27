using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFTest1.UserControls
{
    /// <summary>
    /// Interaction logic for DependencyProperty.xaml
    /// </summary>
    public partial class DependencyProperty : UserControl
    {
        public DependencyProperty()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal,
                delegate
                {
                    int newvalue = 0;
                    if (Counter == int.MaxValue)
                    {
                        newvalue = 0;
                    }
                    else
                    {
                        newvalue = Counter + 1;
                    }
                    SetValue(CounterProperty, newvalue);
                }, Dispatcher);
        }


        public int Counter
        {
            get { return (int)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Counter.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty CounterProperty =
            System.Windows.DependencyProperty.Register("Counter", typeof(int), typeof(DependencyProperty), new PropertyMetadata(0));


    }
}
