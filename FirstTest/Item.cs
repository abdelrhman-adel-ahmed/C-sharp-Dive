namespace FirstTest
{
    internal class Item
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Item(int quantity, double price)
        {
            Quantity = quantity;
            Price = price;
        }
    }
}