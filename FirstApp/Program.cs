using System;
using Enterprises;

namespace FirstApp
{
    class Program
    {
        static void Added(object sender, EnterpriseEventsArgs e)
        {
            Console.WriteLine(e.Message);
        }
        static void Add(Shop shop)
        {
            String name, shelfLife;
            int amount;
            Console.WriteLine("Enter product name");
            name = Console.ReadLine();
            Console.WriteLine("Enter the expiration date of the product");
            shelfLife = Console.ReadLine();
            Console.WriteLine("Enter the amount of the product");
            amount = Convert.ToInt32(Console.ReadLine());
            Product product = new(name, amount, shelfLife);
            shop.AddProduct(product);
        }
        static void Main(string[] args)
        {
            EnterpriseHandler added = Added;
            Shop a = new Shop(Added, Added, Added, Added);
            Console.WriteLine("Hello World!");
            Add(a);
        }
    }
}
