using Domain.Models;

namespace Application.Repositories;

public interface IPlayerRepository
{
    IEnumerable<Player> GetPlayers();
    Player GetPlayerById(int id);
    double GetIMCMoyen();
    double? GetTailleMediane();
    Country? GetCountryWithBestScore();
}
