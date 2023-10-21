using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookMyDrive
{
    internal class Schedule
    {
        private static readonly List<Reservation> reservations = new List<Reservation>();

        public static void listAllReservations()
        {
            //hardcoded customers
            List<Customer> customers = new List<Customer>
             {
             new Customer("AB8123", "Paboda Senevirathne", "123-456-7890", "2"),
             new Customer("XY8456", "Alice Smith", "987-654-3210", "2"),
             new Customer("D88789", "Bob Johnson", "555-123-4567", "0")
              };

            // Adding the hardcoded customers to the first 3 slots of the reservation list
            if (reservations.Count == 0)
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    var customer = customers[i];
                    reservations.Add(new Reservation(customer.cutomerId, customer.customerName, customer.customerType, customer.phoneNumber, new List<int> { 1, 2 }, 29.99m, "Economy", "None"));
                }
            }
            

            //list all reservations
            Console.WriteLine("List of all appointments:");
            foreach (Reservation reservation in reservations)
            {
                Console.WriteLine($"Customer ID: {new string('X', 3) + reservation.cutomerId.Substring(3)}"); 
                Console.WriteLine($"Name: {reservation.customerName}");
                Console.WriteLine($"Phone Number: {reservation.phoneNumber}");
                Console.WriteLine($"Customer type: {reservation.customerType}");
                Console.WriteLine($"CarType: {reservation.carType}");
                Console.WriteLine($"Additional Service: {reservation.additionalServicesType}");
                Console.WriteLine($"Total: ${reservation.calculateTotalCost():F2}\n");
            }
        }

        //create reservations
        public static void CreateReservation()
        {
            //get customer Id
            Console.Write("Customer Id: ");
            string customerId = Console.ReadLine() ?? "default";

            if (!Customer.IsValidCustomerID(customerId))
            {
                Console.WriteLine("Invalid customer ID format. It should be a 6-digit alphanumeric code.");
                return;
            }

            //get customer Name
            Console.Write("Name: ");
            string customerName = Console.ReadLine() ?? "default";

            //get phone number
            Console.Write("Phone Number (XXX) XXX-XXXX: ");
            string phoneNumber = Console.ReadLine() ?? "default";
            //validate phone number
            if (!Customer.IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid phone number format. It should be in the format '(XXX) XXX-XXXX'.");
                return;
            }

            //get customer type
            Console.WriteLine("Customer Types:");
            Console.WriteLine("Customer Type (0 - Regular, 1 - Premium, 2 - VIP):");
            string customerType = Console.ReadLine() ?? "default";

            //get car type
            Console.WriteLine("Car Types:");
            Console.WriteLine("1 - Economy Car Rental - $29.99/day");
            Console.WriteLine("2 - Standard Car Rental - $49.99/day");
            Console.WriteLine("3 - Luxury Car Rental - $79.99/day");
            Console.Write("Choose the number corresponding to the car type (1/2/3): ");

            int service = int.Parse(Console.ReadLine() ?? "default");
            string carType;

            switch (service)
            {
                case 1:
                    carType = "Economy";
                    break;
                case 2:
                    
                    carType = "Standard";
                 
                    break;
                case 3:
                    carType = "Luxury";
                   
                    break;
                default:
                    carType = "Invalid";
                    break;
            }

            List<int> services = new List<int>();
            services.Add(service);

            //get additional services
            Console.WriteLine("Additinal Services:");

            decimal additionalServicePrice = 0;
            string additionalServicesType;
            switch (customerType)
            {
                case "0":
                    Console.WriteLine("Regular - GPS Navigation - $9.99/day");
                    additionalServicesType = "GPS Navigation";
                    additionalServicePrice = 9.99m;
                    break;
                case "1":
                    Console.WriteLine("Premium - Child Car Seat - $14.99/day");
                    additionalServicesType = "Child Car Seat";
                    additionalServicePrice = 14.99m;
                    break;
                case "2":
                    Console.WriteLine("VIP - Chauffeur Service - $99.99/day");
                    additionalServicesType = "Chauffeur Service";
                    additionalServicePrice = 99.99m;
                    break;
                default:
                    additionalServicesType = "Invalid";
                    break;
            }

            Console.Write("Do you want this additional service? (Yes/No): ");
            string additionalServices = Console.ReadLine()?.ToLower() ?? "default";
            if (additionalServices == "no")
            {
                additionalServicesType = "None";
                additionalServicePrice = 0;
            }

            //add user inputs to the Reservation list
            Reservation reservation = new Reservation(customerId, customerName, customerType, phoneNumber, services, additionalServicePrice, carType, additionalServicesType);
            reservations.Add(reservation);

            Console.WriteLine("Thank you! The reservation was successful.");
        }

        //reset reservation
        public static void ResetReservation()
        {
            reservations.Clear();
            Console.WriteLine("Reservation reset successfully!");
        }
    }
}
