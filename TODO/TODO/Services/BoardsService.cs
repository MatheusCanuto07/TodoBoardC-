using TODO.Domain.Boards;
using TODO.Views.Boards;

namespace TODO.Services;

public interface IBoardsService
{
	Task<Board> CreateBoard(BoardViewModel boardViewModel);
}

public class BoardsService : IBoardsService
{
	private readonly IBoardRepository _boardRepository;

	public BoardsService(IBoardRepository boardRepository)
	{
		_boardRepository = boardRepository;
	}

	public async Task<Board> CreateBoard(BoardViewModel boardViewModel)
	{
		var name = new Name(boardViewModel.Name);
		var desc = new Description(boardViewModel.Description);
		var board = await Board.CreateAsync(name, desc, _boardRepository);

		return board;
	}
}
