using Mo.Portfolio.Website.Data.Entities;

namespace Mo.Portfolio.Website.Services.Abstractions;

public interface IPostService
{
    Task<Guid> Create(Post post);
    Task<Post?> Get(Guid id);
    Task<List<Post>>  GetAll();
    Task<List<Post>> GetLastInGroup(int count, Guid groupId);
    Task<List<Post>> GetAllInGroup(Guid groupId);
}