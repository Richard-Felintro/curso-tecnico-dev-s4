using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public static class Repositorio
    {
        public static List<Livro> AdicionarLivro(Livro livro)
        {
            List<Livro> list = new();
            list.Add(livro);
            return (list);
        }
    }
}
