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
    public class LoginService : ILoginService
    {
        public async Task<User> Authenticate(LoginRequest loginRequest)
        {
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(loginRequest.email + ":" + loginRequest.password));

            var url = "https://mauichat.elthoro.dk/basic.php";

            using (var client = new RestClient(url))
            {
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("Authorization", "Basic " + encoded);
                var body = @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var json = response.Content.ToString();
                    
                    return JsonConvert.DeserializeObject<User>(json);
                    // return null;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
