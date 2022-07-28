using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter5_primitives_refrence_and_value_types_.ChangeField
{
    interface IChangeBoxedPoint
    {
        void Change(int x, int y);
    }
    struct Point : IChangeBoxedPoint
    {
        private int m_x, m_y;
        public Point(int x, int y)
        {
            m_x = x;
            m_y = y;
        }
        public void Change(int x, int y)
        {
            m_x = x; m_y = y;
        }
        public override String ToString()
        {
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }
    }
    public class ChangeFieldInBoxedTypes
    {
        public static void Run()
        {
            Point p = new Point(1, 1);
            Console.WriteLine(p);
            p.Change(2, 2);
            Console.WriteLine(p);
            Object o = p;
            Console.WriteLine(o);
            ((Point)o).Change(3, 3);
            Console.WriteLine(o);
            // Boxes p, changes the boxed object and discards it 
            ((IChangeBoxedPoint)p).Change(4, 4);
            Console.WriteLine(p);
            // Changes the boxed object and shows it 
            ((IChangeBoxedPoint)o).Change(5, 5);  
            Console.WriteLine(o);

        }
    }
}
