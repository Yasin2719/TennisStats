using Domain.Models;

namespace Application.Utils;

public static class MathematicsUtils
{
    public static double GetMoyenne(List<int> data)
    {
        return data.Average();
    }

    public static double GetMoyenne(List<double> data)
    {
        return data.Average();
    }

    public static double? GetMediane(List<int> data)
    {
        var sortedData = data.OrderBy(x => x).ToList();
        var count = sortedData.Count;

        if (count == 0) return null;

        if(count % 2 == 1)
        {
            return sortedData[count / 2];
        }
        else
        {
            int firstMiddle = sortedData[(count / 2) - 1];
            int secondMiddle = sortedData[count / 2];

            return (firstMiddle + secondMiddle) / 2.0;
        }
    }

    public static double GetIMCMoyen(List<Player> data)
    {
        var imcData = data
            .Select(
                player =>
                {
                    double height = player.Data.Height / 100.0;
                    double weight = player.Data.Weight / 1000.0;

                    return weight / (height * height);
                })
            .ToList();

        return GetMoyenne(imcData);
    }
}
