
using System;
using System.Net.Http;
using System.Threading.Tasks;
using EbayNet.Extensions;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace EbayNet.Authentication
{
    public class Token
    {
        public Token()
        {
           CreateDate = DateTime.Now; 
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        
        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        public DateTime CreateDate { get; }

        public bool HasExpired => CreateDate.Add(TimeSpan.FromSeconds(ExpiresIn)) <= DateTime.Now;
    }
}