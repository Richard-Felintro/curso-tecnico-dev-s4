void Tabuada(double numero){
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"{numero} x {i} = {numero*i}");
    }
}
Console.Clear();
Console.Write($"Informe um número: ");
Tabuada(double.Parse(Console.ReadLine()!));
