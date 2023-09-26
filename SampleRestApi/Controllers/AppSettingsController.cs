using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Data;
using SampleRestApi.Models;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AppSettingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AppSettingsController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Atualizar configuração do servidor SMTP
        /// </summary>
        /// <remarks>
        /// Atualiza a configuração do servidor SMTP para testar o envio de Email. Observação: Crie uma conta no link https://ethereal.email
        /// </remarks>
        /// <returns name="model">
        /// Configuração atualizada com sucesso!
        /// </returns>
        /// <response code="200">
        /// Success
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        [HttpPut]
        [Route("appsettings/")]
        public async Task<IActionResult> PutAsync([FromBody] AppSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var settings = await _context.AppSettings.AsNoTracking().ToListAsync();
                if (settings.Any())
                {
                    var id = settings.FirstOrDefault().Id;
                    model.Id = id;
                    _context.AppSettings.Update(_mapper.Map<AppSettings>(model));
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.AppSettings.AddAsync(_mapper.Map<AppSettings>(model));
                    await _context.SaveChangesAsync();
                }
                return Ok("Configuração atualizada com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}