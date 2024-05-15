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
    public class BoardControllerTest
    {
        private readonly Mock<IBoardService<BoardDto>> mockService;

        public BoardControllerTest()
        {
            mockService = new Mock<IBoardService<BoardDto>>();
        }


        [Fact]
        public async Task GetBoard_Success()
        {
            //arrange
            var boardId = 1;
            var boardDto = new BoardDto { BoardId = boardId, Name = "Board 1" };
            mockService.Setup(x => x.FetchBoard(boardId))
                       .ReturnsAsync(boardDto);

            var boardController = new BoardController(mockService.Object);

            //act
            var result = await boardController.FetchBoard(boardId);

            //assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(200, okObjectResult.StatusCode);
        }


        [Fact]
        public async Task CreateBoard_Success()
        {
            // Arrange
            var boardDto = new BoardDto { Name = "New Board", BoardId = 1 };
            mockService.Setup(x => x.CreateBoard(boardDto)).ReturnsAsync(boardDto);

            var boardController = new BoardController(mockService.Object);

            // Act
            var result = await boardController.CreateBoard(boardDto);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }


        [Fact]
        public async Task RemoveBoard_Success()
        {
            // Arrange
            var boardId = 1;
            mockService.Setup(x => x.DeleteBoard(boardId)).Returns(Task.CompletedTask);

            var boardController = new BoardController(mockService.Object);

            // Act
            var result = await boardController.RemoveBoard(boardId);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task FetchAllBoards_ReturnsOkWithListOfBoards()
        {
            // Arrange
            var boards = await GetBoardDataAsync();

            mockService.Setup(x => x.FetchAllBoards()).ReturnsAsync(boards);

            var boardController = new BoardController(mockService.Object);

            // Act
            var result = await boardController.FetchAllBoards();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var resultBoards = Assert.IsAssignableFrom<IEnumerable<BoardDto>>(okObjectResult.Value);
            Assert.Equal(boards.Count(), resultBoards.Count());
            foreach (var board in boards)
            {
                Assert.Contains(resultBoards, b => b.BoardId == board.BoardId && b.Name == board.Name);
            }
        }

        private async Task<IEnumerable<BoardDto>> GetBoardDataAsync()
        {
            List<BoardDto> boardDtos = new List<BoardDto>
            {
                new BoardDto
                {
                    BoardId= 1,
                    Name="Board 1"
                },
                new BoardDto
                {
                    BoardId= 1,
                    Name="Board 1"
                },
                new BoardDto
                {
                    BoardId= 1,
                    Name="Board 1"
                }
            };
            return await Task.FromResult<IEnumerable<BoardDto>>(boardDtos);
        }
    }
}
