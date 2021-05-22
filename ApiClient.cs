using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Employex.Model;
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

        readonly RestClient client = new RestClient("http://localhost:8080/ricardorzan/Employex/1.0.0");

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
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Continue:
                        break;
                    case System.Net.HttpStatusCode.SwitchingProtocols:
                        break;
                    case System.Net.HttpStatusCode.OK:
                        break;
                    case System.Net.HttpStatusCode.Created:
                        break;
                    case System.Net.HttpStatusCode.Accepted:
                        break;
                    case System.Net.HttpStatusCode.NonAuthoritativeInformation:
                        break;
                    case System.Net.HttpStatusCode.NoContent:
                        break;
                    case System.Net.HttpStatusCode.ResetContent:
                        break;
                    case System.Net.HttpStatusCode.PartialContent:
                        break;
                    case System.Net.HttpStatusCode.Ambiguous:
                        break;
                    case System.Net.HttpStatusCode.Moved:
                        break;
                    case System.Net.HttpStatusCode.Redirect:
                        break;
                    case System.Net.HttpStatusCode.RedirectMethod:
                        break;
                    case System.Net.HttpStatusCode.NotModified:
                        break;
                    case System.Net.HttpStatusCode.UseProxy:
                        break;
                    case System.Net.HttpStatusCode.Unused:
                        break;
                    case System.Net.HttpStatusCode.TemporaryRedirect:
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        MessageBox.Show("Error al ingresar las credenciales");
                        break;
                    case System.Net.HttpStatusCode.PaymentRequired:
                        break;
                    case System.Net.HttpStatusCode.Forbidden:
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        break;
                    case System.Net.HttpStatusCode.MethodNotAllowed:
                        break;
                    case System.Net.HttpStatusCode.NotAcceptable:
                        break;
                    case System.Net.HttpStatusCode.ProxyAuthenticationRequired:
                        break;
                    case System.Net.HttpStatusCode.RequestTimeout:
                        break;
                    case System.Net.HttpStatusCode.Conflict:
                        break;
                    case System.Net.HttpStatusCode.Gone:
                        break;
                    case System.Net.HttpStatusCode.LengthRequired:
                        break;
                    case System.Net.HttpStatusCode.PreconditionFailed:
                        break;
                    case System.Net.HttpStatusCode.RequestEntityTooLarge:
                        break;
                    case System.Net.HttpStatusCode.RequestUriTooLong:
                        break;
                    case System.Net.HttpStatusCode.UnsupportedMediaType:
                        break;
                    case System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
                        break;
                    case System.Net.HttpStatusCode.ExpectationFailed:
                        break;
                    case System.Net.HttpStatusCode.UpgradeRequired:
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        break;
                    case System.Net.HttpStatusCode.NotImplemented:
                        break;
                    case System.Net.HttpStatusCode.BadGateway:
                        break;
                    case System.Net.HttpStatusCode.ServiceUnavailable:
                        break;
                    case System.Net.HttpStatusCode.GatewayTimeout:
                        break;
                    case System.Net.HttpStatusCode.HttpVersionNotSupported:
                        break;
                    default:
                        break;
                }
                return false;
            }
        }
    }
}
