using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Repos
{
    internal class RepositoryAdoNet<T> : IRepository<T> where T : class
    {
        private string cityDataName = "City";
        private string wayDataName = "Way";
        private string carDataName = "Cars";

        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=TransportDB;Integrated Security=True;Encrypt=False";

        public void Add(T value)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (value is City)
                    {
                        City city = Helper.ChangeType<City>(value);
                        command.CommandText = $"INSERT INTO {cityDataName} VALUES(@Name)";
                        command.Parameters.Add(new SqlParameter("@Name", city.Name));
                        command.ExecuteNonQuery();
                    }
                    else if (value is Way)
                    {
                        Way way = Helper.ChangeType<Way>(value);
                        command.CommandText = $"INSERT INTO {wayDataName} VALUES(@CityFromId, @CityToId, @StartPrice)";
                        command.Parameters.Add(new SqlParameter("@CityFromId", way.CityFrom.Id));
                        command.Parameters.Add(new SqlParameter("@CityToId", way.CityTo.Id));
                        command.Parameters.Add(new SqlParameter("@StartPrice", way.StartPrice));
                        command.ExecuteNonQuery();
                    }
                    else if (value is Car)
                    {
                        Car car = Helper.ChangeType<Car>(value);
                        command.CommandText = $"INSERT INTO {carDataName} VALUES(@Mark, @Model, @Year, @Coeffiecnt, @IsOperable, @Type)";
                        command.Parameters.Add(new SqlParameter("@Mark", car.Mark));
                        command.Parameters.Add(new SqlParameter("@Model", car.Model));
                        command.Parameters.Add(new SqlParameter("@Year", car.Year));
                        command.Parameters.Add(new SqlParameter("@Coeffiecnt", car.Coefficent));
                        command.Parameters.Add(new SqlParameter("@IsOperable", car.IsOperable));
                        command.Parameters.Add(new SqlParameter("@Type", car.Type));
                        command.ExecuteNonQuery();
                    }

                }
            }
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Add(value);
            }
        }

        public void Delete(T value)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    if (value is City)
                    {
                        City city = Helper.ChangeType<City>(value);
                        command.Connection = connection;
                        command.CommandText = $"DELETE FROM {wayDataName} WHERE CityFromId = @Id OR CityToId = @Id DELETE FROM {cityDataName} WHERE Id = @Id";
                        command.Parameters.Add(new SqlParameter("@Id", city.Id));
                        command.ExecuteNonQuery();
                    }
                    else if (value is Way)
                    {
                        Way way = Helper.ChangeType<Way>(value);
                        command.Connection = connection;
                        command.CommandText = $"DELETE FROM {wayDataName} WHERE Id = @Id";
                        command.Parameters.Add(new SqlParameter("@Id", way.Id));
                        command.ExecuteNonQuery();
                    }
                    else if (value is Car)
                    {
                        Car car = Helper.ChangeType<Car>(value);
                        command.Connection = connection;
                        command.CommandText = $"DELETE FROM {carDataName} WHERE Id = @Id";
                        command.Parameters.Add(new SqlParameter("@Id", car.Id));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public T Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (typeof(T) == typeof(City))
                    {
                        City city = GetCity(id);
                        T ent = Helper.ChangeType<T>(city);
                        return ent;
                    }
                    else if (typeof(T) == typeof(Way))
                    {
                        command.CommandText = $"SELECT TOP(1) * FROM {wayDataName} WHERE Id = @Id";
                        command.Parameters.Add(new SqlParameter("@Id", id));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Way way = new Way();
                                way.Id = id;
                                way.CityFrom = GetCity(int.Parse(reader["CityFromId"].ToString()));
                                way.CityTo = GetCity(int.Parse(reader["CityToId"].ToString()));
                                way.StartPrice = double.Parse(reader["StartPrice"].ToString());

                                T ent = Helper.ChangeType<T>(way);
                                return ent;
                            }
                        }
                    }
                    else if (typeof(T) == typeof(Car))
                    {
                        command.CommandText = $"SELECT top(1) * from {carDataName} WHERE Id = @Id";
                        command.Parameters.Add(new SqlParameter("@Id", id));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Car car = new Car();
                                car.Id = id;
                                car.Mark = reader["Mark"].ToString();
                                car.Model = reader["Model"].ToString();
                                car.Year = int.Parse(reader["Year"].ToString());
                                car.Coefficent = double.Parse(reader["Coeffiecnt"].ToString());
                                car.IsOperable = bool.Parse(reader["IsOperable"].ToString());
                                CarType type = (CarType)int.Parse(reader["Type"].ToString());
                                car.Type = type;

                                T ent = Helper.ChangeType<T>(car);
                                return ent;
                            }
                        }
                    }

                }
            }
            throw new Exception($"Cant find!");
        }

        public IEnumerable<T> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (typeof(T) == typeof(City))
                    {
                        List<T> cities = new List<T>();
                        command.CommandText = $"SELECT * FROM {cityDataName}";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                City city = new City();
                                city.Id = int.Parse(reader["Id"].ToString());
                                city.Name = reader["Name"].ToString();


                                T ent = Helper.ChangeType<T>(city);
                                cities.Add(ent);
                            }
                            return cities;
                        }
                    }
                    else if (typeof(T) == typeof(Way))
                    {
                        List<T> ways = new List<T>();
                        command.CommandText = $"SELECT * FROM {wayDataName}";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Way way = new Way();
                                way.Id = int.Parse(reader["Id"].ToString());
                                way.CityFrom = GetCity(int.Parse(reader["CityFromId"].ToString()));
                                way.CityTo = GetCity(int.Parse(reader["CityToId"].ToString()));
                                way.StartPrice = double.Parse(reader["StartPrice"].ToString());

                                T ent = Helper.ChangeType<T>(way);
                                ways.Add(ent);
                            }
                            return ways;
                        }
                    }
                    else if (typeof(T) == typeof(Car))
                    {
                        List<T> cars = new List<T>();
                        command.CommandText = $"select * from {carDataName}";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Car car = new Car();
                                car.Id = int.Parse(reader["Id"].ToString());
                                car.Mark = reader["Mark"].ToString();
                                car.Model = reader["Model"].ToString();
                                car.Year = int.Parse(reader["Year"].ToString());
                                car.Coefficent = double.Parse(reader["Coeffiecnt"].ToString());
                                car.IsOperable = bool.Parse(reader["IsOperable"].ToString());
                                CarType type = (CarType)int.Parse(reader["Type"].ToString());
                                car.Type = type;

                                T ent = Helper.ChangeType<T>(car);
                                cars.Add(ent);
                            }
                        }
                        return cars;
                    }

                }
            }
            throw new Exception($"Cant find!");
        }

        public void Update(int id, T newEntity)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (typeof(T) == typeof(City))
                    {
                        City city = Helper.ChangeType<City>(newEntity);
                        command.CommandText = $"UPDATE {cityDataName} set Name = @Name WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("@Id", id));
                        command.Parameters.Add(new SqlParameter("@Name", city.Name));
                        command.ExecuteNonQuery();
                    }
                    else if (typeof(T) == typeof(Way))
                    {
                        Way way = Helper.ChangeType<Way>(newEntity);
                        command.CommandText = $"UPDATE {cityDataName} set Name = @Name, CityFromId = @CityFromId, CityToId = @CityToId WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("@Id", id));
                        command.Parameters.Add(new SqlParameter("@CityFromId", way.CityFrom.Id));
                        command.Parameters.Add(new SqlParameter("@CityToId", way.CityTo.Id));
                        command.ExecuteNonQuery();
                    }
                    else if (typeof(T) == typeof(Car))
                    {
                        Car car = Helper.ChangeType<Car>(newEntity);
                        command.CommandText = @$"UPDATE {carDataName} SET
                                                 Mark = @Mark, Model = @Model, Year = @Year, Coeffiecnt = @Coeffiecnt, IsOperable = @IsOperable, Type = @Type
                                                 WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("@Id", id));
                        command.Parameters.Add(new SqlParameter("@Mark", car.Mark));
                        command.Parameters.Add(new SqlParameter("@Model", car.Model));
                        command.Parameters.Add(new SqlParameter("@Year", car.Year));
                        command.Parameters.Add(new SqlParameter("@Coeffiecnt", car.Coefficent));
                        command.Parameters.Add(new SqlParameter("@IsOperable", car.IsOperable));
                        command.Parameters.Add(new SqlParameter("@Type", car.Type));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private City GetCity(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"select top(1) * from {cityDataName} WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            City city = new City();
                            city.Id = id;
                            city.Name = reader["Name"].ToString();

                            return city;
                        }
                    }

                }
            }
            throw new Exception("Cant find City");
        }

    }
}
