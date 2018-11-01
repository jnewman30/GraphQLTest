namespace DataLib.Model
{
    public interface IDataAdapter
    {
        int Id { get; set; }

        int AdapterTypeId { get; set; }

        string Name { get; set; }

        string Endpoint { get; set; }

        string Metadata { get; set; }

        bool IsRowActive { get; set; }

        DataAdapterType AdapterType { get; set; }
    }
}