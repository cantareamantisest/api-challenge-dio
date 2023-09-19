using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Data;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class NewsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public NewsController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Obter uma lista das news
        /// </summary>
        /// <remarks>
        /// Obtém uma lista com todas as news cadastradas
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">
        /// Success
        /// </response>
        [HttpGet]
        [Route("news")]
        public async Task<ActionResult<IEnumerable<NewsViewModel>>> GetAsync()
        {
            var news = await _context.News
                .AsNoTracking()
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<NewsViewModel>>(news));
        }

        /// <summary>
        /// Excluir uma news
        /// </summary>
        /// <remarks>
        /// Exclui uma news em função do Id fornecido mantendo as informações do usuário inalteradas 
        /// </remarks>
        /// <response code="204">
        /// News deleted successful!
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        /// /// <response code="500">
        /// Internal Server Error
        /// </response>
        [HttpDelete]
        [Route("news/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return BadRequest();
            }

            try
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}