using System;
using System.Linq;
using Employex.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Employex.Api
{
    class GeneralUserApi
    {
        RestClient client = new RestClient("http://localhost:8080/ricardorzan/Employex/1.0.0");
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
