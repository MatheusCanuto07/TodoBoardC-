using TODO.Domain.Boards;

namespace TODO.Repositories;

public class BoardRepository : IBoardRepository
{
    public Task<Board?> FindByNameAsync(Name name, CancellationToken cancellationToken = default)
	{
		// Ele vai no banco para procurar um board ou retornar null e retorna efetivamente null
		return Task.FromResult<Board?>(null);
	}
    public Task<Board> Create(Board board, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
