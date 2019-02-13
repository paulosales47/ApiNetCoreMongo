using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudoApiNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EstudoApiNetCore.Service;
using MongoDB.Driver;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
                return Ok(usuarioSalvo.ID);

            }
            catch (Exception ex)
            {
                return StatusCode(417, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UsuarioModel usuario)
        {
            try
            {
                var service = new UsuarioService();
                UpdateResult resultadoUpdate = await service.Atualizar(id, usuario);

                return Ok(resultadoUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(417, ex);
            }
        }
    }
}
