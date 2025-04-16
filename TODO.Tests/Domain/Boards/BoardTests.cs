using Moq;
using TODO.Domain.Boards;
using TODO.Repositories;

namespace TODO.Tests.Domain.Boards;

public class BoardTests
{
    private readonly Mock<IBoardRepository> _boardRepository = new();

    [Fact]
    public async Task CreateAsync_WhenValid_ShouldReturnBoard()
    {
        //Arrage        
        _boardRepository
            .Setup(repo => repo.FindByNameAsync(It.IsAny<Name>(), CancellationToken.None))
            .ReturnsAsync((Board?)null);

        Name name = new("test name");
        Description description = new("test Description");

        //Act
        var board = await Board.CreateAsync(
            name,
            description,
            _boardRepository.Object,
            CancellationToken.None);


        //Assert

        Assert.NotNull(board);
        Assert.Equal(name.Value, board.Name.Value);
        Assert.Equal(description.Value, board.Description.Value);
        Assert.NotEmpty(board.Sections);
    }

    [Fact]
    public async Task CreateAsync_WhenExistsOneBoardValid_ShouldReturnBoard()
    {
        //Arrage        
        _boardRepository
            .Setup(repo => repo.FindByNameAsync(It.IsAny<Name>(), CancellationToken.None))
            .ReturnsAsync((Board?)null);

        Name name = new("test name");
        Description description = new("test Description");

        var board = await Board.CreateAsync(
            name,
            description,
            _boardRepository.Object,
            CancellationToken.None);

        _boardRepository
            .Setup(repo => repo.FindByNameAsync(It.IsAny<Name>(), CancellationToken.None))
            .ReturnsAsync(board);

        //Assert
        await Assert.ThrowsAsync<System.ArgumentException>(async () =>
        {
            //Act
            var result = await Board.CreateAsync(
                            name,
                            description,
                            _boardRepository.Object,
                            CancellationToken.None);
        });
    }
}
