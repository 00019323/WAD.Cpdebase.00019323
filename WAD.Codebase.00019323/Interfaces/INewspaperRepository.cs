using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Models;

namespace WAD.Codebase._00019323.Interfaces
{
    public interface INewspaperRepository
    {
        Task<IEnumerable<NewspaperDto>> GetAllAsync();
        Task<NewspaperDto> GetByIdAsync(int id);
        Task<Newspaper> CreateAsync(NewspaperCreateDto newspaperCreateDto);
        Task<Newspaper> UpdateAsync(NewspaperEditDto newspaperEditDto);
        Task<bool> DeleteAsync(int id);
    }
}
