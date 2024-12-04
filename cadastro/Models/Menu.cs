using ModelsPessoa;
using ModelsDadosPessoa;
using System.Data.SQLite;

namespace ModelsMenu;

public class Menu 
{
    // Conexão com o banco de dados SQLite
    string connectionString = "Data Source=cadastro.db;Version=3";

    using (var connection = new SQLiteConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Conexão estabelecida com sucesso!");
    }



    private List<DadosPessoa> pessoas = new List<DadosPessoa>();
    private int idPessoa = 1;
    
    public void ExibirMenu()
    {
        while (true)
        {
            Console.WriteLine("\n------- Menu -------\n");
            Console.WriteLine("1 - Adicionar pessoa");
            Console.WriteLine("2 - Exibir pessoas");
            Console.WriteLine("3 - Editar pessoa");
            Console.WriteLine("4 - Remover pessoa");
            Console.WriteLine("5 - Sair\n");
            Console.Write("Escolha uma opção: ");

            string? inputOption = Console.ReadLine();
            if (!int.TryParse(inputOption, out int option))
            {
                Console.WriteLine("\nOpção inválida!");
                continue;
            }

            switch (option)
            {
                case 1:
                    AdicionarPessoa();
                    break;
                case 2:
                    ExibirPessoa();
                    break;
                case 3:
                    EditarPessoa();
                    break;
                case 4:
                    RemoverPessoa();
                    break;    
                case 5:
                    Console.WriteLine("\nSaindo do programa...\n");
                    return;
                default:
                    Console.WriteLine("\nOpção inválida. Tente novamente.");
                    break;
            }
        }
    }            
    
    private void AdicionarPessoa() 
    {
        Console.Write("\nDigite o nome da pessoa: ");
        string? nomePessoa = Console.ReadLine();

        Console.Write("\nDigite o telefone: ");
        string? telefonePessoa = Console.ReadLine();

        Console.Write("\nDigite o e-mail: ");
        string? emailPessoa = Console.ReadLine();

        DadosPessoa pessoa = new DadosPessoa
        {
            id = idPessoa,
            nome = nomePessoa,
            telefone = telefonePessoa,
            email = emailPessoa
        };

        pessoas.Add(pessoa);
        idPessoa++;

        Console.WriteLine($"\n{nomePessoa} foi adionado(a) com sucesso!\n");
    }

    private void ExibirPessoa()    
    {
        if (pessoas.Count==0)
        {
            Console.WriteLine("\nNenhuma pessoa cadastrada!\n");
            return;
        }

        Console.WriteLine("\n--- Lista de nomes ---\n");
        
        foreach (DadosPessoa pessoa in pessoas)
        {
            Console.WriteLine($"Nome: {pessoa.nome} - ID: #{pessoa.id}\nTelefone: {pessoa.telefone}\nE-mail: {pessoa.email}\n");
        }
    }

    private void EditarPessoa()
    {
        Console.Write("\nInforme o ID da pessoa: ");
        string? inputID = Console.ReadLine();
        if (!int.TryParse(inputID, out int idPessoaConsulta))
        {
            Console.WriteLine("\nID inválido!");
            return;
        }

        DadosPessoa? pessoaEncontrada = null;

        foreach (DadosPessoa pessoa in pessoas)
        {
            if (pessoa.id == idPessoaConsulta)
            {
                pessoaEncontrada = pessoa;
                break; // Encerra o loop ao encontrar a pessoa
            }
        }

        if (pessoaEncontrada == null)
        {
            Console.WriteLine("\nPessoa não encontrada!\n");
            return;
        }

        Console.WriteLine($"\nPessoa encontrada: Nome: {pessoaEncontrada.nome}, ID: {pessoaEncontrada.id}\n");

        Console.WriteLine($"\nDeseja editar os dados de {pessoaEncontrada.nome} - ID: #{pessoaEncontrada.id}? (S/N)");
        string? editarOption = Console.ReadLine()?.ToUpper();

        if (editarOption != "S")
        {
            Console.WriteLine("\nEdição cancelada!");
            return;
        }

        // Editar o nome
        Console.WriteLine("\nQuer editar o nome? (S/N)");
        string? editarNome = Console.ReadLine()?.ToUpper();
        if (editarNome == "S")
        {
            Console.Write("\nDigite o novo nome: ");
            pessoaEncontrada.nome = Console.ReadLine();
        }

        // Editar o telefone
        Console.WriteLine("\nQuer editar o telefone? (S/N)");
        string? editarTelefone = Console.ReadLine()?.ToUpper();
        if (editarTelefone == "S")
        {
            Console.Write("\nDigite o novo telefone: ");
            pessoaEncontrada.telefone = Console.ReadLine();
        }

        // Editar o e-mail
        Console.WriteLine("\nQuer editar o e-mail? (S/N)");
        string? editarEmail = Console.ReadLine()?.ToUpper();
        if (editarEmail == "S")
        {
            Console.Write("\nDigite o novo e-mail: ");
            pessoaEncontrada.email = Console.ReadLine();
        }

        Console.WriteLine("\nEdição concluída com sucesso!\n");
    }

    public void RemoverPessoa()
    {
        Console.Write("\nInforme o ID da pessoa: ");
        string? inputID = Console.ReadLine();
        if (!int.TryParse(inputID, out int idPessoaConsulta))
        {
            Console.WriteLine("\nID inválido!");
            return;
        }

        DadosPessoa? pessoaEncontrada = null;

        foreach (DadosPessoa pessoa in pessoas)
        {
            if (pessoa.id == idPessoaConsulta)
            {
                pessoaEncontrada = pessoa;
                break; // Encerra o loop ao encontrar a pessoa
            }
        }

        if (pessoaEncontrada == null)
        {
            Console.WriteLine("\nPessoa não encontrada!\n");
            return;
        }

        Console.WriteLine($"\nPessoa encontrada: Nome: {pessoaEncontrada.nome}, ID: {pessoaEncontrada.id}\n");

        Console.WriteLine($"\nDeseja remover os dados de {pessoaEncontrada.nome} - ID: #{pessoaEncontrada.id}? (S/N)");
        string? removerOption = Console.ReadLine()?.ToUpper();

        if (removerOption != "S")
        {
            Console.WriteLine("\nRemoção cancelada!");
            return;
        }

        pessoas.Remove(pessoaEncontrada);

        Console.WriteLine($"\nPessoa removida com sucesso!\n");
    }
}