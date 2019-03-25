using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalculaJuros.Test.Refit
{
    public interface IJurosRefit
    {
        [Get("/api/juros/calcular?valor_inicial={valorInicial}&meses={meses}")]
        Task<HttpResponseMessage> CalcularJurosAsync(
            [AliasAs("valorInicial")] double valorInicial, [AliasAs("meses")] int meses);


    }

}
