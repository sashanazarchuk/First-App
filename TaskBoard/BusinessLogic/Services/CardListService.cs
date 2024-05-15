using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
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
    public class CardListService : ICardListService<CardListDto>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CardListService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CardListDto> CreateList(CardListDto listDto)
        {
            try
            {
                var list = new CardList
                {
                    Name = listDto.Name
                };

                context.Lists.Add(list);
                await context.SaveChangesAsync();

                return mapper.Map<CardListDto>(list);
            }
            catch (Exception ex)
            {
                throw new ($"Error creating list: {ex.Message}");
               
            }
        }

        public async Task DeleteList(int id)
        {
            try
            {
                var list = await context.Lists.FindAsync(id);

                if (list == null)
                    throw new Exception($"List with id {id} not found");

                context.Lists.Remove(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new ($"Error deleting list with id {id}: {ex.Message}");
                 
            }
        }

        public async Task<CardListDto> EditList(int listId, CardListDto listDto)
        {
            try
            {
                var list = await context.Lists.FirstOrDefaultAsync(w => w.Id == listId);

                if (list == null)
                    throw new Exception($"List with id {listId} not found");


                list.Name = listDto.Name;


                await context.SaveChangesAsync();

                return listDto;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ($"Error editing list with id {listId}: {ex.Message}");
                
            }
        }

        public async Task<IEnumerable<CardListDto>> FetchAllList()
        {
            try
            {
                var list = await context.Lists.ToListAsync();
                return mapper.Map<IEnumerable<CardListDto>>(list);
            }
            catch (Exception ex)
            {

                throw new ($"Error fetching all lists: {ex.Message}");
                 
            }
        }
    }
}
