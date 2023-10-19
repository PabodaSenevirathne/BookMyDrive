using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyDrive
{
    internal class Reservation: Customer
    {
        public List<int> Services { get; set; }
        public Reservation(int customerId, string customerName, string phoneNumber, List<int> services) : base( customerId, customerName, phoneNumber)  {

            this.Services = services;
        
        }

        public decimal CalculateBasicCost() {
            decimal total = 0;
            foreach (int service in Services)
            {
                switch (service)
                {
                    case 1 :
                        total += 29.99m;
                        break;
                    case 2 :
                        total += 49.99m;
                        break;
                    case 3:
                        total += 79.99m;
                        break;
                }
                
            }
            return total;

        }

    }
}
