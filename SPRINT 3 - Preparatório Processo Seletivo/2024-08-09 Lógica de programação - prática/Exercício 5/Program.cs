using Exercício_5;

//* Eu não sabia que podia pesquisar então fiz desse jeito ;-;

List<Letra> quantidadeLetras = new List<Letra>(){
        new Letra(){
        letra = 'A',
        quantidade = 0,
    },
        new Letra(){
        letra = 'B',
        quantidade = 0,
    },
        new Letra(){
        letra = 'C',
        quantidade = 0,
    },
        new Letra(){
        letra = 'D',
        quantidade = 0,
    },
        new Letra(){
        letra = 'E',
        quantidade = 0,
    },
        new Letra(){
        letra = 'F',
        quantidade = 0,
    },
        new Letra(){
        letra = 'G',
        quantidade = 0,
    },
        new Letra(){
        letra = 'H',
        quantidade = 0,
    },
        new Letra(){
        letra = 'I',
        quantidade = 0,
    },
        new Letra(){
        letra = 'J',
        quantidade = 0,
    },
        new Letra(){
        letra = 'K',
        quantidade = 0,
    },
        new Letra(){
        letra = 'L',
        quantidade = 0,
    },
        new Letra(){
        letra = 'M',
        quantidade = 0,
    },
        new Letra(){
        letra = 'N',
        quantidade = 0,
    },
        new Letra(){
        letra = 'O',
        quantidade = 0,
    },
        new Letra(){
        letra = 'P',
        quantidade = 0,
    },
        new Letra(){
        letra = 'Q',
        quantidade = 0,
    },
        new Letra(){
        letra = 'R',
        quantidade = 0,
    },
        new Letra(){
        letra = 'S',
        quantidade = 0,
    },
        new Letra(){
        letra = 'T',
        quantidade = 0,
    },
        new Letra(){
        letra = 'U',
        quantidade = 0,
    },
        new Letra(){
        letra = 'V',
        quantidade = 0,
    },
        new Letra(){
        letra = 'W',
        quantidade = 0,
    },
        new Letra(){
        letra = 'X',
        quantidade = 0,
    },
        new Letra(){
        letra = 'Y',
        quantidade = 0,
    },
        new Letra(){
        letra = 'Z',
        quantidade = 0,
    },
};
//* Eu não sabia que podia pesquisar então fiz desse jeito ;-;

Console.Clear();
Console.Write($"Escreva um texto: ");
string texto = Console.ReadLine()!;
char[] list = texto.ToUpper().ToCharArray();
foreach (var item in list)
{
    for (var i = 0; i < 26; i++)
    {
        if (item == quantidadeLetras[i].letra)
        {
            quantidadeLetras[i].quantidade++;
            i = 26;
        }
    }
}

Console.WriteLine();
Console.WriteLine($"LETRA | QUANTIDADE");
Console.WriteLine($"------+-----------");

foreach (var item in quantidadeLetras)
{
    Console.WriteLine($"{item.letra}     | {item.quantidade}");
}