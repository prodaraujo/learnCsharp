using ModelsPessoa;
using ModelsDadosPessoa;
using ModelsMenu;

namespace cadastro;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ExibirMenu();
    }
}