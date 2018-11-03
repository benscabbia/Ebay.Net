using System;
using System.Net.Http;
using System.Threading.Tasks;
using BrowseAPIs.Models;
using EbayNet;
using EbayNet.Authentication;
using EbayNet.BrowseAPIs;
using FluentAssertions;
using Flurl.Http;
using Flurl.Http.Testing;
using NSubstitute;
using Xunit;
using Flurl;

namespace ebay.tests
{
    public sealed class EbayRestClientTests
    {
        [Fact]
        public void EbayRestClient_ShouldHave_CorrectDefaultUrlService()
        {
            var restClient = new EbayRestClient();
            restClient.UrlService.Environment.Should().Be(EbayNet.Environment.Production);
        }

        [Fact]
        public async Task EbayRestClient_ShouldCorrectlyAdd_AuthTokenToRequest()
        {

            var moqAuth = Substitute.For<IOAuth2Authenticator>();
            moqAuth.GetTokenAsync().Returns(new Token
            {
                AccessToken = "randomtoken"
            });

            var restClient = new EbayRestClient
            {
                OAuth2Authenticator = moqAuth
            };

            IFlurlRequest flurl = "/some/path"
                .AppendPathSegment($"to", fullyEncode: true)
                .AppendPathSegment($"ebay", fullyEncode: true)
                .WithHeader("header", "value")
                .WithHeaders(
                    new
                    {
                        Content_Type = "application/json",
                    }, replaceUnderscoreWithHyphen: true);

            using (var httpTest = new HttpTest())
            {
                var response = await restClient.Request<object>(flurl);
                httpTest
                    .ShouldHaveCalled("https://api.ebay.com/some/path/to/ebay")
                    .WithContentType("application/json")
                    .WithHeader("Authorization", "Bearer randomtoken")
                    .WithHeader("header", "value")
                    .Times(1);
            }
        }
    }
}
