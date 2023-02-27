namespace Generics.Curiously_recurring_generic_pattern.Problem
{
    //   F-Bounded Polymorphism 
    //The problem here is that the compiler will not force 
    //us to use the correct type in the cat class we used the 
    //list of dogs wich is not correct 
    public abstract class Animal
    {
        List<Animal> Breed { get; set; }
    }
    public class Dog : Animal
    {
        public List<Dog> Breed { get; set; }
    }
    public class Cat : Animal
    {
        public List<Dog> Breed { get; set; }

    }
    internal class Problem
    {
    }

}
