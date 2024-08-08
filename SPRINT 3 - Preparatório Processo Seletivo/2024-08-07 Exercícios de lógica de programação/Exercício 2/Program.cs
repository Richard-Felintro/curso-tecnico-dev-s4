Console.Clear();
Console.WriteLine($"Gerador de tabuada");
Console.Write($"Insira um número: ");
int numero = int.Parse(Console.ReadLine()!);
for(int x = 0; x <= 10; x++){
    Console.WriteLine($"{numero} * {x} = {numero*x}");
}