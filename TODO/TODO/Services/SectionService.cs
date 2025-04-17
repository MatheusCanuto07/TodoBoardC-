using TODO.Domain.Boards;
using TODO.Domain.Section;
using TODO.Views.Boards;
using TODO.Views.Shared.Components.Section;

namespace TODO.Services;

public interface ISectionService
{
    Task<Board> CreateSection(SectionViewModel sectionViewModel);
}

public class SectionService : ISectionService
{
    private readonly ISectionRepository _sectionRepository;
    public SectionService(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }
    public Task<Board> CreateSection(SectionViewModel sectionViewModel)
    {
        throw new NotImplementedException();
    }
}
