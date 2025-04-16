namespace TODO.Domain.Common;

public abstract class Entity
{
	public Guid Id { get; set; }

	public List<IDomainEvent> DomainEvents { get; set; }
}

public interface IDomainEvent;
