using System;
using System.Collections;

namespace first_test
{
    struct test {
        string name;
        public int age;
        public test(int age)
        {
            this = new test();
            this.age = age;
        }
    }
   
    public interface IBaseDto
    {
        public int age { get; set; }
        public int name { get; set; }
    }
    public interface ICUstome: IBaseDto
    {
        public int add1 { get; set; }
        public int add2 { get; set; }
    }

    public class BaseDTO : IBaseDto
    {
        public int age { get; set; }
        public int name { get; set; }
    }
    public  class CustomeDTO :BaseDTO , ICUstome
    {
        public int add1 { get; set; }
        public int add2 { get; set; }
    }

    public class Dal
    {
        public static void rrr(ICUstome b)
        {
            Console.WriteLine(b.add1);
        }
    }
    class Program
    {

        static void day1()
        {
            Console.WriteLine("Hello World!");
            fun1();
            Class1 obj = new Class1();
            int a = 100; //you must initizalie if you pass by refrence
            obj.Refrence(ref a);
            Console.WriteLine(a);//10


            int o1 = 1; //you intialize of not intialize .
            string o2;
            obj.Out(out o1, out o2);
            Console.WriteLine("{0}  {1}", o1, o2);//31 ,aa


            Console.WriteLine("--------------------property set--------------------");
            //property
            Class2 obj2 = new Class2();

            obj2.Name = "ahmed";
            obj2.Func();
            obj2.Age = 1;
            obj2.Func();

            Console.WriteLine(obj2.Name);
            Console.WriteLine("------------------problem that property solve----------------------");

            //one problem that property fix 

            Employee emp1 = new Employee("taha", "ali");

            emp1.first_name = "ramy";
            //email will not get updated because it intialized at object construction
            //we dont want to change the email manuly each time we change the first or last name
            //emp1.email = objemp1first_name + "." + emp1.last_name +"gmail.com";
            Console.WriteLine(emp1.first_name);
            Console.WriteLine(emp1.email);
            Console.WriteLine(emp1.Fullname());

            Console.WriteLine("---------------------fix-------------------");

            EmployeeFix emp2 = new EmployeeFix("taha", "ali");

            emp2.First_name = "ramy";
            Console.WriteLine(emp2.First_name);
            Console.WriteLine(emp2.Email);
            Console.WriteLine(emp2.Fullname());

        }
        static void fun()
        {
            Class1 oo = new Class1();
        }
        static void fun1()
        {
            Console.WriteLine("func1 get called");

            fun();
        }


        static void Boxing()
        {
            object o = 6;
            object d = 5;
            Type t = d.GetType();
            Console.WriteLine(t.BaseType); //-->sys.valuetype why not sys.object since it refrence now ?
            object dd = 12;
            int temp = (int)dd;
            //long tt =(long)dd; //error you have to unbox to the same type you boxed to 
            long ttt = (int)dd; //first it will unbox dd to int and then do implict casting for that int to long
            Console.WriteLine(dd);
        }

        static int? getbalancefromtaxman()
        {
            return null;
        }
        static void ell(int[] x)
        {
            x[0] = 31;
        }

        class els
        {
            public int i;
        }

        //1- normal inhertance with override the methods ,you must declare it virtual in the base
        //2- interface ,all methods are public and abstract by diffult ,and no need for override keyword
        //3- abstract class ,can have non abstract mehtods ,cannot instantiate object from abstract class
        /*But why use interfaces rather than abstract classes?
        A class can inherit from just one base class, but it can implement multiple interfaces!*/
        //class A: IShape, IAnimal, etc.
        class People
        {
            //method must be declared virtual in order to override it in the drived class
            public virtual void people_type()
            {
                Console.WriteLine("people");
            }
        }
        class Emp : People
        {
            public override void people_type()
            {
                Console.WriteLine("employee");
            }
        }


        public interface IShape
        {
            //interface (only) contain abstract methods,all member of the interface are by diffult 
            //abstract, so you can ommit the abstract keyword
            //interface cannot contain instance attribute ,but it can contain default property
            //all methods in the interface are public by diffult
            float speed { get; }
            //int x;  not allowed
            Class2 ty { get; set; }

