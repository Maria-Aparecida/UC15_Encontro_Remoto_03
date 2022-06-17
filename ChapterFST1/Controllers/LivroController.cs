using ChapterFST1.Models;
using ChapterFST1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterFST1.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize(Roles = "1")]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        /// <summary>
        /// Listar livros cadastrados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
               return Ok(_livroRepository.Listar());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Busca um livro por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livro = _livroRepository.BuscarPorId(id);
                
                if(livro == null)
                {
                    return NotFound();

                }
                return Ok(livro);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra um livro.
        /// </summary>
        /// <param name="livro"></param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);
                return StatusCode(201);

            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza um livro.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="livro"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga um livro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return StatusCode(204);
        
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
