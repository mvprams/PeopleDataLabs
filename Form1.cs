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
using System.Dynamic;
using System.Threading;
using System.Configuration;

namespace PeopleDataLabs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// API configuration added to the app.config NOTE: Be sure to add System.Configurtion DLL to the Project References
        /// </summary>
        internal class APIConfiguration
        {
            private string _apiKey;
            public string APIKey
            {
                get
                {
                    return _apiKey;
                }
                set
                {
                    _apiKey = ConfigurationManager.AppSettings["ApiKey"];
                }
            }
        }

        internal class SearchResponse
        {
            public int Status { get; set; }
            public List<Person> Data { get; set; }
        }

        internal class EnrichResponse
        {
            public int Status { get; set; }
            public int Likelihood { get; set; }
            public Person Data { get; set; }
        }
        internal class Person
        {
            public string Id { get; set; }
            public string Full_name { get; set; }
            public string First_name { get; set; }
            public string Middle_initial { get; set; }
            public string Middle_name { get; set; }
            public string Last_initial { get; set; }
            public string Last_name { get; set; }
            public string Sex { get; set; }
            public int? Birth_year { get; set; }
            public string Birth_date { get; set; }
            public string Linkedin_url { get; set; }
            public string Linkedin_username { get; set; }
            public string Linkedin_id { get; set; }
            public string Facebook_url { get; set; }
        }
        #region "variables"
        private const string API_KEY = "4eb821be1bae42ff4ba538c5e89d5d61c158ae009e55085ad9cb3c2323b5d6e4";
        private const string PDL_URL = "https://api.peopledatalabs.com/v5/person/search";
        private const string CSV_FILENAME = "enriched_profiles.csv";
        private const string INPUT_FILE = "profiles.csv";
        private static string output = string.Empty;
        internal static string LinkedInParameter = string.Empty;
        internal static string LinkedInURL = string.Empty;
        #endregion

        
        static async Task Search()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.peopledatalabs.com/v5/person/search?dataset=all&sql=SELECT * FROM person WHERE linkedin_username = '{LinkedInParameter}'&size=10&pretty=true");
                request.Headers.Add("X-Api-Key", API_KEY);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();

                output = jsonResponse;

                SearchResponse apiresponse = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);
                
                foreach (var item in apiresponse.Data)
                {
                    LinkedInURL = item.Last_initial;
                }

                /*
                using (var writer = new StreamWriter("enrich_people.csv"))
                {
                    writer.WriteLine("Id, First Name, Last Name, LinkedIn Username, LinkedIn URL");
                    foreach (var item in apiresponse.Data)
                    {
                        string together = $"{item.Id},{item.First_name},{item.Last_name},{item.Linkedin_username},{item.Linkedin_url}";
                        // Write data to CSV format (customize as needed)
                        await writer.WriteLineAsync(together);
                    }
                }

                Console.WriteLine("Data saved to enrich_people.csv");
                */
            }
            catch (Exception ex)
            {
                output = $"Error: {ex.Message}";
            }
        }

        static async Task Enrich()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {

                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.peopledatalabs.com/v5/person/enrich?profile=https%3A%2F%2Fwww.linkedin.com%2Fin%2F{LinkedInParameter}&min_likelihood=0&titlecase=false&include_if_matched=false"),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "X-API-Key", "4eb821be1bae42ff4ba538c5e89d5d61c158ae009e55085ad9cb3c2323b5d6e4" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    //response.
                    EnrichResponse apiresponse = JsonConvert.DeserializeObject<EnrichResponse>(body);

                    
                    using (var writer = new StreamWriter("enrich_people.csv"))
                    {
                        writer.WriteLine("Likelihood, Id, First Name, Last Name, LinkedIn Username, LinkedIn URL");

                        string together = $"{apiresponse.Likelihood},{apiresponse.Data.Id},{apiresponse.Data.First_name},{apiresponse.Data.Last_name},{apiresponse.Data.Linkedin_username},{apiresponse.Data.Linkedin_url}";
                        // Write data to CSV format (customize as needed)
                        await writer.WriteLineAsync(together);

                    }
                }

                Console.WriteLine("Data saved to enrich_people.csv");

            }
            catch (Exception ex)
            {
                output = $"Error: {ex.Message}";
            }
        }
    


        private void Search_btn_Click(object sender, EventArgs e)
        {
            isFound_tb.Text = "Searching for Persons";
            LinkedInParameter = LinkedIn_tb.Text;
            var t = Task.Run(() => Search());
            Thread.Sleep(5000);
            results_tb.Text = output;
            if (output != string.Empty)
                isFound_tb.Text = "Person record Found!!!";
            else isFound_tb.Text = "Person Not Found";
        }

        private void enrich_btn_Click(object sender, EventArgs e)
        {
            isFound_tb.Text = "Sprinting....";
            LinkedInParameter = LinkedIn_tb.Text;
            var t = Task.Run(() => Enrich());
            Thread.Sleep(3000);
            results_tb.Text = output;
            if (output != string.Empty)
                isFound_tb.Text = "Person record Found!!!";
            else isFound_tb.Text = "Person Not Found";
        }

    }
}