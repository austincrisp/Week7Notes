using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Day1APIClient.Models
{
    class PeopleCollection
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<People> Results { get; set; }

        public PeopleCollection GetPage(HttpClient client, Uri page)
        {
            string pageNumber = page.Query;
            if (pageNumber != null)
            {
                var allPeopleResponse = client.GetAsync($"people{pageNumber}").Result;
                return allPeopleResponse.Content.ReadAsAsync<PeopleCollection>().Result;
            }
            return this;
        }

        public PeopleCollection GetPrevious(HttpClient client)
        {
            return GetPage(client, Previous);
        }

        public PeopleCollection GetNext(HttpClient client)
        {
            return GetPage(client, Next);
        }
    }

    class People
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public Uri Homeworld { get; set; }

        public Planet HomeworldDetail(HttpClient client)
        {
            var response = client.GetAsync(Homeworld).Result;
            Planet homeworld = response.Content.ReadAsAsync<Planet>().Result;
            return homeworld;
        }
    }
}
