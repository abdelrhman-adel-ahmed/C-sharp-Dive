namespace Dependency_injection_tools
{
    public class Invoice
    {
        int quantity;
        int price;
        public Invoice(int price , int quantity)
        {
            this.price = price;
            this.quantity = quantity;
        }
    }
}