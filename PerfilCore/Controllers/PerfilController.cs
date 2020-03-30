using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfilCore.Interfaces;
using PerfilCore.Models;

namespace PerfilCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IServicePerfil ServicoPerfil;

        public PerfilController(IServicePerfil servicoPerfil)
        {
            ServicoPerfil = servicoPerfil;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Add([FromBody]Perfil perfil)
        {
            await ServicoPerfil.SalvarPerfil(perfil);

            var p = new Perfil { DescricaoPerfil = perfil.DescricaoPerfil };
            return CreatedAtAction(nameof(Get),
                                    new
                                    {
                                        id = perfil.IdPerfil,
                                        p
                                    });

        }


        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetAll()
        {
            var resultado = await ServicoPerfil.GetAll<Perfil>();
            return resultado.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> Get(int id)
        {
            var resultado = await ServicoPerfil.Get<Perfil>(x => x.IdPerfil == id);

            if (resultado.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return resultado.FirstOrDefault();
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Update([FromBody]Perfil perfil)
        {
            var resultado = await ServicoPerfil.Get<Perfil>(x => x.IdPerfil == perfil.IdPerfil);

            if (resultado.FirstOrDefault() == null)
            {
                return NotFound();
            }

            try
            {
                var f = resultado.FirstOrDefault();
                if (f.ListaFuncionalidade != null)
                {
                    f.DescricaoPerfil = perfil.DescricaoPerfil;

                    foreach (var item in f.ListaFuncionalidade)
                    {
                        f.ListaFuncionalidade.Remove(item);
                    }

                    foreach (var item in perfil.ListaFuncionalidade)
                    {
                        f.ListaFuncionalidade.Add(item);
                    }
                }
                await ServicoPerfil.Update<Perfil>(f);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar " + ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultado = await ServicoPerfil.Get<Perfil>(x => x.IdPerfil == id);

            if (resultado == null)
            {
                return NotFound();
            }

            try
            {
                await ServicoPerfil.Remove<Perfil>(resultado.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao remover " + ex.Message);
            }

            return Ok();
        }
    }
}