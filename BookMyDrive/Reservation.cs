using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookMyDrive
{
    internal class Reservation : Customer
    {
        public List<int> Services { get; set; }
        public decimal additionalServicePrice { get; set; }

        public string additionalServicesType { get; set; }

        public string carType { get; set; }

        public Reservation(string customerId, string customerName, string customerType, string phoneNumber, List<int> services, decimal additionalServicePrice, string carType, string additionalServicesType ) : base(customerId, customerName, phoneNumber, customerType)
        {

            this.Services = services;
            this.additionalServicePrice = additionalServicePrice;
            this.additionalServicesType = additionalServicesType;
            this.carType = carType;
        }

        //calculate basic total without additional service
        public decimal CalculateBasicCost()
        {
            decimal total = 0;
            
            foreach (int service in Services)
            {
                switch (service)
                {
                    case 1:
                        total += 29.99m;
                        break;
                    case 2:
                        total += 49.99m;
                        break;
                    case 3:
                        total += 79.99m;
                        break;
                }

            }
            return total;
        }

        //calculate total cost with additional service
        public decimal calculateTotalCost()
        {
            decimal basicCost = CalculateBasicCost();
            basicCost = basicCost + additionalServicePrice;
            return basicCost;
        }
    }
}
