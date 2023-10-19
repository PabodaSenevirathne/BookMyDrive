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
                Console.WriteLine($"Name: {reservation.cutomerId}");
                Console.WriteLine($"Name: {reservation.customerName}");
                Console.WriteLine($"Phone Number: {reservation.phoneNumber}");
                Console.WriteLine($"Total: ${reservation.calculateTotalCost():F2}\n");

            }
        }

        public static void CreateReservation()
        {
            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

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
            List<int> services = new List<int>();
            services.Add(service);
            Console.WriteLine("Additinal Services:");


            Console.Write("Do you want this additional service? (Yes/No): ");
            string additionalServices = Console.ReadLine().ToLower();
            string additionalServicesType;


           // List<decimal> additionalServicePrice = new List<decimal>();
            decimal additionalServicePrice = 0;
            if (additionalServices == "yes")
            {

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
                }

                ///additionalServicePrice.Add(additionalPrice);
                //Console.WriteLine($"{additionalPrice}add price");
                //Console.WriteLine(additionalServicePrice.Count);
            }
            else if (additionalServices == "no")
            {
                additionalServices = "None";

            }


            Reservation reservation = new Reservation(customerId, customerName, customerType, phoneNumber, services, additionalServicePrice);
            reservations.Add(reservation);

            Console.WriteLine("Appointment created successfully!");

            //decimal additionalPrice = 0;
            //if (customerType == "0")
            //{
            //    Console.WriteLine("Regular - GPS Navigation - $9.99/day");
            //    additionalPrice = 9.99m;

            //}
            //else if (customerType == "1")
            //{
            //    Console.WriteLine("Premium - Child Car Seat - $14.99/day");
            //    additionalPrice = 14.99m;
            //}
            //else
            //{
            //    Console.WriteLine("VIP - Chauffeur Service - $99.99/day");
            //    additionalPrice = 99.99m;
            //}

            //Console.WriteLine("Do you need additional services(Yes/No)?");

            //List<decimal> additionalServicePrice = new List<decimal>();
            //string additionalServices = Console.ReadLine();

            //if (additionalServices == "yes")
            //{
            //    additionalServicePrice.Add(additionalPrice);
            //    Console.WriteLine($"{additionalPrice}add price");
            //}







            //while (true)
            //{

            //    Console.Write("Service (Regular/ Premium/ VIP): ");
            //    int service = int.Parse(Console.ReadLine());

            //    if (service == 0)
            //    {
            //        break;
            //    }

            //    services.Add(service);
            //}

        }

        public static void ResetReservation()
        {
            reservations.Clear();
            Console.WriteLine("Reservation reset successfully!");
        }
    }
}
