using Application.Repositories;
using Domain.Models;
using Infrastructure.DataReaders;

namespace Infrastructure.Repositories;

internal class CountryRepository : ICountryRepository
{
    private readonly IDataReader _dataReader;
    private readonly List<Player> _players;

    public CountryRepository(IDataReader dataReader)
    {
        _dataReader = dataReader;
        _players = [];

        var data = _dataReader.ReadData();
        if (data is not null)
        {
            _players = [.. data];
        }
    }
    public async Task<Country?> GetCountryWithBestScore()
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