using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebMVC.Repositories
{
    public class ServicesRepositoryUser
    {
        HttpClient client;
        public ServicesRepositoryUser()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }
        public HttpResponseMessage PostResponse(string url , object content)
        {
            return client.PostAsJsonAsync(url, content).Result;
        }
        public HttpResponseMessage DeleteReponse(string url)
        {
            return client.DeleteAsync(url).Result;
        }

    }
}