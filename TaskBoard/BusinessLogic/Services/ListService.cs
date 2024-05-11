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
    public class ListService : IListService<ListDto>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ListService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ListDto> CreateList(ListDto listDto)
        {
            try
            {
                var list = new List
                {
                    Name = listDto.Name
                };

                context.Lists.Add(list);
                await context.SaveChangesAsync();

                return mapper.Map<ListDto>(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating list: {ex.Message}");
                throw;
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

                Console.WriteLine($"Error deleting list with id {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<ListDto> EditList(int listId, ListDto listDto)
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
                Console.WriteLine($"Error editing list with id {listId}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<ListDto>> FetchAllList()
        {
            try
            {
                var list = await context.Lists.ToListAsync();
                return mapper.Map<IEnumerable<ListDto>>(list);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error fetching all lists: {ex.Message}");
                throw;
            }
        }
    }
}
