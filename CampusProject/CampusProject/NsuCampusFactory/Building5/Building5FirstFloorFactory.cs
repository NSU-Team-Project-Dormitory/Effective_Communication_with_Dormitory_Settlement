using Npgsql;

public sealed class Building5FirstFloorFactory
{
    private readonly CampusModel _model;

    public Building5FirstFloorFactory(CampusModel model)
    {
        _model = model;

        string connectionString = "Host=localhost;Username=elizavetazhitnik;Password=;Database=University";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM rooms WHERE dorm_id = 5 AND floor_n = 1", connection))
            {
                try
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string roomId = reader.GetString(0);
                            int capacity = reader.GetInt32(1);

                            Room room = new Room(_model, Guid.NewGuid(), roomId, capacity);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"IDIOT! Error reading data: {ex.Message}");
                }
            }
        }
    }

    public Floor Create()
    {
        return new Floor(_model, new Guid("{DD656AAB-EFC8-4E35-947B-89284E781A6B}"), "Этаж 1", new Dictionary<Guid, Room>());
    }
}
