using AGL.Entity;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AGL.Business.Service
{
    public class PeopleService : IPeopleService
    {
        HttpClient _client;
        private readonly string _serviceURL;

        public PeopleService()
        {
            _client = new HttpClient();
            _serviceURL = "http://agl-developer-test.azurewebsites.net/people.json";
        }

        public List<People> GetPeople()
        {
            List<People> people = null;
            HttpResponseMessage response = _client.GetAsync(_serviceURL).Result;
            if (response.IsSuccessStatusCode)
            {
                string result =  response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(result))
                {
                    people = (List<People>)JsonConvert.DeserializeObject(result, typeof(List<People>));
                }
            }
            return people;
        }
    }
}
