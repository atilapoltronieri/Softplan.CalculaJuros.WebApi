

Sistema para cálculo de Juros.

O sistema conta com duas ações: Realizar cálculo de Juros (/api/Juros/calcular) e enviar o Caminho do Github que contem o código da Aplicação (/api/repositorio/link).

-Docker

-Documentação Swagger

-Teste Unitarios xUnit.

-Teste Integração com Specflow

## Softplan.CalculaJuros

Sistema para cálculo de Juros.



## Architecture

 Onion Architecture
 
Batizado por Jeffrey Pallermo de “Onion Architecture” (Arquitetura-Cebola), uma camada é cliente dos serviços da camada imediatamente mais interna a ela, isto é, as dependências seguem sempre de fora para dentro.
![Architecture](https://i0.wp.com/jeffreypalermo.com/wp-content/uploads/2018/06/image257b0257d255b59255d.png?zoom=1.25&resize=366%2C259&ssl=1) 

https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/

## Start project
- Clone this repository `git clone https://github.com/atilapoltronieri/Softplan.CalculaJuros.WebApi.git`
- Install all dependencies `Asp.net Core 2.2`
- Start dev server `dotnet run`
-Start docker `docker run Softplan.CalculaJuros.WebApi`

