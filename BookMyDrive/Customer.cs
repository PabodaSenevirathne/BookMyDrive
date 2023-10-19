using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyDrive
{
    internal class Customer: ICustomer
    {
        public int cutomerId { get; set; }
        public string customerName { get; set; }
        public string phoneNumber { get; set; }

        public string customerType { get; set; }

        public Customer(int customerId, string customerName, string phoneNumber,string customerType ) {
            this.cutomerId = customerId;
            this.customerName = customerName;
            this.phoneNumber = phoneNumber;
            this.customerType = customerType;
            


        
        }

    }
}
