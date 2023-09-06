using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogoController() 
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get() 
        {
            try
            {
                List<JogoDomain> jogos = _JogoRepository.ListarTodos();
                return Ok(jogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain NovoJogo)
        {
            try
            {
                _JogoRepository.Cadastrar(NovoJogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
