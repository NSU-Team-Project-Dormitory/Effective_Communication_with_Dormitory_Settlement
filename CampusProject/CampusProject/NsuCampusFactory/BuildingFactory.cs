
using Npgsql;

public sealed class BuildingFactory
{
    private CampusModel model;

    public BuildingFactory(CampusModel model)
    {
        this.model = model;
    }

    public Building Create(string buildName, NpgsqlConnection connection)
    {
        var floors = new Dictionary<Guid, Floor>();

        List<int> floorList = new List<int>();

        try
        {
            using (NpgsqlCommand command = new NpgsqlCommand($"select floor_id from floors where dorm_id = '{buildName}' order by floor_id", connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        floorList.Add(reader.GetInt32(reader.GetOrdinal("floor_id")));
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

        foreach (int i in floorList)
        {
            Floor f = new FloorFactory(model).Create(i, buildName, connection);
            floors.Add(f.Id, f);
        }

        var building = new Building(model, Guid.NewGuid(), buildName, floors);

        return building;
    }
}