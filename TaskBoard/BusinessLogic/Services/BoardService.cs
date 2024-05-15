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
    public class BoardService : IBoardService<BoardDto>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public BoardService(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<BoardDto> CreateBoard(BoardDto boardDto)
        {
            try
            {
                var board = new Board
                {
                    Name = boardDto.Name,
                };

                context.Boards.Add(board);
                await context.SaveChangesAsync();

                return mapper.Map<BoardDto>(board);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating board: {ex.Message}", ex);
            }
        }

        public async Task DeleteBoard(int id)
        {
            try
            {
                var board = await context.Boards.FindAsync(id);

                if (board == null)
                    throw new Exception($"Board with id {id} not found");

                context.Boards.Remove(board);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new($"Error deleting board with id {id}: {ex.Message}");

            }
        }

        public async Task<BoardDto> EditBoard(int boardId, BoardDto boardDto)
        {
            try
            {
                var board = await context.Boards.FirstOrDefaultAsync(w => w.BoardId == boardId);

                if (board == null)
                    throw new Exception($"Board with id {boardId} not found");


                board.Name = boardDto.Name;


                await context.SaveChangesAsync();

                return boardDto;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new($"Error editing board with id {boardId}: {ex.Message}");

            }
        }

        public async Task<IEnumerable<BoardDto>> FetchAllBoards()
        {
            try
            {
                var board = await context.Boards.ToListAsync();
                return mapper.Map<IEnumerable<BoardDto>>(board);
            }
            catch (Exception ex)
            {

                throw new($"Error fetching all boards: {ex.Message}");

            }
        }

        public async Task<BoardDto> FetchBoard(int boardId)
        {
            try
            {
                var board = await context.Boards.FirstOrDefaultAsync(c => c.BoardId == boardId);
                if (board == null)
                    throw new Exception($"Board with id {boardId} not found");

                return mapper.Map<BoardDto>(board);
            }
            catch (Exception ex)
            {
                throw new($"Error fetching board: {ex.Message}");
            }
        }
    }
}
