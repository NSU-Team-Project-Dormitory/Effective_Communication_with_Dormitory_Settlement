using System.Collections.Generic;
using System.Data;
using Npgsql;

public sealed class Building5FirstFloorFactory
{
    private readonly CampusModel _model;

    public Building5FirstFloorFactory()
    {
    }

    public Building5FirstFloorFactory(CampusModel model)
    {
        _model = model;

        string connectionString = "Host=localhost;Username=ivan;Password=;Database=postgres";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            Console.WriteLine("Connected!");
            try
            {
                connection.Open();
                Console.WriteLine("Opened!");
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM rooms WHERE dorm_id = '5' AND floor_n = 1", connection))
                {
                    Console.WriteLine("Commanded!");
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Reader!");
                        while (reader.Read())
                        {
                            string roomId = reader.GetString(reader.GetOrdinal("room_id"));
                            int capacity = reader.GetInt32(reader.GetOrdinal("capacity"));

                            Console.WriteLine($"Room ID: {roomId}, Capacity: {capacity}");

                            Room room = new Room(_model, Guid.NewGuid(), roomId, capacity);
                            Console.WriteLine($"Created Room: {room}");
                            Console.WriteLine("Readed read");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IDK WHAT AN IDIOT MES IS: {ex.Message}");
            }


        }
    }

    public Floor Create()
    {
        return new Floor(_model, Guid.NewGuid(), "Этаж 1", new Dictionary<Guid, Room>());
    }
}
