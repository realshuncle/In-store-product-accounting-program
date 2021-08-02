using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    class Product
    {
        public Product(int amount, string shelfLife)
        {
            Amount = amount;
            ShelfLife = shelfLife;
        }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string ShelfLife { get; private set; }

    }
}
