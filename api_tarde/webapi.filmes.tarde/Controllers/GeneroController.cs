using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _generoRepository para que haja referência aos metodos do repositório
        /// </summary>
        public GeneroController() 
        { 
            _generoRepository= new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();

                return Ok(listaGenero);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
