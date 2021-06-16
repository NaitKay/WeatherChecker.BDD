using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChecker.BDD.ApiHelper
{
    class ApiCaller
    {
        private readonly string apiUrl;
        public ApiCaller() 
        {
            apiUrl = Environment.GetEnvironmentVariable("weatherAppAPI");
            
        }
        public void CallGET()
        {
            var client = new RestClient(apiUrl);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        public IRestResponse CallPOST(string body)
        {
            var client = new RestClient(apiUrl);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            return client.Execute(request);
            
        }
    }

}
