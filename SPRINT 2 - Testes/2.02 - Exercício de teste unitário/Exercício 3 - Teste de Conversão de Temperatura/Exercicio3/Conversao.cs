using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3
{
    public static class Conversao
    {
        public static double ConverterCelsiusParaFahrenheit(double celsius)
        {
            var step1 = celsius * 9 / 5;
            var fahrenheit = Math.Round(step1 + 32, 1);
            return fahrenheit;  
        }
    }
}
