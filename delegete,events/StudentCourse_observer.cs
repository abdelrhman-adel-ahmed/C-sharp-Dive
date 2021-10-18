using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{


    public interface IObserver
    {
         void Update(bool avilability);
    }
     interface ISubject
    {
        public void Subscribe(IObserver b);
        public void Unsubscribe(IObserver b);
        public void NotifyAllSubscribers();
        public void NotifyWaitingSubscriber(IObserver b);
    }

    public class Student : IObserver
    {
        public string Name { get; set; }
        public Student(string name) { Name = name; }
        public void Update(bool message)
        {
            Console.WriteLine($"student {Name} has message course is {(message ?" avilable" : " not avilable yet")}");
        }
    }
    public class Course : ISubject
        {
        private string course_name;
        public bool availability ;
        private  List<IObserver> ObserverList = new List<IObserver>();
        private List<IObserver> ObserverWitingList = new List<IObserver>();
        int max_student_num;
        int current_student_num = 0;
        public Course(string name, int max,bool avilable=true)
        {
            course_name = name;
            availability = avilable;
            max_student_num = max;
        }
        public void NotifyAllSubscribers()
        {
            foreach(IObserver b in ObserverList )
            {
                b.Update(availability);
            }
        }
        public void NotifyAllWaitingSubscribers()
        {
            foreach (IObserver b in ObserverWitingList)
            {
                b.Update(availability);
            }
        }

        public void Subscribe(IObserver b)
        {
            bool Flag=false;
            if (current_student_num < max_student_num && availability == true)
            {
                Flag = true;
                ObserverList.Add(b);
                current_student_num++;
            }
            //if the observer already in the waiting list and we add it to the ObserverList
            if (Flag && ObserverWitingList.Contains(b))
            { ObserverWitingList.Remove(b); return; }
            //if the observer in the ObserverWitingList and we didont add it to the ObserverList
            else if (ObserverWitingList.Contains(b) && !Flag)
                return;
            else if (Flag)
                return;
            ObserverWitingList.Add(b);

        }
      
        public void Unsubscribe(IObserver b)
        {
            ObserverList.Remove(b);
            if(ObserverWitingList.Count >0)
            {
                IObserver waiting_observer = ObserverWitingList[0];
                ObserverWitingList.RemoveAt(0);
                //waiting observer want to unsubscribe
                if (waiting_observer.Equals(b))
                    return;
                ObserverList.Add(waiting_observer);
                NotifyWaitingSubscriber(waiting_observer);
                return;
            }
            current_student_num -= 1;
        }
        public void NotifyWaitingSubscriber(IObserver b)
        {
            b.Update(availability);
        }

        void SeeIfWiting()
        {
            //change later *temp solution
            List<IObserver> temp = new List<IObserver>(ObserverWitingList);
            foreach(IObserver b in temp)
            {
                Subscribe(b);
            }
          
        }
        public void SetAvilability(bool avilable)
        {
            availability = avilable;
            //if we set the avilability of the course to true ,go and check the waiting list
            if(availability)
                SeeIfWiting();
        }
    }



    class StudentCourse_observer
    {
        public static void  run()
        {
            Student s1 = new Student("ahmed");
            Student s2 = new Student("laila");
            Student s3 = new Student("noha");
            Student s4 = new Student("said");

            Course c1 = new Course("DB",3);
            Course c2 = new Course("Os",3);

            c1.Subscribe(s1);
            c1.Subscribe(s2);
            c1.Subscribe(s3);
            c1.Subscribe(s4);
            c1.Unsubscribe(s2);


        }
    }
}
