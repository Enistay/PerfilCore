using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfilCore.Interfaces;
using PerfilCore.Models;
using PerfilCore.Extensions;

namespace PerfilCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServiceCadastro ServicoCadastro;

        public UsuarioController(IServiceCadastro servicoCadastro)
        {
            ServicoCadastro = servicoCadastro;
        }

        /// <summary>
        ///  Action Add, Route Adicionar, de Usuario
        /// </summary>
        /// <param name="usuario">objeto para cadastro</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Add([FromBody]Usuario usuario)
        {
            usuario.Senha = StringExtension.CreateMD5(usuario.Senha);
            usuario.Ativo = true;
            usuario.Cadastro = DateTime.Now;

            await ServicoCadastro.Add<Usuario>(usuario);

            return CreatedAtAction(nameof(Get),
                                   new
                                   {
                                       id = usuario.IdUsuario
                                   });

        }

        /// <summary>
        ///  Listar 
        /// </summary>
        /// <returns>IEnumerable do objeto Usuario</returns>
        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var resultado = await ServicoCadastro.GetAll<Usuario>();
            return resultado.ToList();
        }


        /// <summary>
        /// Obter por Id paramentro passando na rota do verbo
        /// </summary>
        /// <param name="id">identificador do objeto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var resultado = await ServicoCadastro.Get<Usuario>(x => x.IdUsuario == id);

            if (resultado.FirstOrDefault() == null)
            {
                return NotFound();
            }

            var usuario = resultado.FirstOrDefault();
            var perfis = await ServicoCadastro.Get<UsuarioPerfil>(x => x.IdUsuario == usuario.IdUsuario);
            if(perfis != null)
            foreach (var item in perfis)
            {
                    usuario.ListaUsuarioPerfil.Add(item);
            }

            return usuario;
        }

        /// <summary>
        /// Atualizar 
        /// </summary>
        /// <param name="Usuario">Objeto</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Update([FromBody]Usuario usuario)
        {
            var resultado = await ServicoCadastro.Get<Usuario>(x => x.IdUsuario == usuario.IdUsuario);

            if (resultado.FirstOrDefault() == null)
            {
                return NotFound();
            }

            try
            {
                var u = resultado.FirstOrDefault();
               
                await ServicoCadastro.Update<Usuario>(u);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar " + ex.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Remove passando paramentro id pela rota
        /// </summary>
        /// <param name="id">identificado do objeto</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var resultado = await ServicoCadastro.Get<Usuario>(x => x.IdUsuario == id);

            if (resultado == null)
            {
                return NotFound();
            }

            try
            {
                await ServicoCadastro.Remove<Usuario>(resultado.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao remover " + ex.Message);
            }

            return Ok();
        }
    }
}