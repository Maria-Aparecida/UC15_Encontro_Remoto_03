using ChapterFST1.Interfaces;
using ChapterFST1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterFST1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Listar usuário
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Buscar usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioEncontrado = _iUsuarioRepository.BuscarPorId(id);
                
                if(usuarioEncontrado == null)   
                    return NotFound();

                return Ok(usuarioEncontrado);
            }
            catch(Exception)
            {
                throw;

            }

        }

        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                
                _iUsuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Alterar usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Atualizar(id, usuario);
                return Ok("usuario Alterado");

            }catch (Exception) 
            {
                throw;
            }
        

        }

        /// <summary>
        /// deletar usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        
        public IActionResult Deletar(int id)
        {
            try
            {
                _iUsuarioRepository.Deletar(id);

                return Ok("Usuario Deletado");
            }
            catch (Exception)
            {
                throw;
            }
        }
     }
}
