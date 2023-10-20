using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookMyDrive
{
    internal class Customer: ICustomer
    {
        public string cutomerId { get; set; }
        public string customerName { get; set; }
        public string phoneNumber { get; set; }

        public string customerType { get; set; }

        public Customer(string customerId, string customerName, string phoneNumber,string customerType ) {
            this.cutomerId = customerId;
            this.customerName = customerName;
            this.phoneNumber = phoneNumber;
            this.customerType = customerType;
           
        
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            //(XXX) XXX-XXXX 
            if (phoneNumber.Length != 14)
            {
                return false;
            }

            if (phoneNumber[0] != '(' || phoneNumber[4] != ')' || phoneNumber[5] != ' ' || phoneNumber[9] != '-')
            {
                return false;
            }

            for (int i = 1; i < 4; i++)
            {
                if (!Char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }

            for (int i = 6; i < 9; i++)
            {
                if (!Char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }

            for (int i = 10; i < 14; i++)
            {
                if (!Char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }


        public static bool IsValidCustomerID(string customerId)
        {
            if (string.IsNullOrEmpty(customerId) || customerId.Length != 6)
            {
                return false;
            }

            // Use a regular expression to validate alphanumeric code
            return Regex.IsMatch(customerId, "^[a-zA-Z0-9]*$");
        }

    }
}
