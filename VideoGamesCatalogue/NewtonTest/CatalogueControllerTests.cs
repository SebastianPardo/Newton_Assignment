using Microsoft.AspNetCore.Mvc;
using Moq;
using NewtonServices.Bussines.Interfaces;
using NewtonServices.Controllers;
using NewtonServices.Models.Entities;
using VideoGame = NewtonServices.Models.ApiModels.VideoGame;
using NewtonServices.Models.Views;

public class CatalogueControllerTests
{
    private readonly Mock<IVideoGamesService> _videoGamesServiceMock;
    private readonly Mock<IPlatformsService> _platformsServiceMock;
    private readonly Mock<IGenresService> _genresServiceMock;
    private readonly CatalogueController _controller;

    public CatalogueControllerTests()
    {
        _videoGamesServiceMock = new Mock<IVideoGamesService>();
        _platformsServiceMock = new Mock<IPlatformsService>();
        _genresServiceMock = new Mock<IGenresService>();

        _controller = new CatalogueController(
            _videoGamesServiceMock.Object,
            _platformsServiceMock.Object,
            _genresServiceMock.Object
        );
    }

    [Fact]
    public async Task GetByPlatform_PlatformNotFound_ReturnsNotFound()
    {
        _platformsServiceMock
            .Setup(s => s.GetByCode("PC"))
            .Returns((Platform?)null);

        var result = await _controller.GetByPlatform("PC");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetByPlatform_NoGamesFound_ReturnsNotFound()
    {
        _platformsServiceMock
            .Setup(s => s.GetByCode("PC"))
            .Returns(new Platform());
        _videoGamesServiceMock
            .Setup(s => s.GetAllByPlatform("PC"))
            .Returns(new List<VwAllVideoGames>());

        var result = await _controller.GetByPlatform("PC");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetByPlatform_GamesFound_ReturnsOk()
    {
        _platformsServiceMock
            .Setup(s => s.GetByCode("PC"))
            .Returns(new Platform());
        _videoGamesServiceMock
            .Setup(s => s.GetAllByPlatform("PC"))
            .Returns(new List<VwAllVideoGames>
            {
                new VwAllVideoGames { Id = Guid.NewGuid(), Title = "Game" }
            });

        var result = await _controller.GetByPlatform("PC");

        var ok = Assert.IsType<OkObjectResult>(result.Result);
        var games = Assert.IsAssignableFrom<IEnumerable<VideoGame>>(ok.Value);
        Assert.NotEmpty(games);
    }
    
}