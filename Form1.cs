using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace PeopleDataLabs
{
    public partial class Form1 : Form
    {
        // Define your data model here
        public class Person
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string LinkedIn { get; set; }
            public string Email { get; set; }
            // Add other fields as needed
        }


        public Form1()
        {
            InitializeComponent();
        }


        private const string API_KEY = "4eb821be1bae42ff4ba538c5e89d5d61c158ae009e55085ad9cb3c2323b5d6e4";
        private const string PDL_URL = "https://api.peopledatalabs.com/v5/person/search";
        private const string CSV_FILENAME = "enriched_profiles.csv";
        private const string INPUT_FILE = "profiles.csv";
        private static string output = string.Empty;
        public static string LinkedInParameter = string.Empty;

        static async Task Search()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.peopledatalabs.com/v5/person/search?dataset=all&sql=SELECT * FROM person WHERE linkedin_username = '{LinkedInParameter}'&size=10&pretty=true");
                request.Headers.Add("X-Api-Key", "4eb821be1bae42ff4ba538c5e89d5d61c158ae009e55085ad9cb3c2323b5d6e4");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();

                List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(jsonResponse);
                // Save data to CSV
                using (var writer = new StreamWriter("enrich_people.csv"))
                {
                    foreach (var item in personList)
                    {
                        // Write data to CSV format (customize as needed)
                        await writer.WriteLineAsync($"{item.FName},{item.LName},{item.Email},{item.LinkedIn}");
                    }
                }

                Console.WriteLine("Data saved to enrich_people.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    

        static void SaveProfilesToCsv(List<JObject> profiles, string filename, List<string> fields, char delimiter)
        {
            using (var writer = new StreamWriter(filename))
            {
                // Write Header:
                writer.WriteLine(string.Join(delimiter.ToString(), fields));

                int count = 0;
                foreach (var profile in profiles)
                {
                    // Write Body:
                    var values = fields.Select(field => profile.ContainsKey(field) ? profile[field].ToString() : "");
                    writer.WriteLine(string.Join(delimiter.ToString(), values));
                    count++;
                    Console.WriteLine($"Wrote {count} lines to: '{filename}'");
                }
            }
        }

        static void SaveProfilesToCsv(List<Dictionary<string, string>> profiles)
        {
            var csvHeaderFields = new List<string>
            {
                "full_name", "job_title", "job_company_name", "job_company_website",
                "work_email", "mobile_phone", "linkedin_url"
            };


            using (var writer = new StreamWriter(CSV_FILENAME))
            {
                writer.WriteLine(string.Join(",", csvHeaderFields));

                foreach (var profile in profiles)
                {
                    var csvLine = new List<string>();
                    foreach (var field in csvHeaderFields)
                    {
                        csvLine.Add(profile.ContainsKey(field) ? profile[field] : "");
                    }
                    writer.WriteLine(string.Join(",", csvLine));
                }
                Console.WriteLine($"Wrote {profiles.Count} lines to: '{CSV_FILENAME}'.");
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            LinkedInParameter = LinkedIn_tb.Text;
            var t = Task.Run(() => Search());
            results_tb.Text = output;
        }

        private void enrich_btn_Click(object sender, EventArgs e)
        {

        }
        
    }
}