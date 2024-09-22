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

    public async Task<double> GetIMCMoyen()
    {
        return MathematicsUtils.GetIMCMoyen(_players);
    }

    public async Task<Player?> GetPlayerById(int id)
    {
        return _players
            .Where(player => player.Id == id)
            .FirstOrDefault();
    }

    public async Task<IEnumerable<Player>> GetPlayers()
    {
        return _players;
    }

    public async Task<double?> GetTailleMediane()
    {
        return MathematicsUtils.GetMediane(
                _players.Select(player => player.Data.Weight).ToList());
    }
}
