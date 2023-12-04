using System.Collections.Generic;
using System.Data;
using AppTransport.Models;
using MySqlConnector;

namespace AppTransport;

public class DB
{
    
    private MySqlConnectionStringBuilder _connectionString { get; }

    public DB()
    {
        _connectionString = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "prodgect2",
            UserID = "root",
            Password = "123456"

        };
    }

    public List<Address> GetAllAddress()
    {
        List<Address> addresses = new List<Address>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM address";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    addresses.Add(new Address(
                        reader.GetInt32("Id"),
                        reader.GetString("NameCity"),
                        reader.GetString("Street"),
                        reader.GetInt32("NumberHouse")));
                }

            }
            conn.Close();
        }

        return addresses;
    }
    public List<Marks> GetAllMarks()
    {
        List<Marks> marks = new List<Marks>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM marks";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    marks.Add(new Marks(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }

            }
            conn.Close();
        }

        return marks;
    }

    public Marks GetMarkById(int id)
    {
        Marks mark = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM marks " +
                                  "WHERE Id = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mark = new Marks(id, 
                        reader.GetString("Name"));
                }

            }
            conn.Close();
        }

        return mark;
    }
    public Workers GetWorkerById(int id)
    {
        Workers worker = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM workers " +
                                  "WHERE Id = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    worker = new Workers(reader.GetInt32("Id"),
                        reader.GetString("Name"),
                        reader.GetString("SecondName"),
                        reader.GetString("LastName"));
                }

            }
            conn.Close();
        }

        return worker;
    }
    public Clients GetClientById(int id)
    {
        Clients client = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM clients " +
                                  "WHERE Id = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client = new Clients(reader.GetInt32("Id"),
                        reader.GetString("Name"),
                        reader.GetString("SecondName"),
                        reader.GetString("LastName"));
                }

            }
            conn.Close();
        }

        return client;
    }

    public Cars GetCarById(int id)
    {
        Cars car = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM cars " +
                                  "WHERE Id = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Marks curentMark = GetMarkById(
                        reader.GetInt32("Mark"));
                    car = new Cars(
                        reader.GetInt32("Id"),
                        curentMark,
                        reader.GetString("Color"),
                        reader.GetString("Number"),
                        reader.GetBoolean("IsRepair"));
                }

            }
            conn.Close();
        }
        return car;
    }

    public Address GetAddressById(int id)
    {
        Address address = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM address " +
                                  "WHERE Id = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    address = new Address(
                        reader.GetInt32("Id"),
                        reader.GetString("NameCity"),
                        reader.GetString("Street"),
                        reader.GetInt32("NumberHouse"));
                }

            }
            conn.Close();
        }
        return address;
    }
    public List<Cars> GetAllCars()
    {
        List<Cars> cars = new List<Cars>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM cars";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Marks curentMark = GetMarkById(reader.GetInt32("Mark"));
                    cars.Add(new Cars(
                        reader.GetInt32("Id"),
                        curentMark,
                        reader.GetString("Color"),
                        reader.GetString("Number"),
                        reader.GetBoolean("IsRepair")));
                }

            }
            conn.Close();
        }
        return cars;
    }

    public List<Clients> GetAllClients()
    {
        List<Clients> clients = new List<Clients>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM clients";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   clients.Add(new Clients(reader.GetInt32("Id"),
                       reader.GetString("Name"),
                       reader.GetString("SecondName"),
                       reader.GetString("LastName")));
                }

            }
            conn.Close();
        }

        return clients;
    }
    public List<Workers> GetAllWorkers()
    {
        List<Workers> workers = new List<Workers>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM workers";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    workers.Add(new Workers(reader.GetInt32("Id"),
                        reader.GetString("Name"),
                        reader.GetString("SecondName"),
                        reader.GetString("LastName")));
                }

            }
            conn.Close();
        }

        return workers;
    }

    public List<Order> GetAllOrders()
    {
        List<Order> orders = new List<Order>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM orders";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var curentWorker = GetWorkerById(reader.GetInt32("Worker"));
                    var curentCar = GetCarById(reader.GetInt32("Car"));
                    var curentAddress = GetAddressById(reader.GetInt32("Addresslocated"));
                    var curentClinet = GetClientById(reader.GetInt32("ClientID"));
                    orders.Add(new Order(reader.GetInt32("Id"),
                        curentWorker,
                        curentCar,
                        curentAddress,
                        reader.GetDateTime("DateArrivals"),
                        reader.GetDouble("price"),
                        curentClinet));
                }

            }
            conn.Close();
        }

        return orders;
    }

}