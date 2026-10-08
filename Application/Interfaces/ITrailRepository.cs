using TrailHub.Domain.Entities;

public interface ITrailRepository
{
    Task AddAsync(Trail trail);
    Task DeleteAsync(int id);
    Task<int> FindIdByName(string name);
    Task<Trail> FindAsync(string name);
    Task EditAsync(int id, EditTrailRequest request);
}