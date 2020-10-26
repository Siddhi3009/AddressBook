using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookSystem
{
    class ReadWrite
    {
        public static void ReadFromStreamReader()
        {
            string path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Contacts.txt";
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
        public static void WriteUsingStreamWriter(List<string> data)
        {
            string path = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\23. AddressBook\AddressBook\AddressBookSystem\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (string contact in data)
                    {
                        streamWriter.WriteLine(contact);
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
    }
}
