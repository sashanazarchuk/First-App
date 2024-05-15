using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Controllers;

namespace TaskBoardUnitTests.UnitTests
{
    public class ActivityControllerTest
    {
        private readonly Mock<IActivityService<ActivityDto>> mockService;

        public ActivityControllerTest()
        {
            mockService = new Mock<IActivityService<ActivityDto>>();
        }


        [Fact]
        public async Task GetActivity_Success()
        {
            //arrange
            var cardId = 1;
            mockService.Setup(x => x.GetActivities(cardId))
                       .ReturnsAsync(await GetActivityDataAsync());

            var activityController = new ActivityController(mockService.Object);

            //act
            var result = await activityController.GetActivities(cardId);

            //assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(200, okObjectResult.StatusCode);
        }


        private async Task<IEnumerable<ActivityDto>> GetActivityDataAsync()
        {
            List<ActivityDto> activityDtos = new List<ActivityDto>
            {
                new ActivityDto
                {
                    Id=1,
                    Action="Action 1",
                    Date=DateTime.UtcNow,
                    CardId=1,
                },
                new ActivityDto
                {
                    Id=2,
                    Action="Action 2",
                    Date=DateTime.UtcNow,
                    CardId=2,
                },
                new ActivityDto
                {
                    Id=3,
                    Action="Action 3",
                    Date=DateTime.UtcNow,
                    CardId=2,
                }
            };
            return await Task.FromResult<IEnumerable<ActivityDto>>(activityDtos);
        }
    }
}
