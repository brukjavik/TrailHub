using TrailHub.Domain.Entities;
public class EditTrailUseCase
{
    private readonly ITrailRepository _repository;
    public EditTrailUseCase(ITrailRepository repository)
    {
        _repository = repository;
    }
    public async Task ExecuteAsync(EditTrailRequest request)
    {
        var id = await _repository.FindIdByName(request.Name);
        await _repository.EditAsync(id, request);
    }
}