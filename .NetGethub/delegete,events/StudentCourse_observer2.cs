using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    public class StudentCourse_observer2
    {
        public static void run()
        {
            Course c1 = new Course("DB", 3);
            Course c2 = new Course("Os", 3);

            Student s1 = new Student(c1, "ahmed");
            Student s2 = new Student(c1, "laila");
            Student s3 = new Student(c1, "noha");
            Student s4 = new Student(c1, "said");
            Student s5 = new Student(c1, "zrbo");

            Console.WriteLine("----------waiting-----------");
            c1.DisplayWating();
            Console.WriteLine("------------enrrolled-------------");
            c1.DisplayEnrolled();
            Console.WriteLine("------------unsuscribe-------------");
            s1.UnSubscribe();
            Console.WriteLine("----------waiting-----------");
            c1.DisplayWating();
            Console.WriteLine("------------enrrolled-------------");
            c1.DisplayEnrolled();
            Console.WriteLine("------------unsuscribe-------------");
            s2.UnSubscribe();
            Console.WriteLine("----------waiting-----------");
            c1.DisplayWating();
            Console.WriteLine("------------enrrolled-------------");
            c1.DisplayEnrolled();


        }

        public enum StudentState
        {
            sucess,
            failed
        }
        public class StudentStateEventArgs : EventArgs
        {
            public StudentState StudentState { get; set; }
            public StudentStateEventArgs(StudentState s)
            {
                StudentState = s;
            }


        }
        public class Student
        {
            Course course;
            public string Name { get; set; }
            public event EventHandler Notify;

            public Student(Course c, string name)
            {

                Name = name;
                course = c;
                course.AddStudent += SubscribeStudent;
                course.Subscribe();
            }
            void SubscribeStudent(object sender, StudentStateEventArgs args)
            {
                if (args.StudentState == StudentState.sucess)
                    course.AddStudent -= SubscribeStudent;
                else
                {
                    course.AddStudent -= SubscribeStudent;
                    course.NotifyWaiting += NotifyMe;
                }

            }
            public void UnSubscribe()
            {
                course.UnSubscribe(this);
            }
            public void NotifyMe(object sender, EventArgs args)
            {
                course.NotifyWaiting -= NotifyMe;
                Console.WriteLine(Name + " had been added to the course " + course.course_name + " finally");
            }

        }
        public class Course
        {
            public string course_name;
            public bool availability;
            int max_student_num;
            int current_student_num = 0;
            public event EventHandler<StudentStateEventArgs> AddStudent;
            public event EventHandler NotifyWaiting;
            delegate void temp(object sender, EventArgs args);

            List<Student> StudentInCourse = new List<Student>();
            List<Student> WatingStudent = new List<Student>();
            public Course(string name, int max, bool avilable = true)
            {
                course_name = name;
                availability = avilable;
                max_student_num = max;
            }
            public void Subscribe()
            {
                if (current_student_num < max_student_num)
                {
                    StudentInCourse.Add(AddStudent.Target as Student);
                    current_student_num += 1;
                    AddStudent(this, new StudentStateEventArgs(StudentState.sucess));
                    return;
                }
                WatingStudent.Add(AddStudent.Target as Student);
                AddStudent(this, new StudentStateEventArgs(StudentState.failed));
            }
            public void UnSubscribe(Student s)
            {
                StudentInCourse.Remove(s);
                if (WatingStudent.Count > 0)
                {
                    Student waiting = WatingStudent[0];
                    WatingStudent.RemoveAt(0);
                    StudentInCourse.Add(waiting);
                    //hack to only invoke one waiting at a time ,and in the target method we unsubscribe our self
                    foreach (EventHandler e in NotifyWaiting.GetInvocationList())
                    {
                        e(this, EventArgs.Empty);
                        break;
                    }
                }
            }
            public void DisplayEnrolled()
            {
                foreach (Student o in StudentInCourse)
                    Console.WriteLine(o.Name);
            }
            public void DisplayWating()
            {

                foreach (Student o in WatingStudent)
                    Console.WriteLine(o.Name);
            }
        }
    }
}
