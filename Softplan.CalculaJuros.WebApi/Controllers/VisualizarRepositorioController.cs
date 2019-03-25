using Microsoft.AspNetCore.Mvc;
using Softplan.CalculaJuros.Services.Abstract.Juros;
using Softplan.CalculaJuros.Services.Abstract.VisualizarRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculaJuros.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VisualizarRepositorioController : ControllerBase
    {
        private readonly IVisualizarRepositorioService _visualizarRepositoryService;

        public VisualizarRepositorioController(IVisualizarRepositorioService visualizarRepositoryService)
        {
            this._visualizarRepositoryService = visualizarRepositoryService;
        }

        /// <summary>
        /// Serviço que forneçe url do projeto no gitHub
        /// </summary>
        /// <returns></returns>
        [HttpGet("repositorio/link")] 
        public ActionResult<string> RetornarLinkRepositorio() 
        {
            return _visualizarRepositoryService.RetornarLinkRepositorio();
        }
    }
}
