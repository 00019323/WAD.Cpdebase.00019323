using AutoMapper;
using WAD.Codebase._00019323.Data;
using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Interfaces;
using WAD.Codebase._00019323.Models;

namespace WAD.Codebase._00019323.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArticleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllAsync()
        {
            var articles = await _context.Articles.Include(a => a.Newspaper).ToListAsync();
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public async Task<ArticleDto> GetByIdAsync(int id)
        {
            var article = await _context.Articles.Include(a => a.Newspaper).FirstOrDefaultAsync(a => a.Id == id);
            return article != null ? _mapper.Map<ArticleDto>(article) : null;
        }

        public async Task<Article> CreateAsync(ArticleCreateDto articleCreateDto)
        {
            var article = _mapper.Map<Article>(articleCreateDto);
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateAsync(ArticleEditDto articleEditDto)
        {
            var article = await _context.Articles.FindAsync(articleEditDto.Id);
            if (article == null) return null;

            _mapper.Map(articleEditDto, article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null) return false;

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
