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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }

        public EstudioController() 
        {
            _EstudioRepository = new EstudioRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get() 
        {
            try
            {
                List<EstudioDomain> estudios = _EstudioRepository.ListarTodos();
                return Ok(estudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(EstudioDomain NovoFilme)
        {
            try
            {
                _EstudioRepository.Cadastrar(NovoFilme);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
