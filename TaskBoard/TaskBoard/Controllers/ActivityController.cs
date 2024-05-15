﻿using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService<ActivityDto> activityService;

        public ActivityController(IActivityService<ActivityDto> activityService)
        {
            this.activityService = activityService;
        }

        [HttpGet("{cardId}")]
        public async Task<IActionResult> GetActivities(int cardId)
        {
            try
            {
                var activities = await activityService.GetActivities(cardId);
                return Ok(activities);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
