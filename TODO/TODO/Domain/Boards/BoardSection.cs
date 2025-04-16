using TODO.Domain.Common;

namespace TODO.Domain.Boards;

public sealed class BoardSection : Entity
{
	public Name Name { get; private set; }
	public BoardSection(Name name)
	{
		Id= Guid.NewGuid();
		Name = name;
	}
	
	private readonly List<BoardSectionCard> _cards = [];
	public IReadOnlyList<BoardSectionCard> Cards => _cards.AsReadOnly();
}
