﻿namespace AddressBookSystem
{
    using CsvHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    class Program
    {
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
                    Console.WriteLine("\nSelect the option. \n1. Add new contact. \n2. Edit existing contact.\n3. Delete Contact \n4. Search By City \n5. Count citywise contacts \n6. Display Alphabetically \n7. Sort By Zipcode \n8. Sort By City \n9. Sort By State \n10. Read the contacts from txt file \n11. Write the contacts in txt file \n12. Read the contacts from csv file \n13. Write the contacts in csv file \n14. Read the contacts from json file \n15. Write the contacts in json file \n16. Exit. ");
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
                            book.AddContact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email);
                            break;
                        case 2:
                            Console.WriteLine("Enter the first name of the contact to be edited ");
                            string name = Console.ReadLine();
                            book.EditContact(name);
                            break;
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
                            binder.CreateCityDictionary();
                            Console.WriteLine("Enter city whose contacts need to be searched");
                            string city = Console.ReadLine();
                            foreach (Contact contact in binder.CityDictionary[city])
                            {
                                Console.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.State + "\t" + contact.ZipCode + "\t" + contact.PhoneNumber + "\t" + contact.Email);
                            }
                            break;
                        case 5:
                            binder.CreateCityDictionary();
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
                            Console.WriteLine("Reading contacts from txt file");
                            ReadWrite.ReadFromStreamReader();
                            break;
                        case 11:
                            Console.WriteLine("Writing contacts in txt file");
                            ReadWrite.WriteUsingStreamWriter(book.People);
                            break;
                        case 12:
                            Console.WriteLine("Reading contacts from csv file");
                            ReadWrite.ReadCSVFile();
                            break;
                        case 13:
                            Console.WriteLine("Writing contacts in csv file");
                            ReadWrite.WriteCSVFile(book.People);
                            break;
                        case 14:
                            Console.WriteLine("Reading contacts from json file");
                            ReadWrite.ReadJsonFile();
                            break;
                        case 15:
                            Console.WriteLine("Writing contacts in json file");
                            ReadWrite.WriteToJsonFile(book.People);
                            break;
                        case 16:
                            loop = 0;
                            break;
                    }
                    binder.Binder[addrName] = (book.People);
                }
                Console.WriteLine("Do you want to enter an address book. \n1. yes \n2. no");
                result = int.Parse(Console.ReadLine());
            }
        }
    }
}