            public abstract void print();

            public int area();

            //deafult implementation ,before c#8 this wasnot allowed
            //default implementation can be freely overridden inside the class which implements that interface.
            //Note that a class does not inherit members from its interfaces; that is not changed by this feature.
            //so we cannot access greeding from an object of square,unless we override it 
            public void greeding()
            {
                Console.WriteLine("hello");
            }
        }
        class sqaure : IShape

        {
            public float speed { get; set; }
            public Class2 ty { get; set; }

            //override keyword not needed when impleminting the interface abstract functions
            int x;
            public int area()
            {
                return x * x;
            }

            public void print()
            {
                Console.WriteLine("sqaure");
            }

        }

        abstract class weapon
        {
            public abstract string damage();

            //abstract class can contain non abstract methods ,but still you cannot create instance from abstract class
            public void play()
            {
                Console.WriteLine("playing");
            }
        }
        class m4 : weapon
        {
            public override string damage()
            {
                return "m4 damage is 13";
            }
        }
        class akm : weapon
        {
            public override string damage()
            {
                return "akm damage is 14";
            }
        }
        static void weapn_damage(weapon w)
        {
            Console.WriteLine(w.damage());

        }


        class car
        {
            public string name;
            public motor m = new motor();

            public class motor
            {
                public string motor_type;
            }

        }
        class pack
        {
            public char a;
            public char b;
            public int c;
        }


        public class Farm
        {

            public Farm()
            {
                Console.WriteLine("farm construtor");

            }
            Cow c1 = new Cow("betsy");
            Cow c2 = new Cow("georgy");

        }

        class JameFarm : Farm
        {
            public JameFarm()
            {
                Console.WriteLine("jame farm constructor");
            }
            Cow jamiefow = new Cow("jamie cow");

        }

        class Cow
        {
            public Cow(string name)
            {
                Console.WriteLine($"cow {name}");
            }
        }


        class test
        {
            public int x;
        }

        struct hnb
        {
            public int x;
            public int y;

        }



