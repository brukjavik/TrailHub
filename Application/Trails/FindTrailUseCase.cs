using TrailHub.Domain.Entities;
public class FindTrailUseCase
{
    private readonly ITrailRepository _repository;
    public FindTrailUseCase(ITrailRepository repository)
    {
        _repository = repository;
    }
    public async Task<Trail> ExecuteAsync(string name)
    {
        return await _repository.FindAsync(name);
    }
}