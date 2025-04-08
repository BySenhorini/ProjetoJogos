using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Jogos.Domains;
using Projeto_Jogos.Interfaces;

namespace Projeto_Jogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {
        private readonly IJogosRepository _jogosRepository;
        public JogosController(IJogosRepository jogosRepository)
        {
            _jogosRepository = jogosRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar os jogos
        /// </summary>
        [HttpPost]
        public IActionResult Post(Jogos jogos)
        {
            try
            {
                _jogosRepository.Cadastrar(jogos);
                return StatusCode(201, jogos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar os jogos
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar os jogos
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogos jogos)
        {
            try
            {
                _jogosRepository.Atualizar(id, jogos);

                return StatusCode(204, jogos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um jogo por id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_jogosRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar os jogos
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogosRepository.Listar());

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}