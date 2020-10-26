using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class CSVReadWrite
    {
        public static List<Contact> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<ContactMap>();
                    var records = csv.GetRecords<Contact>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void WriteCSVFile(string path, List<Contact> contacts)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<Contact>();
                cw.NextRecord();
                foreach (Contact contact in contacts)
                {
                    cw.WriteRecord<Contact>(contact);
                    cw.NextRecord();
                }
            }
        }
    }
}
