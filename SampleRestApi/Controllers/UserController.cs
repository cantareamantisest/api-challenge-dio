using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Data;
using SampleRestApi.Models;
using SampleRestApi.Service.Interfaces;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserController(IMapper mapper, AppDbContext context, IEmailService emailService)
        {
            _mapper = mapper;
            _context = context;
            _emailService = emailService;
        }

        /// <summary>
        /// Obter uma lista dos usuários
        /// </summary>
        /// <remarks>
        /// Obtém uma lista com todos os usuários cadastrados
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">
        /// Success
        /// </response>
        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAsync()
        {
            var users = await _context.Users
                .Include(c => c.Account)
                .Include(c => c.Card)
                .Include(c => c.Features)
                .Include(c => c.News)
                .AsNoTracking()
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(users));
        }

        /// <summary>
        /// Obter uma lista dos usuários por sobrenome com limite
        /// </summary>
        /// <remarks>
        /// Obtém uma lista com filtro baseado no sobrenome dos usuários cadastrados
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">
        /// Success
        /// </response>
        //[HttpGet]
        //[Route("users")]
        //public async Task<ActionResult<IEnumerable<UserViewModel>>> GetByLastnameAsync([FromRoute] string lastName, [FromRoute] int limit = 5)
        //{
        //    var users = await _context.Users
        //        .Include(c => c.Account)
        //        .Include(c => c.Card)
        //        .Include(c => c.Features)
        //        .Include(c => c.News)
        //        .AsNoTracking()
        //        .Where(c => c.LastName == lastName)
        //        .ToListAsync();
        //    return Ok(_mapper.Map<IEnumerable<UserViewModel>>(users));
        //}

        /// <summary>
        /// Obter um usuário pelo Id
        /// </summary>
        /// <remarks>
        /// Obtém um usuário de acordo com o Id fornecido.
        /// </remarks>
        /// <returns name="model">
        /// Retorna os dados do usuário desejado caso esteja cadastrado
        /// </returns>
        /// <response code="200">
        /// Success
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        [HttpGet]
        [Route("users/{id}")]
        public async Task<ActionResult<UserViewModel>> GetByIdAsync([FromRoute] long id)
        {
            var user = await _context.Users
                .Include(c => c.Account)
                .Include(c => c.Card)
                .Include(c => c.Features)
                .Include(c => c.News)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.IdUser == id);
            return user == null ? NotFound() : Ok(_mapper.Map<UserViewModel>(user));
        }

        /// <summary>
        /// Adicionar um usuário
        /// </summary>
        /// <remarks>
        /// Adiciona um usuário de acordo com o modelo fornecido. Observação: Os objetos 'News' e 'Features' não são requeridos.
        /// </remarks>
        /// <returns name="model">
        /// Retorna o usuário recém adicionado
        /// </returns>
        /// <response code="201">
        /// Success
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> PostAsync([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                var userAdded = await _context.Users.AddAsync(_mapper.Map<User>(model));
                await _context.SaveChangesAsync();
                return Created($"v1/users/{userAdded.Entity.IdUser}", userAdded.Entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Atualizar um usuário
        /// </summary>
        /// <remarks>
        /// Atualiza um usuário de acordo com o modelo fornecido. Observação: Os objetos 'News' e 'Features' não são requeridos.
        /// </remarks>
        /// <returns name="model">
        /// Retorna o usuário recém atualizado
        /// </returns>
        /// <response code="200">
        /// Success
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        [HttpPut]
        [Route("users/{id}")]
        public async Task<IActionResult> PutAsync([FromBody] UserViewModel model, [FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var user = await _context.Users
                .Include(c => c.Account)
                .Include(c => c.Card)
                .Include(c => c.Features)
                .Include(c => c.News)
                .FirstOrDefaultAsync(c => c.IdUser == id);

            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Account.Number = model.Account.Number;
                user.Account.Agency = model.Account.Agency;
                user.Account.Balance = model.Account.Balance;
                user.Account.Limit = model.Account.Limit;
                if (model.Features.Count > 0)
                {
                    var features = _mapper.Map<List<Features>>(model.Features);
                    user.Features.AddRange(features);
                }
                if (model.News.Count > 0)
                {
                    var news = _mapper.Map<List<News>>(model.News);
                    foreach (var item in model.News)
                    {
                        var email = new EmailViewModel { To = model.Email, Subject = "Tenho uma ótima noticia pra você", Body = item.Description };
                        _emailService.SendEmail(email);
                    }
                    user.News.AddRange(news);
                }

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Excluir um usuário
        /// </summary>
        /// <remarks>
        /// Exclui um usuário e seus respectivos relacionamento em função do Id fornecido
        /// </remarks>
        /// <response code="204">
        /// User deleted successful!
        /// </response>
        /// <response code="400">
        /// Bad Request
        /// </response>
        [HttpDelete]
        [Route("users/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Users.Remove(user);
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