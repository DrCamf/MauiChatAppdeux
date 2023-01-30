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

        public static List<Message> GetLastFittyChats(int id) 
        {
            //Adress of API
            var url = "https://mauichat.elthoro.dk";
            var client = new RestClient(url);

            //The keys for the right API search
            var apiurl = "/?pass=chat&item=fifty&id=" + id;
            var request = new RestRequest(apiurl, Method.Get);

            RestResponse response =  client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Message>>(response.Content);
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> InsertMessage(SendMessage message)
        {
            var url = "https://mauichat.elthoro.dk";
            var client = new RestClient(url);
            var apiurl = "/?pass=chat";
            
            var request = new RestRequest(apiurl, Method.Post);
            string output = JsonConvert.SerializeObject(message);

            //AppShell.Current.DisplayAlert("Chat", "tekst: " + output, "OK");
            RestResponse response;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(output);
            try
            {
                response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception ex) { return false; }
            
           
        }
    }
}
