using Microsoft.AspNetCore.Mvc;
using TODO.Domain.Boards;
using TODO.Views.Boards;

namespace TODO.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardRepository _boardRepository;
		public BoardsController(IBoardRepository boardRepository)
		{
			_boardRepository = boardRepository;
		}

		public async Task<IActionResult> Index()
        {
            try
            {
                var name = new Name("Board 1");
                var desc = new Description("Board 1 desc");
                var board = await Board.CreateAsync(name, desc, _boardRepository);

                var model = new BoardViewModel
                {
					Id = board.Id,
                    Name = board.Name.ToString(),
					Description = board.Description.ToString(),
                    Sections = board.Sections.Select(s => new BoardSectionViewModel 
                        { 
							Id = s.Id,
                            Name = s.Name.ToString(), 
                            Cards = s.Cards.Select(c => new BoardSectionCardViewModel 
                            { 
                                Id = c.Id,
                                Name = c.Name.ToString() 
                            })
                            .ToList()
                        })
                    .ToList()
				};
                

                return View("Index", model);
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index");
            }                        
        }
    }
}
