using Microsoft.EntityFrameworkCore;
using TrailHub.Domain.Entities;

namespace TrailHub.Infrastructure.Persistence.Repositories;

public class TrailRepository : ITrailRepository
{
    private readonly AppDbContext _context;
    public TrailRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> FindIdByName(string name)
    {
        Trail trail = await _context.Trails.FirstOrDefaultAsync(b => b.Name == name);
        return trail.Id;
    }

    public async Task<Trail> FindAsync(string name)
    {
        return await _context.Trails.FirstOrDefaultAsync(b => b.Name == name);
    }

    public async Task AddAsync(Trail trail)
    {
        await _context.Trails.AddAsync(trail);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var trail = await _context.Trails.FindAsync(id);
        _context.Trails.Remove(trail);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(int id, EditTrailRequest request)
    {
        var trail = await _context.Trails.FindAsync(id);
        await _context.Trails.Where(p => p.Id == id).ExecuteUpdateAsync(s => s
        .SetProperty(b => b.Description, b => request.Description)
        .SetProperty(b => b.Length, b => request.Length));
        await _context.SaveChangesAsync();
    }
}