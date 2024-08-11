// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string texto = Console.ReadLine();

Dictionary<char, int> contadores = new Dictionary<char, int>();

foreach (char letra in "abcdefghijklmnopqrstuvwxyz")
    {
        contadores[letra] = 0;
    }

foreach (char c in texto)
    {
        char letra = Char.ToLower(c);
        
        
        if (contadores.ContainsKey(letra))
        {
            contadores[letra]++;
        }
    }

foreach (KeyValuePair<char, int> item in contadores)
    {
        Console.WriteLine($"Letra '{item.Key}': {item.Value} vezes");
    }
