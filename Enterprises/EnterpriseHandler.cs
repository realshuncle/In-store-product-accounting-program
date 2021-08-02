using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    public delegate void EnterpriseHandler(object sender, EnterpriseEventsArgs e);
    public class EnterpriseEventsArgs
    {
        public string Message { get; private set; }
        public Product Product { get; private set; }
        public EnterpriseEventsArgs(string _mes, Product _prod)
        {
            Message = _mes;
            Product = _prod;
        }
    }
}
