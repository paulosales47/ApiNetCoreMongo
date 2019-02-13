using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudoApiNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EstudoApiNetCore.Service;

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
                await service.Salvar(usuario);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(417, ex);
            }
        }
    }
}
