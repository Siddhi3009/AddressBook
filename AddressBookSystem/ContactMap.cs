using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Map(x => x.FirstName).Name("FirstName");
            Map(x => x.LastName).Name("LastName");
            Map(x => x.Address).Name("Address");
            Map(x => x.City).Name("City");
            Map(x => x.State).Name("State");
            Map(x => x.ZipCode).Name("ZipCode");
            Map(x => x.PhoneNumber).Name("PhoneNumber");
            Map(x => x.Email).Name("Email");
        }
    }
}
