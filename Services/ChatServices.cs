using MauiChatAppdeux.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.Services
{
    public class ChatServices
    {
        static ChatServices _instance;

        public static ChatServices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChatServices();

                return _instance;
            }
        }

        public List<Message> GetLastFittyChats(int id) 
        {
            //Adress of API
            var url = "https://mauichat.elthoro.dk";
            var client = new RestClient(url);

            //The keys for the right API search
            var apiurl = "/?pass=chat&item=fifty&id=" + id;
            var request = new RestRequest(apiurl, Method.Get);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Message>>(response.Content);
            }
            else
            {
                return null;
            }

        }
    }
}
