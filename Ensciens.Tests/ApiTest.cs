using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Xunit.Abstractions;

namespace Ensciens.Tests
{
    public class ApiTest
    : IClassFixture<WebApplicationFactory<Ensciens.Startup>>
    {
        private readonly WebApplicationFactory<Ensciens.Startup> _factory;
        // Permet le déboggage en donnant un accès à l'écriture en console
        private readonly ITestOutputHelper output;

        public ApiTest(ITestOutputHelper output, WebApplicationFactory<Ensciens.Startup> factory)
        {
            this.output = output;
            _factory = factory;
        }


        [Theory]
        [InlineData("/api/EleveApi")]
        [InlineData("/api/BureauApi")]
        [InlineData("/api/ClubApi")]
        [InlineData("/api/CommentaireApi")]
        [InlineData("/api/EvenementApi")]
        [InlineData("/api/PublicationApi")]
        [InlineData("/api/EleveApi/1")]
        [InlineData("/api/EvenementApi/1")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        // Fonder une famille est interdit
        [Fact]
        public async Task Post_EndpointsReturnError()
        {
            // Arrange
            var client = _factory.CreateClient();
            String url = "/api/FamilleApi";
            HttpContent famille = new StringContent("{\"nombreEleves\":12,\"points\":0,\"couleur\":2}");
            // Act
            var response = await client.PostAsync(url, famille);
            // Assert
            int statusCode = (int)response.StatusCode;
            output.WriteLine("Status code vers POST /api/FamilleApi: {0}", statusCode);
            Xunit.Assert.True(statusCode >= 400 && statusCode < 500);
        }

        [Fact]
        public async Task CreateBureau_ReturnOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            String url = "/api/BureauApi";

            String content = "{\"Nom\":\"Bureau des tests\","+
                "\"Logo\":\"images/poulpe.png\","+
                "\"Description\":\"ça c'est un mulching réussi !\"}";
            
            HttpContent requestContent = new StringContent(content);
            requestContent.Headers.Remove("Content-Type");
            requestContent.Headers.Add("Content-Type","application/json");
            
            // Act
            var response = await client.PostAsync(url, requestContent);
            // Assert
            int statusCode = (int)response.StatusCode;
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreatePostAsPAUL_ReturnOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            String url = "/api/PublicationApi";

            String content = "{\"Titre\":\"Bonsoir\","+
                "\"Contenu\":\"Salut les amis j'espère que vous allez tous bien en tout cas moi ça va super\","+
                "\"Medias\":\"Mastodon\","+
                "\"PublicateurId\":\"2\","+
                "\"DatePublication\":\"2020-04-14T07:00:00\"}";
            
            HttpContent requestContent = new StringContent(content);
            requestContent.Headers.Remove("Content-Type");
            requestContent.Headers.Add("Content-Type","application/json");
            requestContent.Headers.Add("Mail","pbernard@ensc.fr");
            requestContent.Headers.Add("Password","pbernard123456");
            
            // Act
            var response = await client.PostAsync(url, requestContent);
            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task CreatePostAsPAUL_ReturnUnauthorized()
        {
            // Arrange
            var client = _factory.CreateClient();

            String url = "/api/PublicationApi";

            String content = "{\"Titre\":\"Bonjour\","+
                "\"Contenu\":\"Je ne suis pas PAUL BERNARD je suis un escroc\","+
                "\"Medias\":\"Twitter\","+
                "\"PublicateurId\":\"2\","+
                "\"DatePublication\":\"2020-04-14T07:00:00\"}";
            
            HttpContent requestContent = new StringContent(content);
            requestContent.Headers.Remove("Content-Type");
            requestContent.Headers.Add("Content-Type","application/json");
            requestContent.Headers.Add("Mail","pbernard@ensc.fr");
            requestContent.Headers.Add("Password","motdepasse");
            
            // Act
            var response = await client.PostAsync(url, requestContent);
            // Assert
            int statusCode = (int)response.StatusCode;
            Xunit.Assert.Equal(statusCode,401);
        }
    }
}
