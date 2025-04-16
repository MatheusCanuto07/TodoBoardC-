using TODO.Views.Shared.Components.Card;

namespace TODO.Views.Shared.Components.Section;

public class SectionViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<CardViewModel> Cards { get; set; } = [];
}
