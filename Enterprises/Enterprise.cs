﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprises
{
    interface IEnterprise
    {
        //protected internal event EnterpriseHandler Added;

        //protected internal event EnterpriseHandler Removed;

        //protected internal event EnterpriseHandler GROE;

        public event EnterpriseHandler Notify;
        private void CallEvent(EnterpriseEventsArgs e, EnterpriseHandler handler)
        {
        }        
        void AddProduct(Product product);
        void RemoveProduct(Product prosuct);
        void GetRidOfExpired();
        void Show(string str); 
    }
}
