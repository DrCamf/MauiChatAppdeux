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
    public class RegisterService
    {
       

        static RegisterService _instance;

        public static RegisterService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RegisterService();

                return _instance;
            }
        }


        public bool CreateUser(RegisterInfo registerInfo)
        {
            //Adress of API
            var url = "https://mauichat.elthoro.dk";
            var client = new RestClient(url);

            string output = JsonConvert.SerializeObject(registerInfo);
            //The keys for the right API search
            var apiurl = "/?pass=person";
            var request = new RestRequest(apiurl, Method.Post);
           
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(output);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return true;
               // return JsonConvert.DeserializeObject<List<Area>>(response.Content);
            }
            else
            {
                return false;
               // return null;
            }

        }
    }
}
