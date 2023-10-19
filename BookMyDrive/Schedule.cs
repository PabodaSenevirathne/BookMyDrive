using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookMyDrive
{
    internal class Schedule
    {
        private static readonly List<Reservation> reservations = new List<Reservation>();

        public static void listAllReservations() {

            Console.WriteLine("List of all appointments:");

            foreach (Reservation reservation in reservations)
            {
                Console.WriteLine($"Name: {reservation.cutomerId}");
                Console.WriteLine($"Name: {reservation.customerName}");
                Console.WriteLine($"Phone Number: {reservation.phoneNumber}");
                Console.WriteLine($"Total: ${reservation.CalculateBasicCost():F2}\n");
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

            List<int> services = new List<int>();

            while (true)
            {
                Console.Write("Service (Regular/ Premium/ VIP): ");
                int service = int.Parse(Console.ReadLine());

                if (service == 0)
                {
                    break;
                }

                services.Add(service);
            }
           
            Reservation reservation = new Reservation( customerId, customerName, phoneNumber, services);
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
