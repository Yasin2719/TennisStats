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


    public async Task<double> GetIMCMoyen()
    {
        return await Task.Run(() => MathematicsUtils.GetIMCMoyen(Players));
    }

    public async Task<Player> GetPlayerById(int id)
    {
        var player = Players.Where(player => player.Id == id).FirstOrDefault();

        return await Task.Run(() => player);
    }

    public async Task<IEnumerable<Player>> GetPlayers()
    {
        return await Task.Run(() => Players);
    }

    public async Task<double?> GetTailleMediane()
    {
        return await Task.Run(() => 
            MathematicsUtils.GetMediane(
                Players.Select(player => player.Data.Weight).ToList()));
    }
}
