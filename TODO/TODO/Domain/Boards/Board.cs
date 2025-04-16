using TODO.Domain.Common;

namespace TODO.Domain.Boards;

// Classe selada para não ser herdada e herda de Entity que tem os atributos compartilhados entre as entidades
public sealed class Board : Entity
{
	// Um board tem uma lista de BoardSections
	private readonly List<BoardSection> _sections = [];

	// A classe é construida por um metodo
	private Board(Name name, Description description)
	{
		Id = Guid.NewGuid();
		Name = name;
		Description = description;
	}

	// Atributos que vc pode ler e não pode editar
	public Name Name { get; private set; }
	public Description Description { get; private set; }
	// Lista somente de leitura, só é possível alterar essa lista usando o metodo AddSection
	public IReadOnlyList<BoardSection> Sections => _sections.AsReadOnly();

	public void AddSection(BoardSection section)
	{
		ArgumentNullException.ThrowIfNull(section);

		if (_sections.Any(innerSection => innerSection.Name == section.Name))
		{
			throw new ArgumentException($"Section with name '{section.Name}' already exists.");
		}

		_sections.Add(section);
	}

    // Metodo statico para criar um novo Board
    public static async Task<Board> CreateAsync(
        Name name,
        Description description,
        IBoardRepository repository,
        // Caso o usuário cancele a requisição (feche o navegador por exemplo)
        CancellationToken cancellationToken = default)
    {
        var exitstingBoard = await repository.FindByNameAsync(name, cancellationToken);

        if (exitstingBoard is not null)
        {
            throw new ArgumentException($"Board with name '{name}' already exists.");
        }

        var board = new Board(name, description);
        // Regra de negócio que um board precisa ter pelo menos uma seção
        var section = new BoardSection(new Name("Draft"));
        board.AddSection(section);

        return board;
    }
}