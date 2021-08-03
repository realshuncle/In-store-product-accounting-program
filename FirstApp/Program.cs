using System;
using Enterprises;

namespace FirstApp
{
    class Program
    {
        static void Added(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{sender}: {e.Message}");
            Console.ResetColor();
        }
        static void Removed(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{sender}: {e.Message}");
            Console.ResetColor();
        }
        static void Showed(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{sender}: {e.Message}");
            Console.ResetColor();
        }
        static void Groeed(object sender, EnterpriseEventsArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{sender}: {e.Message}");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("1 or add - to add product");
                        Console.WriteLine("2 or remove - to remove product");
                        Console.WriteLine("3 or show - to show products");
                        Console.WriteLine("4 or groe - to get rid of expired");
                        Console.WriteLine("5 or help - to fet list of command");
                        Console.WriteLine("6 or quit - to quit from program");
                        Console.ResetColor();
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
