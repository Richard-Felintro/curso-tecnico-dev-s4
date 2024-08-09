Console.Clear();
List<string> list = new();
for (int i = 0; i < 5; i++)
{
    Console.Write($"Cadastre um nome [{i+1}/5] : ");
    list.Add(Console.ReadLine()!);
}
list.Sort();
foreach (var item in list)
{
    Console.WriteLine(item);
}
