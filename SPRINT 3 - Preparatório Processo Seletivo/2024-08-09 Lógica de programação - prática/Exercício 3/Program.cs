Console.Clear();
List<double> list = [5.5,8,100,555,245,938,846.76,5,-9,-50];
double soma = 0;
for (int i = 0; i < 10; i++)
{
    if(list[i] % 2 == 0){
        soma += list[i];
    }
}
Console.WriteLine(soma);
