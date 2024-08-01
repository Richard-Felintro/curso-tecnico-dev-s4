namespace Exercicio4.Test
{
    public class InventarioUnitTest
    {
        [Fact]
        public void AdicionarProduto()
        {
            var quantidadeEsperadaMaca = 2;
            var quantidadeEsperadaBanana = 1;
            List<Produto> list = new();
            list = Inventario.AdicionarProduto("Maçã", list);
            list = Inventario.AdicionarProduto("Maçã", list);
            list = Inventario.AdicionarProduto("Banana", list);
            Assert.Single(list.Where(x => x.Nome.Equals("Maçã") && x.Quantidade == quantidadeEsperadaMaca));
            Assert.Single(list.Where(x => x.Nome.Equals("Banana") && x.Quantidade == quantidadeEsperadaBanana));
        }
    }
}