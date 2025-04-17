using TODO.Domain.Boards;

namespace TODO.Domain.Section;

public interface ISectionRepository
{
    Task<Board?> FindByNameAsync(Name name, CancellationToken cancellationToken = default);
    Task<Board> Create(Board board, CancellationToken cancellationToken = default);
}
