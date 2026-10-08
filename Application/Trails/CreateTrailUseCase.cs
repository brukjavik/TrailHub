using TrailHub.Domain.Entities;
public class CreateTrailUseCase
{
    private readonly ITrailRepository _repository;
    public CreateTrailUseCase(ITrailRepository repository)
    {
        _repository = repository;
    }
    public async Task<Trail> ExecuteAsync(CreateTrailRequest request)
    {
        int difficulty;
        if (request.Length <= 5) difficulty = 1;
        else if (request.Length <= 10) difficulty = 2;
        else difficulty = 3;

        var trail = new Trail
        {
            Length = request.Length,
            Description = request.Description,
            Name = request.Name,
            Difficulty = difficulty,
        };

        await _repository.AddAsync(trail);
        return trail;
    }
}