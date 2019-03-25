using Microsoft.Extensions.Configuration;
using Softplan.CalculaJuros.Services.Abstract.VisualizarRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculaJuros.Services.Services
{
    public class VisualizarRepositorioService : IVisualizarRepositorioService
    {
        private IConfiguration _configuration;
        public VisualizarRepositorioService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string RetornarLinkRepositorio()
        {
            return _configuration.GetSection("UrlGitHub").Value;
        }
    }
}
