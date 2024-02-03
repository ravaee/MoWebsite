using Mo.Portfolio.Website.Data.Abstractions;
using Mo.Portfolio.Website.Types;

namespace Mo.Portfolio.Website.Data.Entities;

public class Group : IEntity
{
    public Guid Id { get; set; }
    public GroupType GroupType { get; set; }
    public virtual ICollection<Post>? Posts { get; set; }
}