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
    public class ChatAreaServices
    {
        static ChatAreaServices _instance;

        public static ChatAreaServices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChatAreaServices();

                return _instance;
            }
        }

        public List<Area> GetAllAreas()
        {
            //Adress of API
            var url = "https://mauichat.elthoro.dk";
            var client = new RestClient(url);

            //The keys for the right API search
            var apiurl = "/?pass=area";
            var request = new RestRequest(apiurl, Method.Get);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Area>>(response.Content);
            }
            else
            {
                return null;
            }

        }

        public Area GetArea(int id)
        {
            //Adress of API
            var url = "https://mauichat.elthoro.dk";
            var client = new RestClient(url);

            //The keys for the right API search
            var apiurl = "/?pass=area&id=" + id;
            var request = new RestRequest(apiurl, Method.Get);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Area>(response.Content);
            }
            else
            {
                return null;
            }

        }

        /* public List<Area> GetAreas()
         {
             return new List<Area>
             {

                 new Area {
                     name= "World war 1",
                     picture_path="https://mauichat.elthoro.dk/Areaimages/ww1.jpg"
                 },
                  new Area {
                     name= "World war 2",
                     picture_path="https://mauichat.elthoro.dk/Areaimages/ww2.jpg"
                 },
                   new Area {
                     name= "Franco Prussian war",
                     picture_path="https://mauichat.elthoro.dk/Areaimages/prussian.jpg"
                 },
                    new Area {
                     name= "Vietnam war",
                     picture_path="https://mauichat.elthoro.dk/Areaimages/vietnam.jpg"
                 },
             };
         }*/
    }
}
