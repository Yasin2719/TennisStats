using Application.DTOs;
using Domain.Abstractions;
using Domain.Models;

namespace Application.Services;

public interface IPlayerService
{
    Task<Result<IEnumerable<Player>>> GetPLayers();
    Task<Result<Player>> GetPlayerById(int id);
    Task<Result<StatsResponse>> GetStats();
}
