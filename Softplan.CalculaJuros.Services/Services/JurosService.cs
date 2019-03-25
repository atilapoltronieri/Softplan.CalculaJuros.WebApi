using Microsoft.Extensions.Configuration;
using Softplan.CalculaJuros.Services.Abstract.Juros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculaJuros.Services.Services
{
    public class JurosService : IJurosService
    {
        private IConfiguration _configuration;
        public JurosService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public decimal CalcularJuros(double valorInicial, int meses)
        {
            var multiplicador = meses == 0 ? 1 : Math.Pow((1 + 0.01D), meses);
         
            return Convert.ToDecimal(String.Format("{0:N}", valorInicial * multiplicador));
        }

        public string Showmethecode()
        {
            return _configuration.GetSection("UrlGitHub").Value;
        }
    }
}
