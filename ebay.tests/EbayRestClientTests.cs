using System.Threading.Tasks;
using EbayNet;
using EbayNet.Authentication;
using FluentAssertions;
using Flurl.Http;
using Flurl.Http.Testing;
using NSubstitute;
using Xunit;
using Flurl;
using System;

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

        [Fact]
        public async Task EbayRestClient_Should_ThrowEbayException()
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
                .WithHeader("header", "value");

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Resource Not Found", 404);

                await Assert.ThrowsAsync<EbayException>(async () => await restClient.Request<object>(flurl));
            }
        }
    }
}
