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

        //public List<decimal> additionalServicePrice { get; set; }
        public Reservation(int customerId, string customerName, string phoneNumber, string customerType, List<int> services, decimal additionalServicePrice ) : base(customerId, customerName, phoneNumber, customerType)
        {

            this.Services = services;
            this.additionalServicePrice = additionalServicePrice;
        }

        //public decimal getAdditionalServicePrice()
        //{

        //    decimal atotal = 0;


        //    foreach (decimal Price in additionalServicePrice)
        //    {
        //        atotal += Price;
        //    }

        //    return atotal;
        //}



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

        public decimal calculateTotalCost()
        {

            decimal basicCost = CalculateBasicCost();
            //decimal additionalServiceCost = getAdditionalServicePrice();

            return basicCost + additionalServicePrice;
        }


    }
}
