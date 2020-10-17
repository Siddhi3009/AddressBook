using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookBinder
    {
        public Dictionary<string, List<Contact>> Binder = new Dictionary<string, List<Contact>>();
        public List<Contact> AddAddrBook(string key, List<Contact> list)
        {
            if (this.Binder.ContainsKey(key))
            {
                Console.WriteLine("Address book already exists");
                return Binder[key];
            }
            else
            {
                Console.WriteLine("New address book created");
                Binder.Add(key, list);
                return Binder[key];
            }
        }
    }
}
