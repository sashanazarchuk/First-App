using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {

        private readonly IListService<ListDto> service;

        public ListController(IListService<ListDto> service)
        {
            this.service = service;
        }

        [HttpPost("CreateList")]
        public async Task<IActionResult> CreateList(ListDto listDto)
        {
            try
            {
                await service.CreateList(listDto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("EditList/{id}")]
        public async Task<IActionResult> EditList(int id, ListDto listDto)
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
