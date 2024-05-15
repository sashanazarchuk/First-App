using BusinessLogic.DTOs;
using Entities.Enum;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardUnitTests.IntTests
{
    public class CardControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;


        public CardControllerTest(WebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }


        [Theory]
        [InlineData("CreateCard", HttpStatusCode.Created)]
        [InlineData("EditItem/4", HttpStatusCode.NoContent)]
        public async Task Card_ReturnsExpectedStatusCode(string endpoint, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var client = factory.CreateClient();
            var cardDto = new CardDto
            {
                Name = "Hello",
                Description = "Hello",
                Date = new DateTime(2024, 5, 10).ToUniversalTime(),
                Priority = CardPriority.High,
                Board = "Home Board",
                CardList = "Home Completed"
            };
            var content = new StringContent(JsonConvert.SerializeObject(cardDto), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response;
            if (endpoint.Contains("CreateCard"))
                response = await client.PostAsync($"/api/Card/{endpoint}", content);

            else
                response = await client.PatchAsync($"/api/Card/{endpoint}", content);


            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }


        [Fact]
        public async Task RemoveCard_Returns204StatusCode()
        {
            // Arrange
            var client = factory.CreateClient();
            var cardId = 5;

            // Act
            var response = await client.DeleteAsync($"/api/Card/RemoveCard/{cardId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
