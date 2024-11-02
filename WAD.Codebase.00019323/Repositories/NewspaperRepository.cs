using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00019323.Data;
using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Interfaces;
using WAD.Codebase._00019323.Models;

namespace WAD.Codebase._00019323.Repositories
{
    public class NewspaperRepository : INewspaperRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NewspaperRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewspaperDto>> GetAllAsync()
        {
            var newspapers = await _context.Newspapers.ToListAsync();
            return _mapper.Map<IEnumerable<NewspaperDto>>(newspapers);
        }

        public async Task<NewspaperDto> GetByIdAsync(int id)
        {
            var newspaper = await _context.Newspapers.FindAsync(id);
            return newspaper != null ? _mapper.Map<NewspaperDto>(newspaper) : null;
        }

        public async Task<Newspaper> CreateAsync(NewspaperCreateDto newspaperCreateDto)
        {
            var newspaper = _mapper.Map<Newspaper>(newspaperCreateDto);
            _context.Newspapers.Add(newspaper);
            await _context.SaveChangesAsync();
            return newspaper;
        }

        public async Task<Newspaper> UpdateAsync(NewspaperEditDto newspaperEditDto)
        {
            var newspaper = await _context.Newspapers.FindAsync(newspaperEditDto.Id);
            if (newspaper == null) return null;

            _mapper.Map(newspaperEditDto, newspaper);
            await _context.SaveChangesAsync();
            return newspaper;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var newspaper = await _context.Newspapers.FindAsync(id);
            if (newspaper == null) return false;

            _context.Newspapers.Remove(newspaper);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
