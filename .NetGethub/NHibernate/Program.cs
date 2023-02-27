using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateTest
{
    class Wallet
    {
        public int Id { get; set; }
        public string Holder { get; set; } = null!;
    }
    class WalletMapping : ClassMapping<Wallet>
    {
        private static void Zrboo(Action<int> cc)
        {
            cc(1);
        }
        public WalletMapping()
        {
            Zrboo(c => { Console.WriteLine(c); });
            Id(x => x.Id, c => c.Generator(Generators.Identity));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WalletMapping w = new WalletMapping();
            Action<int> cc = (c) => { Console.WriteLine(c); };

            Console.WriteLine("Hello, World!");
        }
    }
}