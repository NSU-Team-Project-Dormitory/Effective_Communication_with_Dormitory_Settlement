using System.Collections.ObjectModel;

public sealed class NsuBuildingsFactory
{
    private readonly CampusModel _model;

    public NsuBuildingsFactory(CampusModel model)
    {
        _model = model;
    }

    public IReadOnlyDictionary<Guid, Building> CreateBuildings()
    {
        var buildings = new Dictionary<Guid, Building>();
        var hostel5 = new Building5Factory(_model).Create();

        buildings.Add(hostel5.Id, hostel5);

        return buildings;
    }
}