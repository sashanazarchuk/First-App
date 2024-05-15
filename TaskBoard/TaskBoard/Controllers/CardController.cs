using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ICardService<CardDto> service;

        public CardController(ICardService<CardDto> service)
        {
            this.service = service;
        }

        [HttpPost("CreateCard")]
        public async Task<IActionResult> CreateCard(CardDto cardDto)
        {
            try
            {
                await service.CreateCard(cardDto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveCard/{id}")]
        public async Task<IActionResult> RemoveCard([FromRoute] int id)
        {
            try
            {
                await service.DeleteCard(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("EditItem/{id}")]
        public async Task<IActionResult> EditItem(int id, CardDto cardDto)
        {
            try
            {
                await service.EditCard(id, cardDto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FetchCard/{id}")]
        public async Task<IActionResult> FetchCard(int id)
        {
            try
            {
                var cardDto = await service.FetchCard(id);
                return Ok(cardDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("FetchAllCards")]
        public async Task<IActionResult> FetchAllCards()
        {
            try
            {
                var cardsDto = await service.FetchAllCards();
                return Ok(cardsDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
