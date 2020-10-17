using System;

namespace AddressBookSystem
{
    class Program
    {
        AddressBook book;
        public Program()
        {
            book = new AddressBook();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Welcome to Address Book Program");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Select the option. \n1. Add new contact. \n2. Edit existing contact. \n3. Exit.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the person details to be added in the address book");
                        Console.WriteLine("First Name");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Last Name");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("Address");
                        string Address = Console.ReadLine();
                        Console.WriteLine("City");
                        string City = Console.ReadLine();
                        Console.WriteLine("State");
                        string State = Console.ReadLine();
                        Console.WriteLine("Zip code");
                        string ZipCode = Console.ReadLine();
                        Console.WriteLine("Phone Number");
                        string PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Email");
                        string Email = Console.ReadLine();
                        if (p.book.AddContact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email))
                        {
                            Console.WriteLine("Contact added successfully");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Contact already exists");
                            break;
                        }
                    case 2:
                        Console.WriteLine("Enter the first name of the contact to be edited ");
                        string name = Console.ReadLine();
                        Contact c = p.book.FindContact(name);
                        if (c == null)
                        {
                            Console.WriteLine("Address for {0} count not be found.", name);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("New Last Name");
                            c.LastName = Console.ReadLine();
                            Console.WriteLine("New Address");
                            c.Address = Console.ReadLine();
                            Console.WriteLine("New City");
                            c.City = Console.ReadLine();
                            Console.WriteLine("New State");
                            c.State = Console.ReadLine();
                            Console.WriteLine("New Zip code");
                            c.ZipCode = Console.ReadLine();
                            Console.WriteLine("New Phone Number");
                            c.PhoneNumber = Console.ReadLine();
                            Console.WriteLine("New Email");
                            c.Email = Console.ReadLine();
                            Console.WriteLine("Details updated for " + name);
                            break;
                        }
                    case 3:
                        loop = false;
                        break;
                }
            }
        }
    }
}
