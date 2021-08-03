using System;
using Enterprises;

namespace FirstApp
{
    class Program
    {
        static void Added(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
            Console.WriteLine($"{sender.ToString()}: {e.Message}");
            Console.ResetColor();
        }
        static void Removed(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
            Console.WriteLine($"{sender.ToString()}: {e.Message}");
            Console.ResetColor();
        }
        static void GROE(object sender, EnterpriseEventsArgs e)
        {
            Console.WriteLine(e.Message);
        }
        static void Show(object sender, EnterpriseEventsArgs e)
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
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
                Product product = new(name, amount, shelfLife);
                try
                {
                    shop.AddProduct(product);
                }
                catch (EnterpriseException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }  
        }
        static void Remove(Shop shop)
        {
            String name, shelfLife;
            int amount;
            Console.WriteLine("Enter product name");
            name = Console.ReadLine();
            Console.WriteLine("Enter the expiration date of the product");
            shelfLife = Console.ReadLine();
            Console.WriteLine("Enter the amount of the product");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
                Product product = new(name, amount, shelfLife);
                try
                {
                    shop.RemoveProduct(product);
                }
                catch (EnterpriseException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Shop a = new Shop(Added, Removed, Added, Added);
            Console.WriteLine("Hello World!");
            Add(a);
            Remove(a);
        }
    }
}
