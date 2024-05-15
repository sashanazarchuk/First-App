using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardListController : ControllerBase
    {

        private readonly ICardListService<CardListDto> service;

        public CardListController(ICardListService<CardListDto> service)
        {
            this.service = service;
        }

        [HttpPost("CreateList")]
        public async Task<IActionResult> CreateList(CardListDto listDto)
        {
            try
            {
                await service.CreateList(listDto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("EditList/{id}")]
        public async Task<IActionResult> EditList(int id, CardListDto listDto)
        {
            try
            {
                await service.EditList(id, listDto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveList/{id}")]
        public async Task<IActionResult> RemoveList(int id)
        {
            try
            {
                await service.DeleteList(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FetchAllLists")]
        public async Task<IActionResult> FetchAllLists()
        {
            try
            {
                return Ok(await service.FetchAllList());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
