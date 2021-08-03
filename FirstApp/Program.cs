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
            Console.ForegroundColor = ConsoleColor.DarkGreen; // устанавливаем цвет
            Console.WriteLine($"{sender.ToString()}: {e.Message}");
            Console.ResetColor();
        }
        static void Showed(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // устанавливаем цвет
            Console.WriteLine($"{sender.ToString()}: {e.Message}");
            Console.ResetColor();
        }
        static void Groeed(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen; // устанавливаем цвет
            Console.WriteLine($"{sender.ToString()}: {e.Message}");
            Console.ResetColor();
        }
        static void GROE(Shop shop)
        {
            shop.GetRidOfExpired();
        }
        static void Show(Shop shop, string str = "")
        {
            shop.Show(str);
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
            Shop a = new (Added, Removed, Showed, Groeed);
            Console.WriteLine("Program \"Shop\".");
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("Enter the command. Enter help for a list of commands.");
                string command;
                command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                    case "1": 
                        Add(a);
                        break;
                    case "remove":
                    case "2":
                        Remove(a);
                        break;
                    case "show":
                    case "3":
                        string sear;
                        Console.WriteLine("Enter a search word or leave the line blank and press enter.");
                        sear = Console.ReadLine();
                        Show(a, sear);
                        break;
                    case "groe":
                    case "4":
                        GROE(a);
                        break;
                    case "help":
                    case "5":
                        Console.WriteLine("1 or add - to add product, 2 or remove - to remove product, " +
                            "3 or show - to show products, 4 or groe - to get rid of expired, 5 or help - to fet list of command," +
                            "6 or quit - to quit from program");
                        break;
                    case "quit":
                    case "6":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
