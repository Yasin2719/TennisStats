using Application.Utils;

namespace Application.UnitTests.Utils;

public class MathematicsUtilsTest
{
    [Fact]
    public void GetMoyenne_ShouldReturnTheAverrage()
    {
        //Arrange
        List<int> data = [1, 2, 3];

        //Act
        var moyenne = MathematicsUtils.GetMoyenne(data);

        //Assert
        Assert.Equal(2, moyenne);
    }
    
    [Fact]
    public void GetMoyenne_ShouldReturnTheAverrage_WhenListIsNotOrdered()
    {
        //Arrange
        List<int> data = [1, 9, 3, 8, 5, 6, 7, 4, 2];

        //Act
        var moyenne = MathematicsUtils.GetMoyenne(data);

        //Assert
        Assert.Equal(5, moyenne);
    }

    [Fact]
    public void GetMediane_ShouldReturnTheMediane_WhenListIsOdd()
    {
        //Arrange
        List<int> data = [1, 3, 5, 6, 7];

        //Act
        var mediane = MathematicsUtils.GetMediane(data);

        //Assert
        Assert.Equal(5, mediane);
    }

    [Fact]
    public void GetMediane_ShouldReturnTheMediane_WhenListIsPeer()
    {
        //Arrange
        List<int> data = [1, 3, 5, 6];

        //Act
        var mediane = MathematicsUtils.GetMediane(data);

        //Assert
        Assert.Equal(4, mediane);
    }

    [Fact]
    public void GetMediane_ShouldReturnTheMediane_WhenListIsEmpty()
    {
        //Arrange
        List<int> data = [];

        //Act
        var mediane = MathematicsUtils.GetMediane(data);

        //Assert
        Assert.Equal(null, mediane);
    }
}
