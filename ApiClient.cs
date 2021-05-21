using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Employex.Models;
using Newtonsoft.Json;
using RestSharp;

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

        RestClient client = new RestClient(" http://127.0.0.1:4010");

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
    }
}
