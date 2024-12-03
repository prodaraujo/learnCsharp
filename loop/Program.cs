using System.Runtime.InteropServices.Marshalling;

namespace loops;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();
        int counter = 1;

        while(counter<6){
            numeros.Add(counter);
            counter++;
        }

        do
        {
            numeros.Add(counter);
            counter++;
        } while (counter<10);

        
        for (counter = 10; counter < 16; counter++)
        {
            numeros.Add(counter);
        }

        Console.WriteLine("--- Lista de números ---");

        foreach(int numero in numeros) {
            Console.WriteLine($"Número: {numero}");
        }
    }
}