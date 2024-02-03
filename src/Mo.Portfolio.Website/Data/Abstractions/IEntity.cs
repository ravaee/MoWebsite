using System.ComponentModel.DataAnnotations;

namespace Mo.Portfolio.Website.Data.Abstractions;

public interface IEntity
{
    public Guid Id { get; set; }
}