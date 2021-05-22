using System.Collections.Generic;
using System.Linq;
using Employex.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Employex.Api
{
    class JobOfferApi
    {
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
    }
}
