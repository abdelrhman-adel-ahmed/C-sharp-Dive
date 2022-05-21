using NUnit.Framework;
using System.Collections.Generic;

namespace FirstTest
{
    class BasketTest
    {
        [Test]
        public void JustCreatedBasketIsEmpty()
        {
            Basket basket = new Basket(new List<Item>());
            Assert.AreEqual(basket.IsEmpty(), true);
        }
        [Test]
        public void BasketWithItemIsNotEmpty()
        {
            Basket basket = new Basket(new List<Item> { new Item(quantity:1 ,price:100)});
            Assert.AreEqual(basket.IsEmpty(), false);
        }
    }

}
