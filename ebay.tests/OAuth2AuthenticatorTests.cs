using System;
using System.Net.Http;
using System.Threading.Tasks;
using EbayNet.Authentication;
using FluentAssertions;
using Flurl.Http.Testing;
using Xunit;

namespace ebay.tests
{
    public sealed class OAuth2AuthenticatorTests
    {
        [Theory]
        [InlineData(null, null, "Og==")]
        [InlineData("", "", "Og==")]
        [InlineData("a", "a", "YTph")]
        [InlineData("clientId", "clientSecret", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0")]
        [InlineData("my-awesome-app-11ab1cd02-11z12345",
                    "ABC-1hg3jk1999ab-b123-456c-a12b-12aza",
                    "bXktYXdlc29tZS1hcHAtMTFhYjFjZDAyLTExejEyMzQ1OkFCQy0xaGczamsxOTk5YWItYjEyMy00NTZjLWExMmItMTJhemE=")]
        public void OAuth2Authenticator_ShouldCorrectly_SetBase64Property(string clientId, string clientSecret, string expected)
        {
            var authenticator = new OAuth2Authenticator(clientId, clientSecret);
            authenticator.Base64EncodedOAuthCredentials
                .Should()
                .Be(expected);
        }

        [Fact]
        public async Task OAuth2Authenticator_ShouldUse_ProductionUrl()
        {
            var authenticator = new OAuth2Authenticator("clientId", "clientSecret");
            using (var httpTest = new HttpTest())
            {
                var token = await authenticator.AuthenticateAsync();
                httpTest
                    .ShouldHaveCalled("https://api.ebay.com/identity/v1/oauth2/token/")
                    .WithContentType("application/x-www-form-urlencoded")
                    .WithHeader("Authorization", "Basic *")
                    .WithRequestBody("grant_type=client_credentials")
                    .WithRequestBody("scope=https*")
                    .Times(1);
            }
        }

        [Fact]
        public async Task OAuth2Authenticator_ShouldUse_SanboxUrl()
        {
            var authenticator = new OAuth2Authenticator("clientId", "clientSecret");
            authenticator.UrlService.Environment = EbayNet.Environment.Sandbox;
            using (var httpTest = new HttpTest())
            {
                var token = await authenticator.AuthenticateAsync();
                httpTest
                    .ShouldHaveCalled("https://api.sandbox.ebay.com/identity/v1/oauth2/token/")
                    .WithContentType("application/x-www-form-urlencoded")
                    .WithHeader("Authorization", "Basic *")
                    .WithRequestBody("grant_type=client_credentials")
                    .WithRequestBody("scope=https*")
                    .Times(1);
            }
        }
    }
}

