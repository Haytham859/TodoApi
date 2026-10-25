namespace Todo.Infrastructure.Persistence.Entities;

public abstract class BaseAuditableEntity:BaseEntity
{
    public DateTime CreatedOn { get; set; } 
    public DateTime? ModifiedOn { get; set; }
}