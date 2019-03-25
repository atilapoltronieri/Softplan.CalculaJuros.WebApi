using Microsoft.AspNetCore.Mvc;
using Softplan.CalculaJuros.Services.Abstract.Juros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculaJuros.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;

        public JurosController(IJurosService jurosService)
        {
            this._jurosService = jurosService;
        }

        /// <summary>
        /// Serviço para calculo de juros composto
        /// </summary>
        /// <param name="valorInicial">Valor Inicial</param>
        /// <param name="meses">Periodo de tempo</param>
        /// <returns></returns>
        [HttpGet("calcular")]
        public IActionResult CalcularJuros([FromQuery(Name ="valor_inicial")]double valorInicial, [FromQuery(Name ="meses")]int meses)
        {
            return Ok(_jurosService.CalcularJuros(valorInicial, meses));
        }

    }
}
