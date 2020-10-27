namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    //Contact modal class
    public class Contact 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //Constructor
        public Contact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }
        //override ToString method to return Contact details in a single line
        public override string ToString()
        {
            return FirstName + "\t" + LastName + "\t" + Address + "\t" + City + "\t" + State + "\t" + ZipCode + "\t" + PhoneNumber + "\t" + Email;
        }
    }
}
