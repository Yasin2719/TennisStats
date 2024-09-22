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

    
    public async Task<Result<StatsResponse>> GetStats()
    {
        var bestPays = await _countryRepository.GetCountryWithBestScore();

        var imcMoyen = await _playerRepository.GetIMCMoyen();

        var tailleMediane = await _playerRepository.GetTailleMediane();

        return Result<StatsResponse>.Success(new(bestPays, imcMoyen, tailleMediane.GetValueOrDefault()));
    }
}
