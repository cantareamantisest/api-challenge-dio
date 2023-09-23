using Microsoft.AspNetCore.Mvc;
using SampleRestApi.Utils;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AppSettingsController : ControllerBase
    {
        /// <summary>
        /// Atualizar configuração do servidor SMTP
        /// </summary>
        /// <remarks>
        /// Atualiza a configuração do servidor SMTP para testar o envio de Email. Observação: Crie uma conta no link www.etheral.com
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
        public IActionResult PutAsync([FromBody] SmtpServerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var configuration = ConfigurationOperations.ReadConfiguration();

            if (configuration == null)
            {
                return BadRequest();
            }

            try
            {
                configuration.SmtpServer.Host = model.Host;
                configuration.SmtpServer.Username = model.Username;
                configuration.SmtpServer.Password = model.Password;
                ConfigurationOperations.SaveChanges(configuration);
                return Ok("Configuração atualizada com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}