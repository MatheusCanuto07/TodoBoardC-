namespace TODO.Domain.Boards;

public interface IBoardRepository
{
	Task<Board?> FindByNameAsync(Name name, CancellationToken cancellationToken = default);
	Task<Board> Create(Board board, CancellationToken cancellationToken = default);
}
