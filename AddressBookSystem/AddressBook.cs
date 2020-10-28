namespace AddressBookSystem
{
    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    class AddressBook
    {
        //AddressBook: List of contacts on which operations will be performed
        public List<Contact> People;
        /// <summary>
        /// Constructor for initializing new Address book
        /// </summary>
        public AddressBook()
        {
            People = new List<Contact>();
        }
        /// <summary>
        /// Finding a contact with its first name
        /// </summary>
        /// <param name="fname"></param>
        /// <returns>Contact with same firstname if found, null if no contact found</returns>
        public Contact FindContact(string fname)
        {
            Contact contact = null;
            foreach (var person in People)
            {
                if (person.FirstName.Equals(fname))
                {
                    contact = person;
                    break;
                }
            }
            return contact;
        }
        /// <summary>
        /// Adds a valid contact to the address book
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="ZipCode"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        public void AddContact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            RegexValidation validate = new RegexValidation();
            if (validate.Validate(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email))
            {
                Contact contact = new Contact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email);
                Contact result = FindContact(FirstName);
                if (result == null)
                {
                    People.Add(contact);
                    Console.WriteLine("Contact added successfully");
                }
                else
                {
                    Console.WriteLine("Contact already exists");
                }
            }
            else
            {
                Console.WriteLine("Enter a valid contact");
            }
        }
        /// <summary>
        /// Edits already existing contact based on first name
        /// </summary>
        /// <param name="firstName"></param>
        public void EditContact(string firstName)
        {
            Contact contactToBeEdited = FindContact(firstName);
            Contact contact = new Contact();
            RegexValidation validate = new RegexValidation();
            if (contactToBeEdited == null)
            {
                Console.WriteLine("Address for {0} could not be found.", firstName);
            }
            else
            {
                Console.WriteLine("New First Name");
                contact.FirstName = Console.ReadLine();
                Console.WriteLine("New Last Name");
                contact.LastName = Console.ReadLine();
                Console.WriteLine("New Address");
                contact.Address = Console.ReadLine();
                Console.WriteLine("New City");
                contact.City = Console.ReadLine();
                Console.WriteLine("New State");
                contact.State = Console.ReadLine();
                Console.WriteLine("New Zip code");
                contact.ZipCode = Console.ReadLine();
                Console.WriteLine("New Phone Number");
                contact.PhoneNumber = Console.ReadLine();
                Console.WriteLine("New Email");
                contact.Email = Console.ReadLine();
                if (validate.Validate(contact.FirstName, contact.LastName, contact.Address, contact.City, contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email))
                {
                    People.Remove(contactToBeEdited);
                    People.Add(contact);
                    Console.WriteLine("Details updated for " + firstName);
                }
                else
                {
                    Console.WriteLine("Enter valid details");
                }
            }
        }
        /// <summary>
        /// Removes a contact from the address book
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if contact is removed, false if contact cannot be removed</returns>
        public bool RemoveContact(string name)
        {
            Contact c = FindContact(name);

            if (c != null)
            {
                People.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  Arranges the contacts in an address book alphabetically
        /// </summary>
        public void AlphabeticallyArrange()
        {
            List<string> alphabeticalList = new List<string>();
            foreach (Contact c in People)
            {
                string sort = c.ToString();
                alphabeticalList.Add(sort);
            }
            alphabeticalList.Sort();
            foreach (string s in alphabeticalList)
            {
                Console.WriteLine(s);
            }
        }
        /// <summary>
        /// Arranges the contacts in the address book according to the pincode
        /// </summary>
        public void SortByPincode()
        {
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }
        }
        /// <summary>
        /// Arranges the contacts in the address book according to the city name
        /// </summary>
        public void SortByCity()
        {
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }
        }
        /// <summary>
        /// Arranges the contacts in the address book according to the state name
        /// </summary>
        public void SortByState()
        {
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.State, y.State)));
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }
        }
    }
}
