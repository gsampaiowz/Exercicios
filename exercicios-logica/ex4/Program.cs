// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string Tabuada(int num) {

    string tabuada = "";

    for (int i = 1; i <= 10; i++) {
        tabuada += $"{num} x {i} = {num * i}\n";
    }

    return tabuada;
}

Console.WriteLine(Tabuada(2));