        class animal { }
        class dog : animal { }
        class cat : animal
        {
        }
        static void Main(string[] args)
        {

            //////day1();
            ////string x = "a";
            ////test t =new test(321);
            ////ttt l = new ttt();
            ////Console.WriteLine(t.age);
            ////Console.WriteLine(l.GetType());
            ////Console.WriteLine(t.GetType().BaseType);
            ////Console.WriteLine(x.GetType().BaseType);
            //Console.WriteLine("------------------Linked List---------------------");
            //Node n = new Node();
            //for(int i=0;i<10;i++)
            //{
            //    n.Insert(i);
            //}
            ////Console.WriteLine(n.head.next.next);
            //n.Display();
            //n.Delete(0);
            //n.Delete(13);
            //n.Display();
            //Console.WriteLine(n.Find(10)); 
            //Console.WriteLine("---------------------------------------");
            //unsafe
            //{
            //    int age = 10;
            //    int* ptr =&age;
            //    Console.WriteLine($"virtual address of the ptr is {(int)ptr} the value is {*ptr}");
            //}

            //Console.WriteLine("-----------Boxing-------------");
            //Boxing();
            //int j = 1;
            //object o = j;
            //Console.WriteLine(j.GetType().BaseType);
            //Console.WriteLine(o.GetType().BaseType);


            //Console.WriteLine("------------------------------------");
            //ttt obj = new ttt();
            //int[] arr = new int[3];
            //arr[0] = 100;
            //obj.x = 100;
            //ell( arr);
            //Console.WriteLine(arr[0]);
            //int sss = 0;

            //if(sss==0)
            //    Console.WriteLine("yes");
            //Console.WriteLine("------------------------------------");

            //Console.WriteLine("----------------static class--------------------");
            //static_class.x = 100;
            //Console.WriteLine(static_class.x);
            //static_class.play();
            //Console.WriteLine("------------nullabel------------------------");

            //int? x = getbalancefromtaxman();
            //Console.WriteLine($"vaule is null here {x}");

            //int? v= 1; // v can have from int.max to int.min + one additional value wich is null
            //int? z = null;//int? == Nullabel<int> z=null;
            //Nullable<int> u = 5; // compiler do that  Nullable<int> u = new Nullable<int>(5)

            //Console.WriteLine(v+z);
            //Console.WriteLine($"null + any thing is null {u + v}") ;

            //Console.WriteLine("------------Hullabel------------------------");
            //HNullable<int> h = new HNullable<int>(5);
            //HNullable<int> t = new HNullable<int>(3);
            //HNullable<int> y =  new HNullable<int>(); //will zero out every thing that mean hasvalue will be 0 ->false

            //Console.WriteLine(h);
            //Console.WriteLine(y);
            //// Console.WriteLine(h+t); built in Nullable doesnot override + operator because for example if 
            ////you have nullable of datatime its not convineat to add two date time together what happen is 
            //HNullable<int> sum = (h.HasValue && t.HasValue) ? new HNullable<int>(h.Value + t.Value) :
            //     new HNullable<int>();
            ////so if both has value then create another nullabel that have the sum , if not create zero nullable
            //Console.WriteLine(sum);
            //int? m = null;
            //Console.WriteLine(m.ToString() ==""); //so thats why we return empty string if there is no value not null

            //int qw;
            //int qr = 10;
            //qw = m ?? qr; //(null coalescing operator) qw =m if m is not null if m is null then qw =qr
            //Console.WriteLine(qw);

            //int? ur = 3;
            //int ui = (int)ur;
            //Console.WriteLine("------------------------------------");

            //Console.WriteLine("-------------------Stack-----------------");
            //Stack s = new Stack();
            //for(int i=0;i<5;i++)
            //{
            //    s.Push(i);
            //}
            //Console.WriteLine(s.Pop());
            //Console.WriteLine(s.Pop());

            //Console.WriteLine("-----------------------------------");
            //els po = new els();
            //po.i = 1;
            //els ss = po;
            //ss.i = 10;
            //Console.WriteLine(po.i);
            //Console.WriteLine("-----------------------------------");
            //m4 obs = new m4();
            //akm obk = new akm();
            //weapn_damage(obs);
            //weapn_damage(obk);
            //Console.WriteLine("-----------------------------------");

            //sqaure sv = new sqaure();
            //IShape ccc = sv;
            //ccc.greeding();
            //sv.print();
            ////sv.greeding(); error
            //Console.WriteLine(  sv.ty);
            //Console.WriteLine("-----------------------------------");
            //car cs = new car();

            //cs.m.motor_type = "m11";
            //car ddd = new car();
            //ddd.m.motor_type = "m14";
            //Console.WriteLine(cs.m.motor_type);
            //Console.WriteLine(ddd.m.motor_type);

            //Console.WriteLine("-----------------------------------");
            //File.WriteAllText("t.txt", "hello");
            //Console.WriteLine("-----------------------------------");

            //types typ = new types();
            //Console.WriteLine(typ.max);
            //Console.WriteLine(typ.max_long);
            //typ.non_integer();
            //Console.WriteLine("-----------------------------------");


            //Conversion_dirve drivobj = new Conversion_dirve();
            //Conversion_base baseobj = new Conversion_base();

            ////drivobj = (Conversion_dirve)baseobj; base refrence base run time type check error 
            //baseobj = drivobj;
            //drivobj = (Conversion_dirve)baseobj; // alowed because base refrence drive object


            //Console.WriteLine("-----------------conversion operator------------------");
            //scoter sc = new scoter() {mileage= 12};
            //carr ca = new carr() { mileage =1};
            //ca = sc;

            //Console.WriteLine(ca.mileage);
            //Console.WriteLine(sc.mileage);

            ////Address addr = new Address();
            ////ZipCode zip = new ZipCode("1234");
            ////addr.ZipCode = zip;
            ////Console.WriteLine(addr.ZipCode);
            //Address addr = new Address();
            //addr.ZipCode = (ZipCode)"1234"; 
            //Console.WriteLine(addr.ZipCode);
            //string zipp = addr.ZipCode;
            //Console.WriteLine(zipp);
            //if(addr is  Address)
            //    Console.WriteLine("yse");

            //Console.WriteLine("-----------------------");

            //string str = "ahmed";
            //string str1 = str;
            //System.Text.StringBuilder sb = new System.Text.StringBuilder(str);
            //sb[0] = 'd';
            //str = sb.ToString();
            //char[] ch = str.ToCharArray();
            //ch[0] = 'd';
            //str = new string(ch);
            //Console.WriteLine(str);

            //Console.WriteLine("-------------costructor----------------");
            //pair<string, int> p1 = new pair<string, int> { first = "ahmed", second = 1 };
            //Console.WriteLine(p1);
            //Cow c = new Cow("a");
            //Console.WriteLine(c);

            //List<string> l1 = new List<string>();
            //l1.Add("ahmed");
            //l1.Add("mohaed");
            //l1.Add("a");
            //l1.Add("dsad");
            //List<string> l2 = l1;
            //l2.Display();
            //p(1);
            //p("string");
            //Node<string> n = new Node<string>();
            //n.Insert("a");
            //n.Insert("ab");
            //n.Insert("ac");
            //n.Insert("ad");
            //n.Display();
            //n.Delete("ac");
            //n.Display();
            //List<coww> l1 = new List<coww>();

            //Console.WriteLine("-----------generic open close types-------------");
            //openclose<openclose<string>> s = new openclose<openclose<string>>();

            //Console.WriteLine("--------------generics constrains-------------");
            //product<classone>();
            ////product<classtwo>(); //error, type that passed to the func must be parameterless constructor 

            //Dictionary<string, int> dict = new Dictionary<string, int>();
            //dict.Add("a", 1);
            //dict.Add("b", 2);
            //dict.Add("c", 3);
            //Dictionary<string, int>.KeyCollection.Enumerator i = dict.Keys.GetEnumerator();
            //while(i.MoveNext())
            //{
            //    Console.WriteLine(i.Current);
            //}
            //List<String> ValidSates = new List<string>{
            //"Completed",
            //"active",
            //"others"
            //        };
            //string x = "dd";
            //if (ValidSates.Contains(x))
            //    Console.WriteLine($"dsa {x}");


            //var listOFproperties = typeof(TestCach).GetProperties();
            // foreach (PropertyInfo item in listOFproperties)
            // {
            //    var value= item.GetGetMethod().Invoke(null,null);
            // }
            // decimal UsedSpace = 103999892M;
            // decimal totalspace = 2147483648M;
            // Console.WriteLine((UsedSpace / totalspace) *100);

            CustomeDTO b = new CustomeDTO { age = 1, name = 2,add1=1,add2=3 };
            Dal.rrr(b);

        }

