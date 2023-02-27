using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Curiously_recurring_generic_pattern
{
    public abstract class Animal<T> where T : Animal<T>
    {
        List<T> Breed { get; set; }
    }
    public class Dog : Animal<Dog>
    {
        public List<Dog> Breed { get; set; }
    }
    public class Cat : Animal<Dog>
    {
        public List<Dog> Breed { get; set; }

    }
    public class FBoundedPolymorphismAndSelfTypes
    {
        public static void Run()
        {
           //Cat cat = new Cat();
           //cat.Breed = new List<Cat>
           //{
           //    new Cat()
           //};
        }
    }
}
