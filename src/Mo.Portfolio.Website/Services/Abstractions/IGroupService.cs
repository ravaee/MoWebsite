using Mo.Portfolio.Website.Data.Entities;

namespace Mo.Portfolio.Website.Services.Abstractions;

public interface IGroupService
{
    Task Create(Group post);
    Task<Group?> Get(Guid id);
    Task<List<Group>> GetAll();
    Task<List<Group>> GetAllWithPosts();
    Task Delete(Guid id);
}