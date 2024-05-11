using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Mapper;
using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CardService : ICardService<CardDto>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IActivityService<ActivityDto> activityService;
        private readonly IHistoryService<HistoryDto> historyService;

        public CardService(AppDbContext context, IMapper mapper, IActivityService<ActivityDto> activityService, IHistoryService<HistoryDto> historyService)
        {
            this.context = context;
            this.mapper = mapper;
            this.activityService = activityService;
            this.historyService = historyService;
        }
        public async Task<CardDto> CreateCard(CardDto cardDto)
        {
            try
            {
                var card = new Card
                {
                    Name = cardDto.Name,
                    Description = cardDto.Description,
                    Date = cardDto.Date,
                    Priority = cardDto.Priority,
                    ListId = cardDto.ListId
                };

                context.Cards.Add(card);


                await context.SaveChangesAsync();

                await activityService.LogActivity(new ActivityDto
                {
                    Action = $"You created this card'",
                    CardId = card.Id,
                    Date = DateTime.Now.ToString("MMM d 'at' h:mm tt")
                });

                await historyService.LogHistory(new HistoryDto
                {
                    Action = $"You created {cardDto.Name} card",
                    Date = DateTime.Now.ToString("MMM d 'at' h:mm tt")

                });
                return mapper.Map<CardDto>(card);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating card: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteCard(int id)
        {
            try
            {
                var card = await context.Cards.FindAsync(id);

                if (card == null)
                    throw new Exception($"Card with id {id} not found");

                context.Cards.Remove(card);

                await context.SaveChangesAsync();

                await activityService.LogActivity(new ActivityDto
                {
                    Action = $"You deleted this card'",
                    CardId = card.Id,
                    Date = DateTime.Now.ToString("MMM d 'at' h:mm tt")
                });

                await historyService.LogHistory(new HistoryDto
                {
                    Action = $"You deleted {card.Name} card'",
                    Date = DateTime.Now.ToString("MMM d 'at' h:mm tt")
                });
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting card with id {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<CardDto> EditCard(int cardId, CardDto cardDto)
        {
            try
            {
                var card = await context.Cards.FirstOrDefaultAsync(w => w.Id == cardId);

                if (card == null)
                    throw new Exception($"Card with id {cardId} not found");


                var activityChanges = ActivityCardChange(card, cardDto);

                if (activityChanges.Any())
                {
                    foreach (var change in activityChanges)
                    {
                        await activityService.LogActivity(new ActivityDto
                        {
                            Action = change,
                            CardId = card.Id,
                            Date = DateTime.Now.ToString("MMM d 'at' h:mm tt")
                        });
                    }

                    var historyChanges = HistoryCardChange(card, cardDto);

                    if (historyChanges.Any())
                    {
                        foreach (var change in historyChanges)
                        {
                            await historyService.LogHistory(new HistoryDto
                            {
                                Action = change,
                                Date = DateTime.Now.ToString("MMM d 'at' h:mm tt")
                            });
                        }
                    }

                    card.Name = cardDto.Name;
                    card.Description = cardDto.Description;
                    card.Date = cardDto.Date;
                    card.Priority = cardDto.Priority;
                    card.ListId = cardDto.ListId;

                    await context.SaveChangesAsync();
                }
                return cardDto;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Error editing card with id {cardId}: {ex.Message}");
                throw;
            }
        }

        public async Task<CardDto> FetchCard(int id)
        {
            try
            {
                var card = await context.Cards.FirstOrDefaultAsync(c => c.Id == id);

                if (card == null)
                    throw new Exception($"Card with id {id} not found");

                return mapper.Map<CardDto>(card);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching card with id {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<CardDto>> FetchAllCards()
        {
            try
            {
                var card = await context.Cards.ToListAsync();
                return mapper.Map<IEnumerable<CardDto>>(card);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error fetching all cards: {ex.Message}");
                throw;
            }
        }

        private List<string> ActivityCardChange(Card card, CardDto cardDto)
        {
            var changes = new List<string>();

            if (card.Name != cardDto.Name)
                changes.Add($"You renamed this card from '{card.Name}' to '{cardDto.Name}'");
            

            if (card.Description != cardDto.Description)
                changes.Add($"You changed description from '{card.Description}' to '{cardDto.Description}'");
            

            if (card.Priority != cardDto.Priority)
                changes.Add($"You changed priority from '{card.Priority}' to '{cardDto.Priority}'");
            

            if (card.Date != cardDto.Date)
                changes.Add($"You changed date from '{card.Date}' to '{cardDto.Date}'");
            

            if (card.ListId != cardDto.ListId)
            {
                var oldListName = context.Lists.Where(l => l.Id == card.ListId).Select(l => l.Name).FirstOrDefault();
                var newListName = context.Lists.Where(l => l.Id == cardDto.ListId).Select(l => l.Name).FirstOrDefault();

                changes.Add($"You changed status from '{oldListName}' to '{newListName}'");
            }

            return changes;
        }

        private List<string> HistoryCardChange(Card card, CardDto cardDto)
        {
            var changes = new List<string>();

            if (card.Name != cardDto.Name)
                changes.Add($"You renamed '{card.Name}' to '{cardDto.Name}'");
            

            if (card.Description != cardDto.Description)
                changes.Add($"You changed the description {card.Name} from '{card.Description}' to '{cardDto.Description}'");
            

            if (card.Priority != cardDto.Priority)
                changes.Add($"You changed the priority {card.Name} from '{card.Priority}' to '{cardDto.Priority}'");
            

            if (card.Date != cardDto.Date)
                changes.Add($"You changed the date {card.Name} from '{card.Date}' to '{cardDto.Date}'");
            

            if (card.ListId != cardDto.ListId)
            {
                var oldListName = context.Lists.Where(l => l.Id == card.ListId).Select(l => l.Name).FirstOrDefault();
                var newListName = context.Lists.Where(l => l.Id == cardDto.ListId).Select(l => l.Name).FirstOrDefault();

                changes.Add($"You moved {card.Name} from '{oldListName}' to '{newListName}'");
            }

            return changes;
        }

    }
}