using Mo.Portfolio.Website.Data.Abstractions;
using Mo.Portfolio.Website.Types;

namespace Mo.Portfolio.Website.Data.Entities;

public class Group : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public GroupType GroupType { get; set; }
    public string Summery { get; set; } = string.Empty;
    public virtual ICollection<Post>? Posts { get; set; }
}