        //constrain that t is classone or inherete from class one ,and it has parameterless constructor
        static T product<T>() where T :  new()
        {
            //we cannot say null because T may be value type and cannot say 0 because it can be refrence type
            //T returnvalue = default(T); 
            T returnvalue = new T();
            return returnvalue;
        }
        static void productA<T>(T args) where T :IEnumerable ,IComparable //impose multiple constraint one the value
            {
            }
        class classone :IEnumerable,IComparable{ public classone() { }

            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
       
        class classtwo { public classtwo(int a) { } }
        static void p<T>(T item)
        {
            Console.WriteLine(item);
        }
    }
     
        public class openclose<T>
            {
            static openclose()
        {
                Console.WriteLine(typeof(openclose<T>));
        }
    }

        public class overloaded_constructor
        {
            string Name { get; set; }
            int Age { get; set; }
               
            public overloaded_constructor(string name)
            {
                Console.WriteLine("name");
                if (name.Length > 10)
                    throw new Exception();
                Name = name;
            }
            public overloaded_constructor(string name,int age):this(name) 
                //enable us to call other construcotrs instead of copy and past the name logic again
            {
                Console.WriteLine("age");
                Age = age;
            }
        }
        public  class coww
            {
            static int num;
            int id;
            public coww()
            {
                id = ++ num;
            }
            }
    
   

}
