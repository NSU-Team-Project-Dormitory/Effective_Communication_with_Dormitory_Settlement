
using Npgsql;

public sealed class NsuBuildingsFactory
{
    private readonly CampusModel _model;

    public NsuBuildingsFactory(CampusModel model)
    {
        _model = model;
    }

    public IReadOnlyDictionary<Guid, Building> CreateBuildings(NpgsqlConnection connection)
    {
        var buildings = new Dictionary<Guid, Building>();
        List<string> builds = new List<string>();

        try
        {
            using (NpgsqlCommand command = new NpgsqlCommand("select dorm_id from dormitories order by dorm_id", connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        builds.Add(reader.GetString(reader.GetOrdinal("dorm_id")));
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("SQL exception in BuildingsFactory: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Other exception in BuildingsFactory: " + ex.Message);
        }

        foreach (string i in builds)
        {
            var unit = new BuildingFactory(_model).Create(i, connection);
            buildings.Add(unit.Id, unit);
        }

        return buildings;
    }
}