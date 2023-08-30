using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult get(string email, string senha)
        {

            try
            {
                //faz chamada para o metodo cadastrar
                UsuarioDomain usuarioDomain = _UsuarioRepository.Login(email, senha);

                //retorna um statusCode
                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);

            }


        }
    }
}
