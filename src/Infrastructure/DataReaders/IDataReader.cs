using Domain.Models;

namespace Infrastructure.DataReaders;

public interface IDataReader
{
    List<Player>? ReadData();
}
