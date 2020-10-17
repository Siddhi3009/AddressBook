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
            if (p.book.AddContact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email) == true)
            {
                Console.WriteLine("Contact added successfully");
            }
            else
            {
                Console.WriteLine("Contact already exists");
            }
        }
    }
}
