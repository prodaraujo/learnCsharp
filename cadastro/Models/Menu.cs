using ModelsPessoa;
using ModelsDadosPessoa;
using System.Data.SQLite;

namespace ModelsMenu;

public class Menu 
{
    // Conexão com o banco de dados SQLite
    string connectionString = "Data Source=cadastro.db;Version=3";

    public void DbConnection()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS cadastro (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Telefone TEXT,
                Email TEXT
            );";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
    
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
    
    public void AdicionarPessoa() 
    {
        DbConnection();

        Console.Write("\nDigite o nome da pessoa: ");
        string nomePessoa = Console.ReadLine();
        nomePessoa ??="Nome Desconhecido";

        Console.Write("\nDigite o telefone: ");
        string telefonePessoa = Console.ReadLine();
        telefonePessoa ??="Telefone Desconhecido";

        Console.Write("\nDigite o e-mail: ");
        string emailPessoa = Console.ReadLine();
        emailPessoa ??="E-mail Desconhecido";

        DadosPessoa pessoa = new DadosPessoa
        {
            nome = nomePessoa,
            telefone = telefonePessoa,
            email = emailPessoa
        };

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO cadastro (Nome, Telefone, Email) VALUES (@Nome, @Telefone, @Email)";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nome", nomePessoa);
                command.Parameters.AddWithValue("@Telefone", telefonePessoa);
                command.Parameters.AddWithValue("@Email", emailPessoa);
                command.ExecuteNonQuery();
                Console.WriteLine($"\n{nomePessoa} cadastrado(a) com sucesso!");
            }
        }        
    } 

    public void ExibirPessoa()    
    {
        DbConnection();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM cadastro";

            using (var command = new SQLiteCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNenhuma pessoa cadastrada!\n");
                        return;
                    }

                    Console.WriteLine("\n--- Lista de Pessoas ---\n");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Nome: {reader["Nome"]} - ID: #{reader["Id"]}\nTelefone: {reader["Telefone"]}\nE-mail: {reader["Email"]}\n");
                    }
                }
            }   
        }
    }

    public void EditarPessoa()
    {
        DbConnection();

        Console.Write("\nInforme o ID da pessoa: ");
        string? inputID = Console.ReadLine();
        if (!int.TryParse(inputID, out int idPessoaConsulta))
        {
            Console.WriteLine("\nID inválido!");
            return;
        }

        Console.Write("\nDigite o novo nome: ");
        string? novoNomePessoa = Console.ReadLine();

        Console.Write("\nDigite o novo telefone: ");
        string? novoTelefonePessoa = Console.ReadLine();

        Console.Write("\nDigite o novo e-mail: ");
        string? novoEmailPessoa = Console.ReadLine();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "UPDATE cadastro SET Nome = @Nome, Telefone = @Telefone, Email = @Email WHERE Id = @Id";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", idPessoaConsulta);
                command.Parameters.AddWithValue("@Nome", novoNomePessoa);
                command.Parameters.AddWithValue("@Telefone", novoTelefonePessoa);
                command.Parameters.AddWithValue("@Email", novoEmailPessoa);
                command.ExecuteNonQuery();

                Console.WriteLine("\nEdição concluída com sucesso!\n");
            }
        }
    }

    public void RemoverPessoa()
    {
        DbConnection();

        Console.Write("\nInforme o ID da pessoa que deseja remover: ");
        string? inputID = Console.ReadLine();

        if (!int.TryParse(inputID, out int idPessoaConsulta))
        {
            Console.WriteLine("\nID inválido!");
            return;
        }

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "DELETE FROM cadastro WHERE Id = @Id";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", idPessoaConsulta);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("\nPessoa removida com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nID não encontrado!");
                }
            }
        }
    }
}