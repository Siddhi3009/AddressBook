using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookBinder
    {
        public Dictionary<string, HashSet<Contact>> Binder = new Dictionary<string, HashSet<Contact>>();
        public HashSet<Contact> AddAddrBook(string key, HashSet<Contact> set)
        {
            if (this.Binder.ContainsKey(key))
            {
                Console.WriteLine("Address book already exists");
                return Binder[key];
            }
            else
            {
                Console.WriteLine("New address book created");
                Binder.Add(key, set);
                return Binder[key];
            }
        }
    }
}
