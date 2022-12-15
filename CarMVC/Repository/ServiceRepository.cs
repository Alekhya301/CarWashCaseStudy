using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CarMVC.Repository
{
    public class ServiceRepository
    {

        HttpClient client;
        public ServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }
        public HttpResponseMessage PostResponse(string url, object content)
        {
            return client.PostAsJsonAsync(url, content).Result;
        }
        public HttpResponseMessage DeleteResponse(string url, int Id)
        {
            return client.DeleteAsync(url +Id.ToString()).Result;
        }
        public HttpResponseMessage UpdateResponse(string url, int Id)
        {
            return client.GetAsync(url + Id.ToString()).Result;
        }
        public HttpResponseMessage EditResponse(string url, object content)
        {
            return client.PutAsJsonAsync(url , content).Result;
        }
        public HttpResponseMessage VerifyLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }


    }
}