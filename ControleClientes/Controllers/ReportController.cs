using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleClientes.Services;
using ControleClientes.Entities;

namespace ControleClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {       

        [HttpGet]        
        public IActionResult GetReport()
        {
            try
            {
                var ReportService = new ReportService();
                return Ok(ReportService.CreateReport());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
