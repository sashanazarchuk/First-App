using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ActivityService : IActivityService<ActivityDto>
    {
        private readonly AppDbContext context;

        public ActivityService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ActivityDto>> GetActivities(int cardId)
        {
            var activities = await context.Activities
            .Where(a => a.CardId == cardId)
            .OrderByDescending(a => a.Date)
            .Take(20)
            .ToListAsync();

            return activities.Select(a => new ActivityDto
            {
                Id = a.Id,
                Action = a.Action,
                CardId = a.CardId,
                Date = a.Date,
                DateFormat = a.Date.ToString("ddd, d MMMM")
            }).ToList();
        }

        public async Task LogActivity(ActivityDto activityDto)
        {
            var activity = new Activity
            {
                Action = activityDto.Action,
                CardId = activityDto.CardId,
                Date = DateTime.UtcNow
            };

            context.Activities.Add(activity);
            await context.SaveChangesAsync();
        }


    }
}
