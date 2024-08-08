Console.Clear();

Random random = new Random();
int tentativas = 0;
int numero;
int result = random.Next(1,100);
Console.WriteLine($"Tente adivinhar o número aleatório!");
do {
    numero = int.Parse(Console.ReadLine()!);
    tentativas++;
}
while(numero != result);
Console.WriteLine($"Você acertou em {tentativas} tentativas, o número era {result}!");
