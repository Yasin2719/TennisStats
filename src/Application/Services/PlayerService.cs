using Application.DTOs;
using Application.Repositories;
using Domain.Abstractions;
using Domain.Errors;
using Domain.Models;

namespace Application.Services;

public class PlayerService(
    IPlayerRepository playerRepository) : IPlayerService 
{
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public Result<IEnumerable<Player>> GetPLayers()
    {
        var players = _playerRepository.GetPlayers();
        return Result<IEnumerable<Player>>.Success(players);
    }

    public Result<Player> GetPlayerById(int id)
    {
        var player = _playerRepository.GetPlayerById(id);

        if(player is null)
        {
            return Result<Player>.Failure(
                PlayerError.NotFound, 
                System.Net.HttpStatusCode.NotFound);
        }

        return Result<Player>.Success(player);
    }

    
    public Result<StatsResponse> GetStats()
    {
        var bestPays = _playerRepository.GetCountryWithBestScore();

        var imcMoyen = _playerRepository.GetIMCMoyen();

        var tailleMediane = _playerRepository.GetTailleMediane();

        return Result<StatsResponse>.Success(new(bestPays, imcMoyen, tailleMediane.GetValueOrDefault()));
    }
}
