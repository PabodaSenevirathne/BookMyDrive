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

            Console.WriteLine("List of all appointments:");

            foreach (Reservation reservation in reservations)
            {
                Console.WriteLine($"Customer ID: {new string('X', 3) + reservation.cutomerId.Substring(3)}"); 
                Console.WriteLine($"Name: {reservation.customerName}");
                Console.WriteLine($"Phone Number: {reservation.phoneNumber}");
                Console.WriteLine($"Phone Number: {reservation.customerType}");
                Console.WriteLine($"CarType: {reservation.carType}");
                Console.WriteLine($"Additional Service: {reservation.additionalServicesType}");
                Console.WriteLine($"Total: ${reservation.calculateTotalCost():F2}\n");

            }
        }

        public static void CreateReservation()
        {
            Console.Write("Customer Id: ");
            string customerId = Console.ReadLine();

            if (!Customer.IsValidCustomerID(customerId))
            {
                Console.WriteLine("Invalid customer ID format. It should be a 6-digit alphanumeric code.");
                return;
            }

            Console.Write("Name: ");
            string customerName = Console.ReadLine();

            //Console.Write("Phone Number: ");
            //string phoneNumber = Console.ReadLine();

            Console.Write("Phone Number (xxx-xxx-xxxx): ");
            string phoneNumber = Console.ReadLine();
            if (!Customer.IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid phone number format. It should be in the format 'xxx-xxx-xxxx'.");
                return;
            }

            Console.WriteLine("Customer Types:");
            Console.WriteLine("Customer Type (0 - Regular, 1 - Premium, 2 - VIP):");
            string customerType = Console.ReadLine();

            Customer customer = new Customer(customerId, customerName, phoneNumber, customerType);

            Console.WriteLine("Car Types:");
            Console.WriteLine("1 - Economy Car Rental - $29.99/day");
            Console.WriteLine("2 - Standard Car Rental - $49.99/day");
            Console.WriteLine("3 - Luxury Car Rental - $79.99/day");
            Console.Write("Choose a car type (1/2/3): ");

            int service = int.Parse(Console.ReadLine());
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

            Console.WriteLine(carType);

            List<int> services = new List<int>();
            services.Add(service);
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
            string additionalServices = Console.ReadLine().ToLower();

            if (additionalServices == "no")
            {
                additionalServices = "None";

            }

            Reservation reservation = new Reservation(customerId, customerName, customerType, phoneNumber, services, additionalServicePrice, carType, additionalServicesType);
            reservations.Add(reservation);

            Console.WriteLine("Appointment created successfully!");

        }

        public static void ResetReservation()
        {
            reservations.Clear();
            Console.WriteLine("Reservation reset successfully!");
        }
    }
}
