using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookBinder
    {
        public Dictionary<string, HashSet<Contact>> Binder = new Dictionary<string, HashSet<Contact>>();
        public List<Contact> City = new List<Contact>();
        public Dictionary<string, List<Contact>> CityDictionary = new Dictionary<string, List<Contact>>();
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
        public List<Contact> SortByCity(string cityname)
        {
            foreach (var key in Binder.Keys)
            {
                foreach (Contact c in Binder[key])
                {
                    if (c.City == cityname)
                        City.Add(c);
                }
            }
            return City;
        }
        public List<Contact> SearchContactsByCity(string city)
        {
            CityDictionary[city] = SortByCity(city);
            return CityDictionary[city];
        }
    }
}
