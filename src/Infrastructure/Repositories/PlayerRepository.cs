using Application.Repositories;
using Application.Utils;
using Domain.Models;
using Infrastructure.DataReaders;

namespace Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly IDataReader _dataReader;
    private readonly List<Player> _players;

    public PlayerRepository(IDataReader dataReader)
    {
        _dataReader = dataReader;
        _players = [];

        var data = _dataReader.ReadData();
        if(data is not null)
        {
            _players = [.. data];
        }
    }

    public double GetIMCMoyen()
    {
        return MathematicsUtils.GetIMCMoyen(_players);
    }

    public Player? GetPlayerById(int id)
    {
        return _players
            .Where(player => player.Id == id)
            .FirstOrDefault();
    }

    public IEnumerable<Player> GetPlayers()
    {
        return _players;
    }

    public double? GetTailleMediane()
    {
        return MathematicsUtils.GetMediane(
                _players.Select(player => player.Data.Weight).ToList());
    }

    public Country? GetCountryWithBestScore()
    {
        return (
            from player in _players
            group player by player.Country.Code into newGroup
            orderby newGroup.Key
            select new
            {
                totalPoints = newGroup.Sum(x => x.Data.Points),
                country = newGroup.Select(x => x.Country)
            })
             .OrderByDescending(x => x.totalPoints)
             .Select(x => x.country.First())
             .FirstOrDefault();
    }
}
