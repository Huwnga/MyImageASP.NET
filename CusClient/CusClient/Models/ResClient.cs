using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace CusClient.Models
{
    public class ResClient
    {
        string mid = ConfigurationManager.ConnectionStrings["MyImageDomain"].ConnectionString;

        public ResClient()
        {
            BaseUrl = mid;
        }

        public string BaseUrl { get; set; }
        public string EndPoint { get; set; }

        public string RestRequestAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = client.GetAsync(EndPoint).Result;

            return GetStrResValue(response);
        }

        public string InsertData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(EndPoint, content).Result;

            return GetStrResValue(response);
        }
        public string InsertData(Object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            string postBody = JsonConvert.SerializeObject(obj);

            HttpContent content = new StringContent(postBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(EndPoint, content).Result;

            return GetStrResValue(response);
        }
        public string UpdateData(Object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            string postBody = JsonConvert.SerializeObject(obj);

            HttpContent content = new StringContent(postBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(EndPoint, content).Result;

            return GetStrResValue(response);
        }
        public string DeleteData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = client.DeleteAsync(EndPoint).Result;

            return GetStrResValue(response);
        }

        private string GetStrResValue(HttpResponseMessage response)
        {
            string strResponseValue = String.Empty;

            if (response.IsSuccessStatusCode)
            {
                strResponseValue = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                strResponseValue = "Error: " + (int)response.StatusCode + " (" + response.ReasonPhrase + ")";
            }

            return strResponseValue;
        }

        private int CheckStatusCode(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}