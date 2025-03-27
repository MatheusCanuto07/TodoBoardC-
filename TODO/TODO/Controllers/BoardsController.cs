using Microsoft.AspNetCore.Mvc;
using TODO.Domain.Boards;
using TODO.Services;
using TODO.Views.Boards;

namespace TODO.Controllers
{
    [Route("/")]
	public class BoardsController : Controller
    {
        private readonly IBoardsService _boardsService;
		public BoardsController(IBoardsService boardRepository)
		{
			_boardsService = boardRepository;
		}

		public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _boardsService.CreateBoard();

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
