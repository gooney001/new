﻿using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        private void GetToken()
        {
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // 获取token
            var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                //Scope = "api1"
            }).Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);


            // 用获取到的token访问api
            var client2 = new HttpClient();
            client2.SetBearerToken(tokenResponse.AccessToken);

            var response = client2.GetAsync("http://localhost:5001/api/Values").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
