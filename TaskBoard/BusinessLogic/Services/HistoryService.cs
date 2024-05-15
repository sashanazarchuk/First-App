using AutoMapper;
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
    public class HistoryService : IHistoryService<HistoryDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HistoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HistoryDto>> GetAllHistory()
        {
            try
            {
                var history = await _context.Histories
                    .OrderByDescending(h => h.Date)
                    .ToListAsync();

                var historyDtos = _mapper.Map<IEnumerable<HistoryDto>>(history);

                foreach (var historyDto in historyDtos)
                {
                    historyDto.DateFormat = historyDto.Date.ToString("ddd, d MMMM");
                }
                return historyDtos;
            }
            catch (Exception ex)
            {
                throw new($"Error fetching all history: {ex.Message}");

            }
        }

        public async Task LogHistory(HistoryDto historyDto)
        {
            try
            {
                var history = new History
                {
                    Action = historyDto.Action,
                    Date = DateTime.UtcNow
                };

                _context.Histories.Add(history);
                await _context.SaveChangesAsync();

                var totalCount = await _context.Histories.CountAsync();

                if (totalCount > 20)
                {
                    var oldestRecord = await _context.Histories
                        .OrderBy(h => h.Date)
                        .FirstOrDefaultAsync();

                    if (oldestRecord != null)
                    {
                        _context.Histories.Remove(oldestRecord);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new($"Error logging history: {ex.Message}");

            }
        }
    }
}
