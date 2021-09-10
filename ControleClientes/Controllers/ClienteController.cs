using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ControleClientes.Entities;
using ControleClientes.Services;

namespace ControleClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create(Cliente Cliente)
        {
            try
            {
                var ClienteService = new ClienteService();
                ClienteService.Create(Cliente);
                return Ok("Cliente cadastrado com sucesso.");

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Cliente Cliente)
        {
            try
            {
                var ClienteService = new ClienteService();
                ClienteService.Update(Cliente);
                return Ok("Cliente atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var ClienteService = new ClienteService();
                ClienteService.Delete(id);
                return Ok("Cliente excluido com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var ClienteService = new ClienteService();                
                return Ok(ClienteService.GetALL());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                var ClienteService = new ClienteService();                
                return Ok(ClienteService.GetByNome(nome));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

    }
}
