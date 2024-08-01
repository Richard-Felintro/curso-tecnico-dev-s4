using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    public static class Inventario
    {
        public static List<Produto> AdicionarProduto(string productName, List<Produto> list)
        {
            Produto? p = list.Find(x => x.Nome == productName);
            if (p == null)
            {
                Produto? newProd = new Produto
                {
                    Nome = productName,
                    Quantidade = 1,
                };
                list.Add(newProd);
                return list;
            }
            else
            {
                p.Quantidade++;
                return list;
            }
        }
    }
}
