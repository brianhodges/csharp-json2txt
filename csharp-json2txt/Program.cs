using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace csharp_json2txt
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "data.json";
            using (var file = File.OpenRead(filename))
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);
                    using (var f = File.CreateText("../log.txt"))
                    {
                        for (int x = 0; x < people.Count; x++)
                        {
                            f.WriteLine("ID: {0}", people[x].id);
                            f.WriteLine("Full Name: {0} {1}", people[x].first_name, people[x].last_name);
                            f.WriteLine("Email: {0}", people[x].email);
                            f.WriteLine("BTC Address: {0}", people[x].btc_address);
                            f.WriteLine("IP Address: {0}", people[x].ip_address);
                            f.WriteLine();
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Done.");
        }
    }
}


