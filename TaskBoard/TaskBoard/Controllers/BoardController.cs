using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService<BoardDto> service;

        public BoardController(IBoardService<BoardDto> service)
        {
            this.service = service;
        }

        [HttpPost("CreateBoard")]
        public async Task<IActionResult> CreateBoard(BoardDto boardDto)
        {
            try
            {
                await service.CreateBoard(boardDto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("EditBoard/{id}")]
        public async Task<IActionResult> EditBoard(int id, BoardDto boardDto)
        {
            try
            {
                await service.EditBoard(id, boardDto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveBoard/{id}")]
        public async Task<IActionResult> RemoveBoard(int id)
        {
            try
            {
                await service.DeleteBoard(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FetchAllBoards")]
        public async Task<IActionResult> FetchAllBoards()
        {
            try
            {
                return Ok(await service.FetchAllBoards());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("FetchBoard{id}")]
        public async Task<IActionResult> FetchBoard(int id)
        {
            try
            {
                return Ok(await service.FetchBoard(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
