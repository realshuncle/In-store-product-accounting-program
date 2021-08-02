using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    public class Product
    {
        private void isDate(string str)
        {
            System.Globalization.CultureInfo ruRU = new("ru-RU");
            DateTime.ParseExact(str, "d", ruRU);
        }
        public Product(int amount, string shelfLife)
        {
            isDate(shelfLife);
            Amount = amount;
            ShelfLife = shelfLife;
        }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string ShelfLife { get; private set; }

    }
}
