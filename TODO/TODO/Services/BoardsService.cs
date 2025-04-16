using TODO.Domain.Boards;

namespace TODO.Services;

public interface IBoardsService
{
	Task<Board> CreateBoard();
}

public class BoardsService : IBoardsService
{
	private readonly IBoardRepository _boardRepository;

	public BoardsService(IBoardRepository boardRepository)
	{
		_boardRepository = boardRepository;
	}


	public async Task<Board> CreateBoard()
	{
		var name = new Name("Board 1");
		var desc = new Description("Board 1 desc");
		var board = await Board.CreateAsync(name, desc, _boardRepository);

		return board;
	}
}
