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
        public IActionResult Get(string email, string senha)
        {
            try
            {
                // Faz chamada para o método de login
                UsuarioDomain usuarioDomain = _UsuarioRepository.Login(email, senha);

                if (usuarioDomain != null)
                {
                    // Login aprovado, você pode retornar um resultado com informações do usuário
                    return Ok(usuarioDomain);
                }
                else
                {
                    // Login falhou, retorna um status Unauthorized (401)
                    return Unauthorized();
                }
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }
    }
}
