namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class AddressBook
    {
        //AddressBook: List of contacts on which operations will be performed
        public List<Contact> People;
        //Constructor for initializing new Address book
        public AddressBook()
        {
            People = new List<Contact>();
        }
        //Finding a contact with its first name
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
        //Adding a contact to the address book
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
        //Removing a contact from the address book
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
        //Arranging the contacts in an address book alphabetically
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
        //Arranging the contacts in the address book according to the pincode
        public void SortByPincode()
        {
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }
        }
        //Arranging the contacts in the address book according to the city name

        public void SortByCity()
        {
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }
        //Arranging the contacts in the address book according to the state name

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
