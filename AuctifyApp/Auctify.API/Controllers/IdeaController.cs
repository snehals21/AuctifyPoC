using Application.DTOs;
using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Auctify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IdeaService _ideaService;

        public IdeaController(IdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIdea([FromBody] IdeaDTO ideaEntityDto)
        {
            var idea = new IdeaEntity
            {
                Title = ideaEntityDto.Title,
                Description = ideaEntityDto.Description,
                CategoryId = ideaEntityDto.CategoryId
            };
            var record = await _ideaService.CreateIdea(idea);
            return Ok(record);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetIdeas()
        {
            var ideas = await _ideaService.GetIdeas();
            return Ok(ideas);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetIdeasByCategory(int categoryId)
        {
            var ideas = await _ideaService.GetIdeasByCategory(categoryId);

            if (ideas == null)
                return NotFound($"No ideas found for Category ID: {categoryId}");

            return Ok(ideas);
        }
    }
}
