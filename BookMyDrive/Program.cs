namespace BookMyDrive
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
        //Program program = new Program();
        //    List<Customer> customers = new List<Customer>
        //{
        //    new Customer(1, "John Doe", "123-456-7890", "Premium"),
        //    new Customer(2, "Alice Smith", "987-654-3210", "VIP"),
        //    new Customer(2, "Bob Johnson", "555-123-4567", "Regular")
        //};

            while (true)
            {

                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. List all Reservation");
                Console.WriteLine("2. Create an Reservation");
                Console.WriteLine("3. Clear all Reservations");
                Console.WriteLine("4. Exit");

                int option;

                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
                {
                    Console.Write("Invalid input! Please enter a number between 1 and 4: ");
                }

                switch (option)
                {
                    case 1:
                        Schedule.listAllReservations();
                        break;

                    case 2:
                        Schedule.CreateReservation();
                        break;

                    case 3:
                        Schedule.ResetReservation();
                        break;

                    case 4:
                        return;
                }
            }
        }
    }
}