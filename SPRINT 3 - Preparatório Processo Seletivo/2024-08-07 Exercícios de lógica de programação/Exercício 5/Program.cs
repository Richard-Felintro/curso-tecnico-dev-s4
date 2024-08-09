using Exercício_5;
Aluno joao = new Aluno()
{
    nome = "João",
    notaMatematica = 5.9,
    notaPortugues = 7.5,
    notaBiologia = 4.3,
};

Aluno pedro = new Aluno()
{
    nome = "Pedro",
    notaMatematica = 8.5,
    notaPortugues = 9.5,
    notaBiologia = 7.4,
};

List<Aluno> list = [joao, pedro];

foreach (Aluno item in list)
{
    double soma = item.notaMatematica + item.notaPortugues + item.notaBiologia;
    double media = soma / 3;
    if (media >= 7)
    {
        Console.WriteLine($"O aluno {item.nome} passou com uma média de {media}");
    }
    else
    {
        Console.WriteLine($"O aluno {item.nome} reprovou com uma média de {media}");
    }

}
Console.WriteLine($"");


// List<Array> alunos = new List<Array>();
// foreach (nota in aluno)