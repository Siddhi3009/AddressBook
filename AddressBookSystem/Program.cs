using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace AddressBookSystem
{
    class Program
    {
        public static List<string> data = new List<string>();
        public static List<Contact> data1 = new List<Contact>();
        static void Main(string[] args)
        {
            AddressBookBinder binder = new AddressBookBinder();
            Console.WriteLine("Welcome to Address Book Program");
            int result = 1;
            while (result == 1)
            {
                Console.WriteLine("Enter the name of the Address Book to be used");
                string addrName = Console.ReadLine();
                AddressBook book = new AddressBook();
                book.People = binder.AddAddrBook(addrName, book.People);
                int loop = 1;
                while (loop == 1)
                {
                    Console.WriteLine("\nSelect the option. \n1. Add new contact. \n2. Edit existing contact.\n3. Delete Contact \n4. Search By City \n5. Count citywise contacts \n6. Display Alphabetically \n7. Sort By Zipcode \n8. Sort By City \n9. Sort By State \n10. Exit.");
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
                            if (book.AddContact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email))
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
                            Contact c = book.FindContact(name);
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
                            Console.WriteLine("Enter the first name of the contact to be deleted ");
                            string name1 = Console.ReadLine();
                            if (book.RemoveContact(name1))
                            {
                                Console.WriteLine("Contact removed successfully");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Contact not found");
                                break;
                            }
                        case 4:
                            binder.CreateDictionary();
                            Console.WriteLine("Enter city whose contacts need to be searched");
                            string city = Console.ReadLine();
                            foreach (Contact contact in binder.CityDictionary[city])
                            {
                                Console.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.State + "\t" + contact.ZipCode + "\t" + contact.PhoneNumber + "\t" + contact.Email);
                            }
                            break;
                        case 5:
                            binder.CreateDictionary();
                            foreach (var key in binder.CityDictionary.Keys)
                            {
                                Console.WriteLine(key + "\t" + binder.CityDictionary[key].Count);
                            }
                            break;
                        case 6:
                            book.AlphabeticallyArrange();
                            break;
                        case 7:
                            book.SortByPincode();
                            break;
                        case 8:
                            book.SortByCity();
                            break;
                        case 9:
                            book.SortByState();
                            break;
                        case 10:
                            loop = 0;
                            break;
                    }
                    binder.Binder[addrName] = (book.People);
                }
                Console.WriteLine("Do you want to enter an address book. \n1. yes \n2. no");
                result = int.Parse(Console.ReadLine());
            }
            foreach (var key in binder.Binder.Keys)
            {
                data.Add(key);
                foreach (Contact c in binder.Binder[key])
                {
                    data.Add(c.ToString());
                }
            }
            Console.WriteLine("Writing contacts in file");
            WriteUsingStreamWriter();
            ReadFromStreamReader();

            //CSV READ WRITE 
            foreach (var key in binder.Binder.Keys)
            {
                foreach (Contact c in binder.Binder[key])
                {
                    data1.Add(c);
                }
            }
            CSVReadWrite.WriteCSVFile(@"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Contact.csv", data1);
            var path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Contact.csv";
            var resultData = CSVReadWrite.ReadCSVFile(path);
        }
        //FileIO Operations
        public static void ReadFromStreamReader()
        {
            string path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String fileData = "";
                    while ((fileData = sr.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
        public static void WriteUsingStreamWriter()
        {
            string path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (string contact in data)
                    {
                        streamWriter.WriteLine(contact);
                    }
                    streamWriter.Close();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
      
    }
}

