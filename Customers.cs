using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace D202_assignment_1
{
    class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public Customer(string name)
        {
            CustomerName = name;
        }
    }
}
