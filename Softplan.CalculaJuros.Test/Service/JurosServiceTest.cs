using FluentAssertions;
using Softplan.CalculaJuros.Services.Abstract.Juros;
using Softplan.CalculaJuros.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Softplan.CalculaJuros.Test.Service
{
    public class JurosServiceTest : IClassFixture<WebHosterFixture>
    {
        private readonly IJurosService _jurosService;

        public JurosServiceTest(WebHosterFixture webHosterFixture)
        {
            this._jurosService = webHosterFixture.Services.GetService(typeof(IJurosService)) as IJurosService;
        }

        [Fact]
        public void Deve_Calcular_Juros()
        {
            //arange 
            var valorInicial = 100d;
            var meses = 5;

            //act
            var juros = _jurosService.CalcularJuros(valorInicial, meses);

            var expect = 105.10m;

            //assert
            juros.Should().Equals(expect);
        }

        [Fact]
        public void Deve_Calcular_Juros_Mes_Igual_Zero()
        {
            //arange 
            var valorInicial = 100d;
            var meses = 0;

            //act
            var juros = _jurosService.CalcularJuros(valorInicial, meses);

            var expect = 100d;

            //assert
            juros.Should().Equals(expect);
        }

    }
}
