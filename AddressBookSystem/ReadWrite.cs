using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class ReadWrite
    {
        public static void ReadFromStreamReader()
        {
            string path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Utility\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String fileData = "";
                    while ((fileData = sr.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
        public static void WriteUsingStreamWriter(List<Contact> data)
        {
            string path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Utility\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (Contact contact in data)
                    {
                        streamWriter.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.State + "\t" + contact.ZipCode + "\t" + contact.PhoneNumber + "\t" + contact.Email);
                    }
                    streamWriter.Close();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
        public static void ImplementCSVDataHandling()
        {
            string filePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Utility\Contact.csv";
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Data Reading done successfully from Contact.csv file");
                foreach (Contact contact in records)
                {
                    Console.Write("\t" + contact.FirstName);
                    Console.Write("\t" + contact.LastName);
                    Console.Write("\t" + contact.Address);
                    Console.Write("\t" + contact.City);
                    Console.Write("\t" + contact.State);
                    Console.Write("\t" + contact.ZipCode);
                    Console.Write("\t" + contact.PhoneNumber);
                    Console.Write("\t" + contact.Email);
                    Console.Write("\n");
                }
            }
        }
        public static void WriteCSVFile(List<Contact> data)
        {
            string filePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Utility\Contact.csv";
            using (var writer = new StreamWriter(filePath))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                Console.WriteLine("Data Writing done successfully from Contact.csv file");
                csvWrite.WriteRecords(data);
            }
        }
    }
}
