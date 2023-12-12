using Npgsql;

public class FloorFactory
{
    private CampusModel model;

    public FloorFactory(CampusModel model)
	{
        this.model = model;
	}

    public Floor Create(int currFloor, string currDorm, NpgsqlConnection connection)
    {
        var rooms = new Dictionary<Guid, Room>();

        try
        {
            using (NpgsqlCommand command = new NpgsqlCommand($"select room_id, capacity from rooms where dorm_id = '{currDorm}' and floor_n = {currFloor} order by room_id", connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("room_id"));
                        int cap = reader.GetInt32(reader.GetOrdinal("capacity"));
                        Room room = new Room(model, Guid.NewGuid(), name, cap);
                        rooms.Add(room.Id, room);
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("SQL exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Other exception: " + ex.Message);
        }

        return new Floor(model, Guid.NewGuid(), currFloor, rooms);
    }
}

