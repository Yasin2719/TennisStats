using Domain.Models;

namespace Application.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetPlayers();
    Task<Player> GetPlayerById(int id);
    Task<int> GetIMCMoyen();
    Task<int> GetTailleMediane();
}
