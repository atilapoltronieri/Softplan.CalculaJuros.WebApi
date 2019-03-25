using BoDi;
using FluentAssertions;
using Newtonsoft.Json;
using Softplan.CalculaJuros.Test.Base;
using Softplan.CalculaJuros.Test.Fixture;
using Softplan.CalculaJuros.Test.Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Softplan.CalculaJuros.Test.Cenarios.Steps
{
    [Binding]
    public  class JurosStep : CreateClient<IJurosRefit>, IClassFixture<WebHosterFixture>
    {
        public class ParametroDTO
        {
            public double ValorInicial { get; set; }
            public int Meses { get; set; }
        }
        public class Result
        {
            public decimal Juros { get; set; }
        } 

        public JurosStep(WebHosterFixture fixture, IObjectContainer objectContainer) : base(fixture, objectContainer)
        {

        }

        [Given(@"que o valor inicial é (.*)")]
        public void DadoQueOValorInicialE(double p0)
        {
            var a = p0;
            var parametros = new ParametroDTO { ValorInicial = p0 };
            ObjectContainer.RegisterInstanceAs(parametros);
        }

        [Given(@"que o valor do meses é (.*)")]
        public void DadoQueOValorDoMesesE(int p0)
        {
            var b = p0;
            var parametro = ObjectContainer.Resolve<ParametroDTO>();
            parametro.Meses = p0;
        }

        [When(@"chamar a api de calculo")]
        public async Task QuandoChamarAApiDeCalculo()
        {
            var a =  await FixureContext.Client.GetAsync("api/repositorio/link");
         
            var parametro = ObjectContainer.Resolve<ParametroDTO>();

            var result = await Context.CalcularJurosAsync(parametro.ValorInicial, parametro.Meses);
            result.EnsureSuccessStatusCode();
            var bodyReturn = await result.Content.ReadAsStringAsync();
            var resultDto = JsonConvert.DeserializeObject<decimal>(bodyReturn);

            ObjectContainer.RegisterInstanceAs(new Result { Juros = resultDto });

        }

        [Then(@"o valor calculado será (.*)")]
        public void EntaoOValorCalculadoSera(decimal p0)
        {
            var a = p0;
            a.Should().Equals(p0);
            var result = ObjectContainer.Resolve<Result>();

            result.Juros.Should().Equals(p0);
        }
     

    }
}
