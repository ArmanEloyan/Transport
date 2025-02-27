using ConsoleApp13.UI;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdminPanel adminPanel = new AdminPanel();
            UserPanel userPanel = new UserPanel();
            MainUI ui = new MainUI(new AdminUI(adminPanel), new UserUI(userPanel));
            ui.MainMenuShow();
        }
    }
}
