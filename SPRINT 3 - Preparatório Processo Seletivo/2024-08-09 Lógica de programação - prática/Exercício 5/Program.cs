using Exercício_5;

List<Letra> quantidadeLetras = new List<Letra>();
char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
for (var i = 0; i < 26; i++)
{
    quantidadeLetras.Add(new Letra()
    {
        letra = alfabeto[i],
    });
}

Console.Clear();
Console.Write($"Escreva um texto: ");
string texto = Console.ReadLine()!;
char[] list = texto.ToUpper().ToCharArray();

foreach (var item in quantidadeLetras)
{
    item.quantidade += list.Count(x => x == item.letra);
}

Console.WriteLine($"\nLETRA | QUANTIDADE\n------+-----------");
foreach (var item in quantidadeLetras)
{
    Console.WriteLine($"{item.letra}     | {item.quantidade}");
}