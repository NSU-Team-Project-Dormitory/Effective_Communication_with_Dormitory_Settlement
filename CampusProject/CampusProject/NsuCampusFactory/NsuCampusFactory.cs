using Npgsql;

public sealed class NsuCampusFactory
{
    private readonly CampusModel _model;

    public NsuCampusFactory(CampusModel model)
    {
        _model = model;
    }

    public Campus Create()
    {
        Campus? campus = null;

        string connectionString = "Host=localhost;Username=ivan;Password=;Database=postgres";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                var buildingsFactory = new NsuBuildingsFactory(_model);
                campus = new Campus(_model, new Guid("{53545CD5-35B6-41D7-9BD9-D0228AA8511E}"),
                                    "НГУ", buildingsFactory.CreateBuildings(connection));

                connection.Close();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("SQL exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Other exception: " + ex.Message);
            }
        }
        

        return campus;
    }
}