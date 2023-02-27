using System;

namespace Monads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BadExample();
            UsingCompositionalMonadic();
        }

        private static void UsingCompositionalMonadic()
        {
            string foo = null;
            int length = foo.Bind(x => x.Trim().Nil())
                            .Bind(x => x.Substring(0, 5).Nil())
                            .Bind(x => x.Length.Nil())
                            .Value;
        }

        public static void BadExample()
        {
            string foo = null;
            if (foo != null)
            {
                foo = foo.Trim();
            }
            if (foo != null)
            {
                foo = foo.Substring(0, 5);
            }
            int n = foo == null ? 0 : foo.Length;

            //This is some sort of monad (its of course just a sentac sugar),we apple to change the calls
            int nn = foo?.Trim()?.Substring(0, 5)?.Length ?? 0;
        }
    }
    //monadic type (wraper type) that have the type and the extra behavoir we wanna abstract 
    //in this case the nullabilty
    public struct Nil<T>
    {
        public Nil(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public bool HasValue => Value != null;
    }
    public static class Ext
    {    
        //convert normal type to a monadic type
        public static Nil<T> Nil<T>(this T value)
        {
            return new Nil<T>(value);
        }

        //a.then(f).then(g).then(j)
        //compose functinos that output monadic values
        public static Nil<C> Bind<B, C>(this B b, Func<B, Nil<C>> fn)
        {
            return b.Nil().Bind(fn);
        }

        //f(a).then(g).then(j)
        //compose functinos that output monadic values , this takes the wraper type 
        //The above function takes the normal type wrape it and call this function.
        public static Nil<C> Bind<B, C>(this Nil<B> b, Func<B, Nil<C>> fn)
        {
            return b.HasValue ? fn(b.Value) : new Nil<C>();
        }

    }
}
