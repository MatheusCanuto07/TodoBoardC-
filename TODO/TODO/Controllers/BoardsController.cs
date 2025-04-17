using Microsoft.AspNetCore.Mvc;
using TODO.Domain.Boards;
using TODO.Services;
using TODO.Views.Boards;
using TODO.Views.Shared.Components.Card;
using TODO.Views.Shared.Components.Section;

namespace TODO.Controllers;

[Route("/")]
public class BoardsController : Controller
{
    private readonly IBoardsService _boardsService;
    private readonly List<Board> _repo = [];

    public BoardsController(IBoardsService boardRepository)
    {
        _boardsService = boardRepository;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            Board? board = null;
            BoardViewModel b = new BoardViewModel("Fazer dashboard", "Tela Relatorio: ");
               
            // Se o repo não tiver nenhum board, cria um
            if (!_repo.Any())
            {
                board = await _boardsService.CreateBoard(b);
                _repo.Add(board);
            }
            else
            {
                board = _repo.FirstOrDefault();
            }

            // Cria a estrutura que o front-end precisa inicializar
            var model = new BoardViewModel
            {
                // Atributos board
                Id = board!.Id,
                Name = board.Name.ToString(),
                Description = board.Description.ToString(),
                // Pode ter 1 ou mais sections
                Sections = board.Sections.Select(s => new SectionViewModel
                {
                    Id = s.Id,
                    Title = s.Name.ToString(),
                    // Cada section tem 0 ou mais cards
                    Cards = s.Cards.Select(c => new CardViewModel
                    {
                        Id = c.Id,
                        Title = c.Name.ToString()
                    }).ToList()
                }).ToList()
            };

            return View("Index", model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View("Index");
        }
    }

    [Route("createsection")]
    [HttpPost]
    public async Task<IActionResult> CreateSection(SectionViewModel section)
    {
        try
        {
            // Implementar o create e o update
            // Ele vai na pasta que tem o nome da controller procurar pela view que tem esse nome

            //var board = await _boardsService.CreateBoard(boardViewModel);

            return View("Index");
        }
        catch (Exception ex) {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View("Index");
        }
    }
}
