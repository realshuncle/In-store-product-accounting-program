using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    public class EnterpriseException : Exception
    {
        public EnterpriseException(string message) : base(message)
        {

        }
    }
    public class Shop : IEnterprise
    {
        public Shop(EnterpriseHandler added, EnterpriseHandler removed, EnterpriseHandler showed, EnterpriseHandler groe)
        {
            Added += added;
            Removed += removed;
            Showed += showed;
            GROE += groe;
            Products = new();
        }

        private readonly List<Product> Products;

        protected internal event EnterpriseHandler Added;

        protected internal event EnterpriseHandler Removed;

        protected internal event EnterpriseHandler Showed;

        protected internal event EnterpriseHandler GROE;

        public void AddProduct(Product product)
        {
            IEnterprise temp = this;
            EnterpriseEventsArgs e = new ($"Added product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife}.", product);
            int index = Products.FindIndex(prod => prod.Name == product.Name && prod.ShelfLife == product.ShelfLife);
            if (index != -1)
                Products[index].Amount += product.Amount;
            else
                Products.Add(product);
            temp.CallEvent(e, Added);
        }
        public void RemoveProduct(Product product)
        {
            IEnterprise temp = this;
            int index = Products.FindIndex(prod => prod.Name == product.Name && prod.ShelfLife == product.ShelfLife);
            EnterpriseEventsArgs e;
            if (index != -1)
                if (product.Amount >= Products[index].Amount)
                {
                    e = new($"Removed product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife}.", product);
                    Products.RemoveAt(index);
                }
                else
                {
                    e = new($"Removed product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife}. Remaining: {Products[index].Amount -= product.Amount}.", product);
                    Products[index].Amount -= product.Amount;
                }
            else
                e = new ($"Product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife} was not found.", product);
            temp.CallEvent(e, Removed);
        }
        public void GetRidOfExpired()
        {
            foreach (Product i in Products.ToList())
            {
                CultureInfo ruRU = new("ru-RU");
                DateTime.TryParseExact(i.ShelfLife, "d", ruRU, DateTimeStyles.None, out DateTime parsedDate);
                if (DateTime.Today.CompareTo(parsedDate) > 0)
                {
                    IEnterprise temp = this;
                    EnterpriseEventsArgs e = new ($"Removed product {i.Name}, amount: {i.Amount}, implementation period: {i.ShelfLife}.", i);
                    Products.Remove(i);
                    temp.CallEvent(e, GROE);
                }        
            }    
        }
        void IEnterprise.CallEvent(EnterpriseEventsArgs e, EnterpriseHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }
        public void Show(string str)
        {
            IEnterprise temp = this;
            foreach (Product i in Products)
                if (i.Name.Contains(str) || i.ShelfLife.Contains(str))
                {
                    EnterpriseEventsArgs e = new ($"Product {i.Name}, amount: {i.Amount}, implementation period: {i.ShelfLife}.", i);
                    temp.CallEvent(e, Showed);
                }
        }
    }
}
