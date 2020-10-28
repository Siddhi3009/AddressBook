namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Contact modal class
    /// </summary>
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
        /// <summary>
        /// Contact class for storing contact details using parameterised constructor
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="ZipCode"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
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
        /// <summary>
        ///override ToString method to return Contact details in a single line
        /// </summary>
        /// <returns> A string of all the contact details</returns>
        public override string ToString()
        {
            return FirstName + "\t" + LastName + "\t" + Address + "\t" + City + "\t" + State + "\t" + ZipCode + "\t" + PhoneNumber + "\t" + Email;
        }
    }
}
