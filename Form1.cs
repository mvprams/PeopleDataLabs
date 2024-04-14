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


        private const string API_KEY = "4eb821be1bae42ff4ba538c5e89d5d61c158ae009e55085ad9cb3c2323b5d6e4";
        private const string PDL_URL = "https://api.peopledatalabs.com/v5/person/bulk";
        private const string CSV_FILENAME = "enriched_profiles.csv";
        private const string INPUT_FILE = "profiles.csv";
        private static string output = string.Empty;

        static async Task Search()
        {
            var allRecords = new List<Dictionary<string, string>>();

            try
            {

                using (var reader = new StreamReader(INPUT_FILE))
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
                    /*

                    client.DefaultRequestHeaders.Add("X-api-key", API_KEY);
                    var response = await client.PostAsync(PDL_URL, content);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    List<JObject> jsonResponses = JsonConvert.DeserializeObject<List<JObject>>(responseContent);
                */
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
            catch (Exception e)
            {
                Console.WriteLine(output = e.Message.ToString());

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
            var t = Task.Run(() => Search());
            results_tb.Text = output;
        }

        private void enrich_btn_Click(object sender, EventArgs e)
        {

        }


////////////////////////////////////////////////////////////////////////////////////
///This is all the new stuff
#region
public async Task Alpha()
        { 

        // TODO: Add your API key below
            string apiKey = "";

            // TODO: Set the number of records to pull (-1 for all available records)
            int maxNumRecords = 100;

            string pdlUrl = "https://api.peopledatalabs.com/v5/person/search";
            var requestHeader = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-api-key", apiKey }
            };

            string sqlQuery = "SELECT * FROM person WHERE (linkedin_username = 'seanthorne')";
            int numRecordsToRequest = 10;

            var parameters = new Dictionary<string, string>
            {
                { "dataset", "all" },
                { "sql", sqlQuery },
                { "size", numRecordsToRequest.ToString() },
                { "pretty", "true" }
            };

            // Pull all results in multiple batches
            int batch = 1;
            var allRecords = new List<JObject>();
            var startTime = DateTime.Now;

            while (batch == 1 || parameters.ContainsKey("scroll_token"))
            {
                if (maxNumRecords != -1)
                {
                    // Update numRecordsToRequest
                    numRecordsToRequest = Math.Max(0, Math.Min(maxNumRecords - allRecords.Count, 100));
                }

                if (numRecordsToRequest == 0)
                {
                    break;
                }

                parameters["size"] = numRecordsToRequest.ToString();
                var response = await GetApiResponseAsync(pdlUrl, requestHeader, parameters);

                if (batch == 1)
                {
                    Console.WriteLine($"{response["total"]} available records in this search");
                }

                allRecords.AddRange(response["data"].ToObject<List<JObject>>());
                parameters["scroll_token"] = response.Value<string>("scroll_token");
                Console.WriteLine($"Retrieved {response["data"].Count()} records in batch {batch}");
                batch++;

                if (parameters.ContainsKey("scroll_token"))
                {
                    await Task.Delay(6000); // Avoid hitting rate limit thresholds
                }
            }

            var endTime = DateTime.Now;
            var runtime = endTime - startTime;

            Console.WriteLine($"Successfully recovered {allRecords.Count} profiles in {batch} batches [{runtime.TotalSeconds} seconds]");
        }

        static async Task<JObject> GetApiResponseAsync(string url, Dictionary<string, string> headers, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var response = await client.GetAsync(url + "?" + string.Join("&", parameters));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JObject.Parse(content);
            }
        }

        // Utility function to save profiles to CSV (you can implement this part)
        static void SaveProfilesToCsv(List<JObject> profiles, string filename, List<string> fields, string delimiter)
{
    // Implement your CSV saving logic here
}
#endregion
    }
}