using EbayNet;
using FluentAssertions;
using Xunit;

namespace ebay.tests
{
    public sealed class UrlServiceTests
    {
        [Fact]
        public void UrlService_ShouldHave_CorrectDefault()
        {
            var urlService = new UrlService();
            urlService.Url.Should().Be("https://api.ebay.com/");
        }

        [Fact]
        public void UrlService_ShouldReturn_CorrectUrl()
        {
            var urlService = new UrlService(EbayNet.Environment.Sandbox);
            urlService.Url.Should().Be("https://api.sandbox.ebay.com/");
        }
    }
}


