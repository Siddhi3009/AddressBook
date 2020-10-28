namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class AddressBookBinder
    {
        //Address books store with address book name as key
        public Dictionary<string, List<Contact>> Binder = new Dictionary<string, List<Contact>>();
        //Dictionary of contacts seggregated citywise
        public Dictionary<string, List<Contact>> CityDictionary = new Dictionary<string, List<Contact>>();
        /// <summary>
        /// Add address book to dictionary or updates existing one if already added
        /// </summary>
        /// <param name="key"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public List<Contact> AddAddrBook(string key, List<Contact> set)
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
        /// <summary>
        /// Creates List of different cities whose contact exists
        /// </summary>
        /// <returns>List of different cities in address books</returns>
        public List<string> DistinctCities()
        {
            List<string> city = new List<string>();
            foreach (var key in Binder.Keys)
            {
                foreach (Contact c in Binder[key])
                {
                    if (city.Contains(c.City))
                        continue;
                    else
                        city.Add(c.City);
                }
            }
            return city;
        }
        /// <summary>
        ///  Creates Dictionary with city as a key
        /// </summary>
        public void CreateCityDictionary()
        {
            List<string> City = DistinctCities();
            foreach (string city in City)
            {        
                List<Contact> CityContact = new List<Contact>();
                foreach (var key in Binder.Keys)
                {
                    foreach (Contact c in Binder[key])
                    {
                        if (c.City == city)
                            CityContact.Add(c);
                    }
                }
                if (this.CityDictionary.ContainsKey(city))
                    CityDictionary[city] = CityContact;
                else
                    CityDictionary.Add(city, CityContact);
            }
        }
    }
}
