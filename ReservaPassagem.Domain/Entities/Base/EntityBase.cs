namespace ReservaPassagem.Domain.Entities.Base;

public abstract class EntityBase
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; private set; } = null;
}