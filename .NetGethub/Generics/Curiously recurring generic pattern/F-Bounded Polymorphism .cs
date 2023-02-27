using Generics.Curiously_recurring_generic_pattern.Problem;
using System.Runtime.CompilerServices;

namespace Generics.Curiously_recurring_generic_pattern.Solution
{
    // F-Bounded Polymorphism 
    // The problem here is that the compiler will not force 
    // us to use the correct type in the cat class we used the 
    // list of dogs wich is not correct 
    // problem : we can still have some mistakes for ex 
    //  public class Cat : Animal<Dog> if we define the class this way 
    // then there is on checking if we implement the write type or not ,
    // so how to make the compiler force me that the class iam defining and 
    // and the type iam annotating the class with (the generic type) is the same.
    // solution: F Bounded Polymorphism + SelfTypes



    // if we use the abstract class the generic check 
    // is not performed ?!!
    //public abstract class Animal<T>
    //{
    //    List<T> Breed { get; set; }
    //}
    public interface IAnimal<T>
    {
        List<T> Breed { get; set; }
    }

    public abstract class Animal<T> : IAnimal<T>
    {
        public List<T> Breed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class Dog : IAnimal<Dog>
    {
        public List<Dog> Breed { get; set; }
    }
    public class Cat : IAnimal<Dog>
    {
        public List<Dog> Breed { get; set; }

    }
    public class FBoundedPolymorphism
    {
        public static void Run()
        {
            // Cat cat = new Cat();
            // cat.Breed = new List<Cat>
            // {
            //     new Cat()
            // };
        }
    }
}
