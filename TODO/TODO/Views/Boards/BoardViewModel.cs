using TODO.Views.Shared.Components.Section;

namespace TODO.Views.Boards;

public class BoardViewModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public List<SectionViewModel> Sections { get; set; } = [];
	public BoardViewModel(string nameP, string descriptionP)
	{
		Name = nameP;
        Description = descriptionP;
	}
	public BoardViewModel() { }
}
