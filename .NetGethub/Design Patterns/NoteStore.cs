using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class NoteStore
    {

        public List<String> completed = new List<string>();
        public List<String> active = new List<string>();
        public List<String> others = new List<string>();
        public List<String> ValidSates = new List<string>{
            "completed",
            "active",
            "others"
        };

        public void AddNote(string name)
        {
            if (name.Length <= 0)
                throw new Exception("Name cannot be empty");

            if (name == "completed")
                completed.Add(name);

            else if (name == "active")
                active.Add(name);
            else
                others.Add(name);
        }
        public List<String> GetNotes(String state)
        {
            if (!ValidSates.Contains(state))
            {
                throw new Exception($"invalid state {state}");
            }
            if (state == "completed")
                return completed;
            else if (state == "active")
                return active;
            //if we remove the if it will work !!!!!!!!!!!!
            /*
             When the compiler looks at your code, it's sees a third path (the else you didn't code for) that could occur
            but doesn't return a value. Hence not all code paths return a value.*/
            //else if (state == "others")
            //    return others;
            else
                return others;
        }
    }
}
