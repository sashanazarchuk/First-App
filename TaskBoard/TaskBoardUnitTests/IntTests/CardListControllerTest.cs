using BusinessLogic.DTOs;
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
    public class CardListControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;
        public CardListControllerTest(WebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("CreateList", HttpStatusCode.Created)]
        [InlineData("EditList/4", HttpStatusCode.NoContent)]
        public async Task CardList_ReturnsExpectedStatusCode(string endpoint, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var client = factory.CreateClient();
            var cardListDto = new CardListDto
            {
                Name = "Hello",
                BoardId = 1
           
            };
            var content = new StringContent(JsonConvert.SerializeObject(cardListDto), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response;
            if (endpoint.Contains("CreateList"))
                response = await client.PostAsync($"/api/CardList/{endpoint}", content);

            else
                response = await client.PatchAsync($"/api/CardList/{endpoint}", content);


            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }


        [Fact]
        public async Task RemoveList_Returns204StatusCode()
        {
            // Arrange
            var client = factory.CreateClient();
            var listId = 1;

            // Act
            var response = await client.DeleteAsync($"/api/CardList/RemoveList/{listId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
