// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] numbers = new int[] { 2, 3, 5, 6, 9, 7};

int somaDosPares = 0;

foreach(int num in numbers){
    if(num % 2 == 0){
        somaDosPares += num;
    }
}

Console.WriteLine(somaDosPares);