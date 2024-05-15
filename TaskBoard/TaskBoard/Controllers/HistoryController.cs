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

        [HttpGet("History/{id}")]
        public async Task<ActionResult<IEnumerable<HistoryDto>>> GetHistory(int boardId)
        {
            try
            {
                var history = await _historyService.GetHistories(boardId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                throw new ($"Error getting history: {ex.Message}");
            }
        }
    }
}
