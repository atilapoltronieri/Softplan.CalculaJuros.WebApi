using BoDi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Softplan.CalculaJuros.Test.Fixture;
using Softplan.CalculaJuros.Test.Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculaJuros.Test.Base
{
    public class CreateClient<TApiClient> where TApiClient : class
    {
        public TApiClient Context { get; }
        public WebHosterFixture FixureContext { get; }
        protected IObjectContainer ObjectContainer { get; set; }

        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public CreateClient(WebHosterFixture fixture, IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
            FixureContext = fixture;
            Context = RestService.For<TApiClient>(fixture.Client, new RefitSettings
            {
                JsonSerializerSettings = _settings
            });
        }


    }
}
