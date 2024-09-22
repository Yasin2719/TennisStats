using Application.Repositories;
using Application.Services;
using Application.UnitTests.Fakers.Repositories;

namespace Application.UnitTests.Services;

public class PlayerServiceTest
{
    private readonly FakePlayerRepository _playerRepository;
    private readonly PlayerService _service;

    public PlayerServiceTest()
    {
        _playerRepository = new FakePlayerRepository();

        _service = new PlayerService(
            _playerRepository, 
            new FakeCountryRepository());
    }

    [Fact]
    public async Task GetPlayers_ShouldReturnPlayersList()
    {
        //Arrange
        //Act
        var result = await _service.GetPLayers();

        //Assert
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task GetPlayerById_ShouldReturnSuccess_WhenPlayerExist()
    {
        //Arrange
        int playerId = _playerRepository
            .Players
            .FirstOrDefault()!.Id;

        //Act
        var result = await _service.GetPlayerById(playerId);

        //Assert
        Assert.True(result.IsSucess);
    }

    [Fact]
    public async Task GetPlayerById_ShouldNotNull_WhenPlayerExist()
    {
        //Arrange
        int playerId = _playerRepository
            .Players
            .FirstOrDefault()!.Id;

        //Act
        var result = await _service.GetPlayerById(playerId);

        //Assert
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task GetPlayerById_ShouldReturnExpectedPlayer_WhenPlayerExist()
    {
        //Arrange
        int playerId = _playerRepository
            .Players
            .FirstOrDefault()!.Id;

        //Act
        var result = await _service.GetPlayerById(playerId);

        //Assert
        Assert.Equal(playerId, result.Data?.Id);
    }

    [Fact]
    public async Task GetPlayerById_ShouldReturnFailure_WhenPlayerNotExist()
    {
        //Arrange
        int playerId = int.MaxValue;

        //Act
        var result = await _service.GetPlayerById(playerId);

        //Assert
        Assert.True(result.IsFailure);
    }
}
