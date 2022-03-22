using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Ensciens.Tests
{
    public class ViewsTest
    : IClassFixture<WebApplicationFactory<Ensciens.Startup>>
    {
        private readonly WebApplicationFactory<Ensciens.Startup> _factory;

        public ViewsTest(WebApplicationFactory<Ensciens.Startup> factory)
        {
            _factory = factory;
        }


        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Eleve/")]
        [InlineData("/Eleve/Create")]
        [InlineData("/Bureau/")]
        [InlineData("/Bureau/Edit/61")]
        [InlineData("/Famille/")]
        [InlineData("/Publication/")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }


        [Theory]
        [InlineData("/Famille/Edit/2")]
        [InlineData("/Famille/Delete")]
        [InlineData("/ControleurInexistant")]
        public async Task Get_EndpointsReturnError(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            int statusCode = (int)response.StatusCode;
            Xunit.Assert.True(statusCode == 404);
        }
    }
}
