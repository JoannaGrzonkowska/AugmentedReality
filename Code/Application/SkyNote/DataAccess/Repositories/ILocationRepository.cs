namespace DataAccess.Repositories
{
    public interface ILocationRepository : IRepositoryBase<location>
    {
        location GetByCord(decimal xCord, decimal yCord);
    }
}
