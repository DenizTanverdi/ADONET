using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDapper
{
    class Customer
    {
        private string customerId;

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private string companyName;

        public string CompanyName {
            get { return companyName; }
            set { companyName = value; } }


    }
}
