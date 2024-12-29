namespace calculadora;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ExibirMenu();
    }

    public class Menu{
        public void ExibirMenu()
        {
            Calc calc = new Calc();
            

            while (true)
            {
                Console.WriteLine("\n_____Menu_____\n");
                Console.WriteLine("1 - Somar");
                Console.WriteLine("2 - Subtrair");
                Console.WriteLine("3 - Sair\n");

                Console.Write("Escolha uma opção: ");
                string? inputOption = Console.ReadLine();
                if(!int.TryParse(inputOption, out int option)){
                    Console.WriteLine("");
                    continue;
                }

                switch (option)
                {
                    case 1: 
                        calc.Somar();
                        break;
                    case 2:
                        calc.Subtrair();
                        break;
                    case 3: 
                        Console.WriteLine("\nSaindo do programa...\n");
                        return;
                    default: 
                        Console.WriteLine("\nOpção inválida. Tente novamente");
                        break;
                }
            }
        }
    }
    
    public class Calc
    {
        public void Somar()
        {
            Console.Write("\nEscreva um número: ");
            string? inputN1 = Console.ReadLine();
            if(!int.TryParse(inputN1, out int n1)){
                Console.WriteLine("\nOpção inválida!");
            }
            Console.Write("\nEscreva outro número: ");
            string? inputN2 = Console.ReadLine();
            if(!int.TryParse(inputN2, out int n2)){
                Console.WriteLine("\nOpção inválida!");
            }
            
            int resultado = n1 + n2;
            Console.WriteLine($"\nO resultado da soma é {resultado}");

        }

        public void Subtrair()
        {
            Console.Write("\nEscreva um número: ");
            string? inputN1 = Console.ReadLine();
            if(!int.TryParse(inputN1, out int n1)){
                Console.WriteLine("\nOpção inválida!");
            }
            Console.Write("\nEscreva outro número: ");
            string? inputN2 = Console.ReadLine();
            if(!int.TryParse(inputN2, out int n2)){
                Console.WriteLine("\nOpção inválida!");
            }
            
            int resultado = n1 - n2;
            Console.WriteLine($"\nO resultado da subtração é {resultado}");
        }
    }
    public void Somar()
    {
        Console.Write("\nEscreva um número: ");
        string? inputN1 = Console.ReadLine();
        if(!int.TryParse(inputN1, out int n1)){
            Console.WriteLine("\nOpção inválida!");
        }
        Console.Write("\nEscreva outro número: ");
        string? inputN2 = Console.ReadLine();
        if(!int.TryParse(inputN2, out int n2)){
            Console.WriteLine("\nOpção inválida!");
        }
        
        int resultado = n1 + n2;
        Console.WriteLine($"\nO resultado da soma é {resultado}");

    }

        public void Subtrair()
    {
        Console.Write("\nEscreva um número: ");
        string? inputN1 = Console.ReadLine();
        if(!int.TryParse(inputN1, out int n1)){
            Console.WriteLine("\nOpção inválida!");
        }
        Console.Write("\nEscreva outro número: ");
        string? inputN2 = Console.ReadLine();
        if(!int.TryParse(inputN2, out int n2)){
            Console.WriteLine("\nOpção inválida!");
        }
        
        int resultado = n1 - n2;
        Console.WriteLine($"\nO resultado da subtração é {resultado}");
    }
}