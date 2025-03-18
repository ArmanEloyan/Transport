using ConsoleApp13.Repos;
using ConsoleApp13.UI;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<City> citiesRepo = new RepositoryAdoNet<City>();
            IRepository<Car> carRepo = new RepositoryAdoNet<Car>();
            IRepository<Way> waysRepo = new RepositoryAdoNet<Way>();

            AdminPanel adminPanel = new AdminPanel(citiesRepo, carRepo,waysRepo);
            UserPanel userPanel = new UserPanel(citiesRepo, carRepo, waysRepo);
            MainUI ui = new MainUI(new AdminUI(adminPanel), new UserUI(userPanel));
            ui.MainMenuShow();
        }
    }
}
