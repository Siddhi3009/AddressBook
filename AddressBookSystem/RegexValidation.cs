using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookSystem
{
    /// <summary>
    /// Validate Contact Information provided
    /// </summary>
    class RegexValidation
    {
        public static string REGEX = "^[A-Z][a-zA-Z]{2,}$";
        public static string REGEX_EMAIL = "^[a-zA-Z0-9]+([-.+_#$][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+[.][a-zA-Z]{2,3}([.][a-zA-Z]{2})?$";
        public static string REGEX_NUMBER = "^[1-9][0-9]\\s[1-9]{1}[0-9]{9}$";
        public static string REGEX_ZIPCODE = "^[1-9][0-9]{2}[\\s]?[0-9]{3}";
        /// <summary>
        /// Validates contact information of firstname, lastname, address, city, state, zipcode, email, phone number
        /// </summary>
        /// <param name="entry"></param>
        /// <returns>Validation Result true or false</returns>
        public bool Validate(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            bool result = true;
            if (!Regex.IsMatch(FirstName, REGEX))
            {
                Console.WriteLine("Enter a valid FirstName");
                result = false;
            }
            if (!Regex.IsMatch(LastName, REGEX))
            {
                Console.WriteLine("Enter a valid LastName");
                result = false;
            }
            if (!Regex.IsMatch(Address, REGEX))
            {
                Console.WriteLine("Enter a valid Address");
                result = false;
            }
            if (!Regex.IsMatch(City, REGEX))
            {
                Console.WriteLine("Enter a valid City");
                result = false;
            }
            if (!Regex.IsMatch(State, REGEX))
            {
                Console.WriteLine("Enter a valid state");
                result = false;
            }
            if (!Regex.IsMatch(ZipCode, REGEX_ZIPCODE))
            {
                Console.WriteLine("Enter a valid zipcode");
                result = false;
            }
            if (!Regex.IsMatch(PhoneNumber, REGEX_NUMBER))
            {
                Console.WriteLine("Enter a valid Number");
                result = false;
            }
            if (!Regex.IsMatch(Email, REGEX_EMAIL))
            {
                Console.WriteLine("Enter a valid email");
                result = false;
            }
            return result;
        }
    }
}
