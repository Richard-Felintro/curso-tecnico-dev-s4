Console.Clear();
Console.WriteLine("Informe a nota do aluno");
switch (float.Parse(Console.ReadLine()!)){
    case >= 7:
    Console.WriteLine("Aluno aprovado.");
    break;
        case >= 5:
        Console.WriteLine("Aluno em recuperação.");
    break;
        default:
        Console.WriteLine("Aluno reprovado.");
    break;
}