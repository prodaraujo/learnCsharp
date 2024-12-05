using ModelsPessoa;
using ModelsDadosPessoa;
using ModelsMenu;
using System.Data.SQLite;

namespace cadastro;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ExibirMenu();
    }
}