using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        [Fact]
        public void SomarDoisNumeros()
        {
            var n1 = 3.3;
            var n2 = 2.2;
            var valorEsperado = 5.6;

            var Soma = Calculo.Somar(n1, n2);
            Assert.Equal(valorEsperado, Soma);
        }
        [Fact]
        public void SubtrairDoisNumeros()
        {
            var n1 = 5;
            var n2 = 3.2;
            var valorEsperado = 1.8;

            var Resultado = Calculo.Subtrair(n1, n2);
            Assert.Equal(valorEsperado, Resultado);
        }
        [Fact]
        public void MultiplicarDoisNumeros()
        {
            var n1 = 3;
            var n2 = 2.5;
            var valorEsperado = 7.5;

            var Resultado = Calculo.Multiplicar(n1, n2);
            Assert.Equal(valorEsperado, Resultado);
        }
        [Fact]
        public void DividirDoisNumeros()
        {
            var n1 = 6;
            var n2 = 2;
            var valorEsperado = 4;

            var Resultado = Calculo.Dividir(n1, n2);
            Assert.Equal(valorEsperado, Resultado);
        }
    }
}
