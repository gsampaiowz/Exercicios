// See https://aka.ms/new-console-template for more information
Console.WriteLine("Digite 5 nomes:");

string[] nomes = new string[5];

for (int i = 0; i < nomes.Length; i++)
{
    nomes[i] = Console.ReadLine();
}

Array.Sort(nomes);

Console.WriteLine("Nomes digitados:");

foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}
