namespace Domain.Primitives;

public interface IAuditableEntity
{
    DateTime CreatedOnUtC {  get; set; }
    DateTime? LastUpdatedOnUtC { get; set; }
}
