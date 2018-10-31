
using System;
using System.Net.Http;
using System.Threading.Tasks;
using EbayNet.Extensions;
using Flurl;
using Flurl.Http;
using System.Linq;

namespace EbayNet.Authentication
{
    public interface IOAuth2Authenticator
    {
        Task<Token> GetTokenAsync();
    }
}


