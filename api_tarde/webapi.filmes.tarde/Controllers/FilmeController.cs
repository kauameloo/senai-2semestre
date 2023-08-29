using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private IFilmeRepository _FilmeRepository { get; set; }


        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> filmes = _FilmeRepository.ListarTodos();
                return Ok(filmes);
            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                throw;
            }



        }



        [HttpPost]
        public IActionResult post(FilmeDomain NovoFilme)
        {

            try
            {
                _FilmeRepository.Cadastrar(NovoFilme);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }


        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _FilmeRepository.Deletar(Id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }


        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                FilmeDomain filmeDomain = _FilmeRepository.BuscarPorId(Id);

                if (filmeDomain == null)
                {
                    return NotFound("O filme buscado não foi encontrado");
                }

                return Ok(filmeDomain);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult PutUrl(int Id, FilmeDomain Filme)
        {
            try
            {
                _FilmeRepository.AtualizarIdURL(Id, Filme);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpPut]
        public IActionResult PutId(FilmeDomain filme)
        {
            try
            {
                _FilmeRepository.AtualizarIdCorpo(filme);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
