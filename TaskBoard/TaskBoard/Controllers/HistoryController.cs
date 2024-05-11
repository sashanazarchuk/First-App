using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService<HistoryDto> _historyService;

        public HistoryController(IHistoryService<HistoryDto> historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("History")]
        public async Task<ActionResult<IEnumerable<HistoryDto>>> GetHistory()
        {
            try
            {
                var history = await _historyService.GetAllHistory();
                return Ok(history);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting history: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
