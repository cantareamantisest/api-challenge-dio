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
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public FeaturesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Obter uma lista das features
        /// </summary>
        /// <remarks>
        /// Obtém uma lista com todas as features cadastradas
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">
        /// Success
        /// </response>
        [HttpGet]
        [Route("features")]
        public async Task<ActionResult<IEnumerable<FeaturesViewModel>>> GetAsync()
        {
            var features = await _context.Features
                .AsNoTracking()
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<FeaturesViewModel>>(features));
        }

        /// <summary>
        /// Excluir uma feature
        /// </summary>
        /// <remarks>
        /// Exclui uma feature em função do Id fornecido mantendo as informações do usuário inalteradas 
        /// </remarks>
        /// <response code="204">
        /// Feature deleted successful!
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        /// <response code="500">
        /// Internal Server Error
        /// </response>
        [HttpDelete]
        [Route("features/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Features.Remove(feature);
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