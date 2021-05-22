using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Employex.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Employex
{
    class ApiClient
    {
        /*HttpClient client = new HttpClient();

        ApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<User> GetFirstUser(string path)
        {
            IList<User> usersList = null;
            User firstUser = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                usersList = await response.Content.ReadAsAsync<User>();
                firstUser = await response.Content.ReadAsStringAsync<User>();
            }
            return firstUser;
        }*/

        RestClient client = new RestClient("http://localhost:8080/ricardorzan/Employex/1.0.0");

        public dynamic GetFirstJobOffer()
        {
            var request = new RestRequest($"/job_offers?page=1", Method.GET);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<IList<JobOffer>>(response.Content);
                return result.First();
            }
            else
            {
                return null;
            }
        }

        public dynamic GetJobOffers()
        {
            var request = new RestRequest($"/job_offers?page=1", Method.GET);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<JobOffer>>(response.Content);
                return result;
            }
            else
            {
                return null;
            }
        }

        internal bool LogIn(string text, string password)
        {
            var request = new RestRequest($"/users/login", Method.GET);
            request.AddParameter("username", text);
            request.AddParameter("password", password);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", "046b6c7f - 0b8a - 43b9 - b35d - 6489e6daee91"));
            var response = client.Execute(request);
            if (response.IsSuccessful)
                //var result = JsonConvert.DeserializeObject<String>(response.Content);
                return true;
            else
                return false;
        }
    }
}
