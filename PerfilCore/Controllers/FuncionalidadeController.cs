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
    /// <summary>
    /// Classe Controlo Funcionalidade
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionalidadeController : ControllerBase
    {
        private readonly IServiceCadastro ServicoCadastro;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="servicoCadastro">Servico de Cadastro Genérico</param>
        public FuncionalidadeController(IServiceCadastro servicoCadastro)
        {
            ServicoCadastro = servicoCadastro;
        }

        /// <summary>
        ///  Action Add, Route Adicionar, de funcionalidade
        /// </summary>
        /// <param name="funcionalidade">objeto para cadastro</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Add([FromBody]Funcionalidade funcionalidade)
        {
            await ServicoCadastro.Add<Funcionalidade>(funcionalidade);

            return CreatedAtAction(nameof(Get), 
                                   new { id = funcionalidade.IdFuncionalidade,
                                       funcionalidade
                                   });

        }

        /// <summary>
        ///  Listar 
        /// </summary>
        /// <returns>IEnumerable do objeto Funcionalidade</returns>
        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Funcionalidade>>> GetAll()
        {
            var resultado = await ServicoCadastro.GetAll<Funcionalidade>();
            return resultado.ToList();
        }


        /// <summary>
        /// Obter por Id paramentro passando na rota do verbo
        /// </summary>
        /// <param name="id">identificador do objeto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionalidade>> Get(int id)
        {
            var resultado = await ServicoCadastro.Get<Funcionalidade>( x=> x.IdFuncionalidade == id);

            if (resultado.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return resultado.FirstOrDefault();
        }

        /// <summary>
        /// Atualizar 
        /// </summary>
        /// <param name="funcionalidade">Objeto</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Update([FromBody]Funcionalidade funcionalidade)
        {
            var resultado = await ServicoCadastro.Get<Funcionalidade>(x => x.IdFuncionalidade == funcionalidade.IdFuncionalidade);

            if (resultado.FirstOrDefault() == null)
            {
                return NotFound();
            }

            try
            {
                var f = resultado.FirstOrDefault();
                f.DescricaoFuncao = funcionalidade.DescricaoFuncao;
                await ServicoCadastro.Update<Funcionalidade>(f);
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
            var resultado = await ServicoCadastro.Get<Funcionalidade>(x => x.IdFuncionalidade == id);

            if (resultado == null)
            {
                return NotFound();
            }

            try
            {
                await ServicoCadastro.Remove<Funcionalidade>(resultado.FirstOrDefault());
            }
            catch (Exception ex)
            {                     
                return BadRequest("Erro ao remover " + ex.Message);
            }

            return Ok();
        }
    }
}