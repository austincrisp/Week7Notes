using Day1APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day1APIClient
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        private static void SetUpClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/JSON"));
            client.BaseAddress = new Uri("https://swapi.co/api");
        }

        static void Main(string[] args)
        {
            SetUpClient();
            var response = client.GetAsync("people/1").Result;
            //var luke = response.Content.ReadAsStringAsync().Result;
            People luke = response.Content.ReadAsAsync<People>().Result;

            var allPeopleResponse = client.GetAsync("people").Result;
            PeopleCollection allPeople = allPeopleResponse.Content.ReadAsAsync<PeopleCollection>.Result;
            var nextPage = allPeople.GetNext(client);
        }
    }
}
