using Domain.Models;

namespace Application.Repositories;

public interface ICountryRepository
{
    Task<Country> GetCountryWithBestScore();
}
