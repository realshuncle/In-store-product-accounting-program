using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    class EnterpriseException : Exception
    {
        public EnterpriseException(string message) : base(message)
        {

        }
    }
    class Shop : IEnterprise
    {
        public Shop(EnterpriseHandler added, EnterpriseHandler Removed, EnterpriseHandler Showed, EnterpriseHandler GROE)
        {
            Added += added;
        }

        private List<Product> Products;

        event EnterpriseHandler IEnterpri;

        protected internal event EnterpriseHandler Added;

        protected internal event EnterpriseHandler Removed;

        protected internal event EnterpriseHandler Showed;

        protected internal event EnterpriseHandler GROE;

        public event EnterpriseHandler Notify;

        public void AddProduct(Product product)
        {
            EnterpriseEventsArgs e = new EnterpriseEventsArgs($"Added product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife}.", product);
            int index = Products.FindIndex(prod => prod.Name == product.Name && prod.ShelfLife == product.ShelfLife);
            if (index != -1)
                Products[index].Amount += product.Amount;
            else
                Products.Add(product);
            CallEvent(e, Added);
        }
        public void RemoveProduct(Product product)
        {
            int index = Products.FindIndex(prod => prod.Name == product.Name && prod.ShelfLife == product.ShelfLife);
            if (index != -1)
            {
                EnterpriseEventsArgs e = new EnterpriseEventsArgs($"Removed product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife}.", product);
                Products.RemoveAt(index);
                //CallEvent(e, Removed);
            }
            else
            {
                EnterpriseEventsArgs e = new EnterpriseEventsArgs($"Product {product.Name}, amount: {product.Amount}, implementation period: {product.ShelfLife} was not found.", product);
                //CallEvent(e, Removed);
                //throw new EnterpriseException("This product was not found.");
            }
            CallEvent(e, Removed);
        }
        public void GetRidOfExpired()
        {
            foreach (Product i in Products)
            {
                DateTime parsedDate;
                CultureInfo ruRU = new CultureInfo("ru-RU");
                if (DateTime.Today.CompareTo(DateTime.TryParseExact(i.ShelfLife, "d", ruRU, DateTimeStyles.None, out parsedDate)) < 0)
                {
                    EnterpriseEventsArgs e = new EnterpriseEventsArgs($"Removed product {i.Name}, amount: {i.Amount}, implementation period: {i.ShelfLife}.", i);
                    Products.Remove(i);
                    CallEvent(e, GROE);
                }        
            }    
        }
        private void CallEvent(EnterpriseEventsArgs e, EnterpriseHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }
        public void Show(string str)
        {
            foreach (Product i in Products)
            {
                if (i.Name.Contains(str) || i.ShelfLife.Contains(str))
                {
                    EnterpriseEventsArgs e = new EnterpriseEventsArgs($"Removed product {i.Name}, amount: {i.Amount}, implementation period: {i.ShelfLife}.", i);
                    CallEvent(e, GROE);
                }
            }
        }
    }
}
