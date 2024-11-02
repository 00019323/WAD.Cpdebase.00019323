using Microsoft.AspNetCore.Mvc;
using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Interfaces;

namespace WAD.Codebase._00019323.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewspapersController : ControllerBase
    {
        private readonly INewspaperRepository _repository;

        public NewspapersController(INewspaperRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewspaperDto>>> GetAll()
        {
            var newspapers = await _repository.GetAllAsync();
            return Ok(newspapers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewspaperDto>> GetById(int id)
        {
            var newspaper = await _repository.GetByIdAsync(id);
            if (newspaper == null) return NotFound("Newspaper not found.");

            return Ok(newspaper);
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewspaperCreateDto newspaperCreateDto)
        {
            var newspaper = await _repository.CreateAsync(newspaperCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = newspaper.Id }, $"Record with id {newspaper.Id} created.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, NewspaperEditDto newspaperEditDto)
        {
            if (id != newspaperEditDto.Id) return BadRequest("Id mismatch.");

            var updatedNewspaper = await _repository.UpdateAsync(newspaperEditDto);
            if (updatedNewspaper == null) return NotFound("Newspaper not found.");

            return Ok($"Record with id {id} updated.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result) return NotFound("Newspaper not found.");

            return Ok($"Record with id {id} deleted.");
        }
    }
}
