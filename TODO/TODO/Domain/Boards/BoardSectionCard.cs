using TODO.Domain.Common;

namespace TODO.Domain.Boards;

public sealed class BoardSectionCard : Entity
{
	public Name Name { get; set; }
	public Description Description { get; set; }
}
