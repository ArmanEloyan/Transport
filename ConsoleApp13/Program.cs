using ConsoleApp13.Entities;
using ConsoleApp13.Models;
using ConsoleApp13.Repos;
using ConsoleApp13.UI;

namespace ConsoleApp13
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new Client();

            string Url = "https://localhost:7204"; // ✅ проверь порт в Swagger/в браузере

            // ✅ Получение города
            //string getCityUrl = $"{baseUrl}/city/getbyid?id=1";
            //var city = await client.GetRequest<City>(getCityUrl);
            //Console.WriteLine($"City: {city.Name}");


            //string getAllCityUrl = $"{baseUrl}/city/getall";
            //var cities = await client.GetRequest<IEnumerable<City>>(getAllCityUrl);

            //foreach (var c in cities)
            //{
            //    Console.WriteLine($"City: {c.Name}");
            //}

            //IRepository<City, int> cityRepo1 = new Repository<City, int>(client, $"https://localhost:7204/city");

            //await cityRepo1.AddAsync(new City(){Name = "dd22d" });

            //   Console.WriteLine(city.DisplayInfo());
            // Console.WriteLine($"City: {city.Name}");
            DataContext dataContext = new DataContext();


            IRepository<City, int> citiesRepo = new Repository<City, int>(client, $"{Url}/city");
            IRepository<Car, int> carRepo = new Repository<Car, int>(client, $"{Url}/car");
            IRepository<Way, int> waysRepo = new Repository<Way, int>(client, $"{Url}/way");
            IRepository<Order, int> orderRepo = new Repository<Order, int>(client, $"{Url}/order");
            IRepository<CarType, int> carTypeRepo = new Repository<CarType, int>(client, $"{Url}/cartype");
            TransportCompanyOrderSystem orderSystem = new TransportCompanyOrderSystem(orderRepo);

            AdminPanel adminPanel = new AdminPanel(citiesRepo, carRepo, waysRepo, orderRepo, carTypeRepo);
            UserPanel userPanel = new UserPanel(citiesRepo, carRepo, waysRepo, orderRepo);
            MainUI ui = new MainUI(new AdminUI(adminPanel), new UserUI(userPanel, orderSystem));
            await ui.MainMenuShow();
        }
    }
}