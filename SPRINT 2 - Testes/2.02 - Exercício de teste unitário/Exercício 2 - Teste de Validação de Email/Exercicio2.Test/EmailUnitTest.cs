using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.Test
{
    public class EmailUnitTest
    {
        [Fact]
        public void ChecarFormatoEmail()
        {
            var email = "richardfsdfsfdds.com";
            var resultado = Email.ChecarEmail(email);
            var resultadoEsperado = false;
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
