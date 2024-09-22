using Application.DTOs;
using Application.Repositories;
using Domain.Abstractions;
using Domain.Errors;
using Domain.Models;

namespace Application.Services;

public class PlayerService(
    IPlayerRepository playerRepository, 
    ICountryRepository countryRepository) : IPlayerService 
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly ICountryRepository _countryRepository = countryRepository;

    public async Task<Result<IEnumerable<Player>>> GetPLayers()
    {
        var players = await _playerRepository.GetPlayers();
        return Result<IEnumerable<Player>>.Success(players);
    }

    public async Task<Result<Player>> GetPlayerById(int id)
    {
        var player = await _playerRepository.GetPlayerById(id);

        if(player is null)
        {
            return Result<Player>.Failure(
                PlayerError.NotFound, 
                System.Net.HttpStatusCode.NotFound);
        }

        return Result<Player>.Success(player);
    }

    
    public Task<Result<StatsResponse>> GetStats()
    {
        throw new NotImplementedException();
    }
}
