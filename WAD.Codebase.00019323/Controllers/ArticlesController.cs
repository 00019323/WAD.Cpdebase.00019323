using Microsoft.AspNetCore.Mvc;
using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Interfaces;

namespace WAD.Codebase._00019323.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _repository;

        public ArticlesController(IArticleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetAll()
        {
            var articles = await _repository.GetAllAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetById(int id)
        {
            var article = await _repository.GetByIdAsync(id);
            if (article == null) return NotFound("Article not found.");

            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ArticleCreateDto articleCreateDto)
        {
            var article = await _repository.CreateAsync(articleCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = article.Id }, $"Record with id {article.Id} created.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ArticleEditDto articleEditDto)
        {
            if (id != articleEditDto.Id) return BadRequest("Id mismatch.");

            var updatedArticle = await _repository.UpdateAsync(articleEditDto);
            if (updatedArticle == null) return NotFound("Article not found.");

            return Ok($"Record with id {id} updated.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result) return NotFound("Article not found.");

            return Ok($"Record with id {id} deleted.");
        }
    }
}
