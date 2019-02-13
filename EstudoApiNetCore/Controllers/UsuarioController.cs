using EstudoApiNetCore.Models;
using EstudoApiNetCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstudoApiNetCore.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioModel usuario)
        {
            try
            {
                var service = new UsuarioService();
                UsuarioModel usuarioSalvo = await service.Salvar(usuario);
                return StatusCode(StatusCodes.Status201Created, usuarioSalvo.ID);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UsuarioModel usuario)
        {
            try
            {
                var service = new UsuarioService();
                UpdateResult resultadoUpdate = await service.Atualizar(id, usuario);

                if (resultadoUpdate.ModifiedCount > 0)
                    return StatusCode(StatusCodes.Status200OK, "Registro atualizado com sucesso");
                
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var service = new UsuarioService();
                DeleteResult resultadoExclusao = await service.Excluir(id);

                if (resultadoExclusao.DeletedCount > 0)
                    return StatusCode(StatusCodes.Status200OK, "Registro excluido com sucesso");

                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var service = new UsuarioService();
                IEnumerable<UsuarioModel> usuarios = await service.ListarUsuarios();

                return StatusCode(StatusCodes.Status200OK, usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var service = new UsuarioService();
                UsuarioModel usuario = await service.BuscarUsuario(id);

                if (usuario is null)
                    return NotFound();

                return StatusCode(StatusCodes.Status200OK, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex);
            }
        }
    }
}
