using Application.Repositories;
using Application.Utils;
using Domain.Models;

namespace Application.UnitTests.Fakers.Repositories;

internal class FakePlayerRepository : IPlayerRepository
{
    public List<Player> Players { get; set; } =
    [
        new()
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            ShortName = "JoDoe",
            Picture = "picturelink.com",
            Sex = "M",
            Country = new Country()
            {
                Picture = "countrypicturelink.com",
                Code = "FRA"
            },
            Data = new PlayerStats()
            {
                Age = 20,
                Height = 180,
                Weight = 75,
                Points = 80,
                Rank = 2,
                Last = [1, 0],
            }
        },
        new ()
        {
            Id = 2,
            Firstname = "Jane",
            Lastname = "Doe",
            ShortName = "JaDoe",
            Picture = "picturelink.com",
            Sex = "F",
            Country = new Country()
            {
                Picture = "countrypicturelink.com",
                Code = "USA"
            },
            Data = new PlayerStats()
            {
                Age = 20,
                Height = 170,
                Weight = 68,
                Points = 110,
                Rank = 1,
                Last = [1, 1],
            }
        },
        new() {
            Id = 3,
            Firstname = "John",
            Lastname = "Doe",
            ShortName = "JoDoe",
            Picture = "picturelink.com",
            Sex = "M",
            Country = new Country()
            {
                Picture = "countrypicturelink.com",
                Code = "FRA"
            },
            Data = new PlayerStats()
            {
                Age = 20,
                Height = 180,
                Weight = 75,
                Points = 80,
                Rank = 2,
                Last = [1, 0],
            }
        }
    ];


    public double GetIMCMoyen()
    {
        return MathematicsUtils.GetIMCMoyen(Players);
    }

    public Player? GetPlayerById(int id)
    {
        var player = Players.Where(player => player.Id == id).FirstOrDefault();

        return player;
    }

    public IEnumerable<Player> GetPlayers()
    {
        return Players;
    }

    public double? GetTailleMediane()
    {
        return MathematicsUtils.GetMediane(
            Players.Select(player => player.Data.Weight).ToList());
    }

    public Country? GetCountryWithBestScore()
    {
        return (
            from player in Players
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
