using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using AppContacts.Models;
using System.Threading.Tasks;

namespace AppContacts
{

  public  interface IContactClient
    {
        IEnumerable<Contact> FindAll();
        Contact Find(int? id);
        bool Create(Contact Contact);
        bool Edit(Contact Contact);
        bool Delete(int id);
    }
    public class ContactClient:IContactClient
    {

        //private readonly string baseURL = "http://localhost:55031/api/";
        private readonly string baseURL = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
        public IEnumerable<Contact> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseURL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Contacts").Result;

                if (response.IsSuccessStatusCode)
                    return  response.Content.ReadAsAsync<IEnumerable<Contact>>().Result;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Contact Find(int? id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseURL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Contacts/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Contact>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Contact Contact)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseURL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Contacts", Contact).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Contact Contact)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseURL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Contacts/" + Contact.Id, Contact).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseURL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Contacts/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}