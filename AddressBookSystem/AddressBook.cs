namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
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
        /// Adds a contact to the address book
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="ZipCode"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <returns>true: contact added successfully, false: contact already exists</returns>
        public bool AddContact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            Contact contact = new Contact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email);
            Contact result = FindContact(FirstName);
            if (result == null)
            {
                People.Add(contact);
                return true;
            }
            else
                return false;
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
