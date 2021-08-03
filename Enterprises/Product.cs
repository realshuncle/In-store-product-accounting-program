using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    public class Product
    {
        private static void IsDate(string str)
        {
            System.Globalization.CultureInfo ruRU = new("ru-RU");
            DateTime.ParseExact(str, "d", ruRU);
        }
        public Product(string name, int amount, string shelfLife)
        {
            IsDate(shelfLife);
            Name = name;
            Amount = amount;
            ShelfLife = shelfLife;
        }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string ShelfLife { get; private set; }

    }
}
