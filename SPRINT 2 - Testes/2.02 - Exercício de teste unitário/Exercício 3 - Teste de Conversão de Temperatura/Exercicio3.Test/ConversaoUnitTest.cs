using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3.Test
{
    public class ConversaoUnitTest
    {
        [Theory]
        [InlineData(17, 62.6)]
        [InlineData(23, 62.6)]
        [InlineData(400, 752)]
        public void ConverterCelsiusParaFahrenheit(double celsius, double expectedResult)
        {
            var fahrenheit = Conversao.ConverterCelsiusParaFahrenheit(celsius);
            Assert.Equal(fahrenheit, expectedResult);
        }
    }
}
