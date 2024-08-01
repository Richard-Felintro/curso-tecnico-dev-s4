using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1.Test
{
    public class RepositorioUnitTest
    {
        [Fact]
        public void AdicionarLivro()
        {
            var titulo = "titulo123";
            var autor = "autor456";
            var genero = "genero789";
            Livro livro = new()
            {
                Titulo = titulo,
                Autor = autor,
                Genero = genero
            };
            List<Livro> list = Repositorio.AdicionarLivro(livro);
            Assert.Contains(list, item => item.Titulo == titulo);
        }
    }
}
