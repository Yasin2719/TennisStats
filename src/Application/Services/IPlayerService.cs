using Application.DTOs;
using Domain.Abstractions;
using Domain.Models;

namespace Application.Services;

public interface IPlayerService
{
    Result<IEnumerable<Player>> GetPLayers();
    Result<Player> GetPlayerById(int id);
    Result<StatsResponse> GetStats();
}
