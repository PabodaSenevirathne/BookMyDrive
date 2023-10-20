using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyDrive
{
    internal interface ICustomer
    {
        string cutomerId { get; set; }
        string customerName { get; set; }
        string phoneNumber { get; set; }

        string customerType { get; set; }
    }
}
