using System;

namespace ConsoleApp8
{
    internal class Program
    {
        private static void displayMainMenu()
        {
            Console.WriteLine("\n============================================================");
            Console.WriteLine("Welcome to the Community Library Movie DVD Management System");
            Console.WriteLine("============================================================");
            Console.WriteLine("\n====================Main Menu====================\n");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("\nEnter your choice ==> (1/2/0)");
        }

        private static void displayStaffMenu()
        {
            Console.WriteLine("\n====================Staff Menu====================\n");
            Console.WriteLine("1. Add new DVDs of a new movie to the system");
            Console.WriteLine("2. Remove DVDs of a movie from the system");
            Console.WriteLine("3. Register a new member with the system");
            Console.WriteLine("4. Remove a registered member from the system");
            Console.WriteLine("5. Display a member's contact phone number, given the member's name");
            Console.WriteLine("6. Dsiplay all members who are currently renting a particular movie");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("\n\nEnter your choice ==> (1/2/3/4/5/6/0)");
        }

        private static void displayMemberMenu()
        {
            Console.WriteLine("\n====================Member Menu====================\n");
            Console.WriteLine("1. Browse all the movies");
            Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
            Console.WriteLine("3. Borrow a movie DVD");
            Console.WriteLine("4. Return a movie DVD");
            Console.WriteLine("5. List current borrowing movies");
            Console.WriteLine("6. Display the top 3 movies rented by the members");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("\n\nEnter your choice ==> (1/2/3/4/5/6/0)");
        }

        private static void processStaffMenu()
        {
            string staffID;
            string staffPassword;

            Console.Clear();
            Console.WriteLine("\n====================Staff Login ====================\n");
            Console.WriteLine("Please enter your username: ");
            staffID = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Please enter your password: ");
            staffPassword = Convert.ToString(Console.ReadLine());

            while (true)
            {
                if (staffID == "staff" && staffPassword == "today123")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect login credentials");
                    Console.WriteLine("Enter any key to try again OR Enter 0 to return to main menu");
                    string select = Console.ReadLine();
                    if (select == "0")
                    {
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n====================Staff Login ====================\n");
                        Console.WriteLine("Please enter your username: ");
                        staffID = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Please enter your password: ");
                        staffPassword = Convert.ToString(Console.ReadLine());
                    }
                }
            }

            Console.Clear();
            displayStaffMenu();
            string option = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            displayMainMenu();
            string select;
            select = Console.ReadLine();
            while (select != "0")
            {
                if (select == "1")
                {
                    processStaffMenu();
                }
                else if (select == "2")
                {
                    displayMemberMenu();
                    break;
                }
                else
                {
                    // show error
                    Console.WriteLine("Invalid Choice! Please try again!");
                }
                Console.WriteLine();
                displayMainMenu();
                select = Console.ReadLine();
            }
        }
    }
}
