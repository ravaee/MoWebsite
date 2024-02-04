using Microsoft.EntityFrameworkCore;
using Mo.Portfolio.Website.Data;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Services;
public class GroupService(ApplicationDbContext context) : IGroupService
{
    public async Task Create(Group group)
    {
        await context.Groups.AddAsync(group);
        
        await context.SaveChangesAsync();
    }

    public async Task<Group?> Get(Guid id)
    {
        var group = await context.Groups.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        return group;
    }

    public async Task<List<Group>> GetAll()
    {
        List<Group> groups = await context.Groups.AsNoTracking().ToListAsync();
        
        return groups;
    }
    
    public async Task<List<Group>> GetAllWithPosts()
    {
        List<Group> groups = await context.Groups
            .Where(p=> p.Posts.Count > 0)
            .AsNoTracking()
            .ToListAsync();
        
        return groups;
    }

    public async Task Delete(Guid id)
    {
        var group = await context.Groups.FirstOrDefaultAsync(p => p.Id == id);

        if (group is null)
            return;

        context.Groups.Remove(group);

        await context.SaveChangesAsync();
    }
}