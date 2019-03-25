using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculaJuros.Services.Abstract.Juros
{
    public interface IJurosService
    {
        decimal CalcularJuros(double valorInicial, int meses);
    }
}
