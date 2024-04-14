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

namespace PeopleDataLabs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


            private const string API_KEY = "YOUR API KEY";
        private const string PDL_URL = "https://api.peopledatalabs.com/v5/person/bulk";
        private const string CSV_FILENAME = "enriched_profiles.csv";

        static async Task Main(string[] args)
        {
            var allRecords = new List<Dictionary<string, string>>();

            using (var reader = new StreamReader("profiles.csv"))
            {
                var profileCount = 0;
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (profileCount > 0)
                    {
                        var profile = new Dictionary<string, string>
                        {
                            { "profile", line }
                        };
                        allRecords.Add(profile);
                    }
                    profileCount++;
                }
                Console.WriteLine($"Read {profileCount - 1} profiles.");
            }

            var data = new Dictionary<string, List<Dictionary<string, string>>>
            {
                { "requests", allRecords }
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-api-key", API_KEY);
                var response = await client.PostAsync(PDL_URL, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponses = JsonConvert.DeserializeObject<List<JObject>>(responseContent);

                foreach (var jsonResponse in jsonResponses)
                {
                    if (jsonResponse["status"].Value<int>() == 200)
                    {
                        var record = jsonResponse["data"].ToObject<Dictionary<string, string>>();
                        allRecords.Add(record);
                    }
                    else
                    {
                        Console.WriteLine($"Bulk Person Enrichment Error: {jsonResponse}");
                    }
                }
            }

            SaveProfilesToCsv(allRecords);
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
    }
}
