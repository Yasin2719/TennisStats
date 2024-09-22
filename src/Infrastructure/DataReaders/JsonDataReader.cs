using Domain.Models;
using Infrastructure.DataReaders;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Helpers;

internal class JsonDataReader(IConfiguration configuration): IDataReader
{
    private readonly IConfiguration _configuration = configuration;

    public List<Player>? ReadData()
    {
            string path = _configuration.GetSection("json-file-path").Value;

            var serializer = new JsonSerializer();
            JsonDataType data = new()
            {
                Players = []
            };

            using (var streamReader = new StreamReader(path))
            using (var textReader = new JsonTextReader(streamReader))
            {
                var test = File.Exists(path);
                data = serializer.Deserialize<JsonDataType>(textReader);
            }

            return data?.Players;
    }
}
