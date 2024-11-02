using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Models;

namespace WAD.Codebase._00019323.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<ArticleDto>> GetAllAsync();
        Task<ArticleDto> GetByIdAsync(int id);
        Task<Article> CreateAsync(ArticleCreateDto articleCreateDto);
        Task<Article> UpdateAsync(ArticleEditDto articleEditDto);
        Task<bool> DeleteAsync(int id);
    }
}
