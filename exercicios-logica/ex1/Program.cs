// See https://aka.ms/new-console-template for more information

Console.WriteLine("Digite um número:");

var number = int.Parse(Console.ReadLine());

Console.WriteLine(number % 2 == 0 ? "Par" : "Impar");
