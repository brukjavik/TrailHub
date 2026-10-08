using TrailHub.Domain.Entities;
public class DeleteTrailUseCase
{
    private readonly ITrailRepository _repository;
    public DeleteTrailUseCase(ITrailRepository repository)
    {
        _repository = repository;
    }
    public async Task ExecuteAsync(string name)
    {
        var id = await _repository.FindIdByName(name);
        await _repository.DeleteAsync(id);
    }
}