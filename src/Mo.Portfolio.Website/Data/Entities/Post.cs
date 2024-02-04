using Mo.Portfolio.Website.Data.Abstractions;

namespace Mo.Portfolio.Website.Data.Entities;

public class Post : IEntity
{
    public Guid Id { get; set; }
    public string Body { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Summary { get; set; }  
    public string? ImageUrl { get; set; } 
    public Guid GroupId { get; set; }
    public DateTime CreateDate { get; set; }
    public virtual Group? Group { get; set; }
}