using System;
using System.Collections.Generic;

namespace first_test
{
    class Class1
    {

        //pass by refrence ,must be specifed in the function as long as when we pass the var 
        //if the parameter is specified to be passed by refrence you must pass it by refernce

        public void Refrence(ref int a)
        {
            Console.WriteLine("Refrence get called");
            a = 10;
        }

        //out ,it kinda of pass by refrence it spit out multiple value for the vars that you passs
        // the diffrence is you can pass uninitialized parameters,not like pass refrence you must give
        //value to the var you passed by refrence .
        public void Out(out int a, out string c)
        {
            Console.WriteLine("Out get called");
            a = 31;
            c = "aa";
        }
        ~Class1()
        {
            Console.WriteLine("dis");
        }
    }


    class Class2

    {

        string name;
        //property include special methods called accessors, get or set or both ,its like property in python
        public string Name  //property
        {
            //With properties you have the option to control the logic of accessing the variable.
            get { return name; }
            set
            {
                if (value == "ahmed")
                {
                    name = value;
                }
                else
                {
                    name = "mohamed";
                }
            }
        }
        //auto-implemented property ,when there is no custom logic needed , you can do this 
        //without even create the actual attr ,it will be done implicitly
        public int Age
        { get; set; }

        public void Func()

        {
            Console.WriteLine("auto-implemented property");
            Console.WriteLine(Age);
        }
    }

    class Employee
    {

        public string first_name, last_name, email;
        public Employee(string first, string last)
        {
            first_name = first;
            last_name = last;
            email = first_name + "." + last_name + "@gmailcom";
        }
        public string Fullname()
        {
            return $"{first_name} {last_name}";
        }
    }


    class EmployeeFix
    {

        string first_name, last_name, email;
        public EmployeeFix(string first, string last)
        {
            first_name = first;
            last_name = last;
        }
        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }
        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string Fullname()
        {
            return first_name + last_name;
        }

        public string Email
        {
            get
            {
                return email = first_name + "." + last_name + "@gmailcom";
            }

        }
    }


    class Node<T>
        {
        public T data;
        public Node<T> next;
        public Node<T> head = null;

        public void Insert(T data)
        {
            Node<T> temp = new Node<T>();
            temp.data = data;
            temp.next = null;
            if (head==null)
            {
                head = temp;
                return;

            }
            Node<T> temp2 = head;
            while(temp2.next!=null)
            {
                temp2 = temp2.next;
            }
            temp2.next = temp;
        }
        void recursive_display(ref Node<T> head)
        {
            if (head == null)
            {
                return;
            }
            Console.WriteLine(head.data);
            recursive_display(ref head.next);
        }
        public void Display()
        {

            recursive_display(ref head);
        }
        public void Delete(T data)
        {
            if (head.data.Equals(data))
            {
                Node<T> temp2 = head.next;
                head= temp2;
                return;
            }
            Node<T> next_node = head;
            while (next_node.next != null && !EqualityComparer<T>.Default.Equals(next_node.next.data ,data) )
            {
                next_node = next_node.next;
            }
            if (next_node.next !=null)
                next_node.next = next_node.next.next;
        }

        public bool Find(T data)
        {
            Node<T> temp = head;
            while (temp.next !=null && !EqualityComparer<T>.Default.Equals(temp.data,data))
            {
                temp = temp.next;
            }
            if (EqualityComparer<T>.Default.Equals(temp.data ,data))
                return true;
            else
                return false;


        }
    }


    class Stack
    {
        public int[] arr = new int[100];
        int pointer = 0;

        public void Push(int value)
        {
            arr[pointer++] = value;
        }
        public int Pop()
        {
            return arr[--pointer];
        }
        public int Size()
        {
            return pointer; 
        }
        public void  Display()
        {
            for (int i=pointer; i>=0;i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }

    static class static_class
    {
        public static int x;
        const int y=100; //const are static by difullt
        const int tttt= 1 + 2;
        public static void play()
        {
            Console.WriteLine("play");
            //console ,math ,convert all of those are static classes 
        }

    }

    struct HNullable <T> where T:struct //mean t is value type
    {
        T value;
        bool hasValue; //if false means null (no value)
        public HNullable(T value)
        {
            this.value = value;
            hasValue = true;
        }
        public bool HasValue { get { return hasValue; } }
        public T Value { get { return value; } }

        //to print the value
        public override string ToString()
        {
            return hasValue? value.ToString() : "";
        }

        public override bool Equals(object other)
        {
            //if this is null and other is null so we equal each other, in c# null==null 
            if (!this.hasValue)
                return (other == null);
            //if other doesnot have value then we dont equal because i have value (passed the first check)
            if (other == null)
                return false;
            //if both have value then check if those value are equal
            return this.value.Equals(other);
            
        }


    }

}
