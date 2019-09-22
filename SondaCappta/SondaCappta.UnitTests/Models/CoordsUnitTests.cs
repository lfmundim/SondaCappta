using Shouldly;
using SondaCappta.Models;
using Xunit;

namespace SondaCappta.UnitTests.Models
{
    public class CoordsUnitTests
    {
        [Theory]
        [InlineData(5, 4, "5 4")]
        public void ToString_UnitTests(int xCoord, int yCoord, string expectedResult)
        {
            var coord = new Coords(xCoord, yCoord);

            coord.ShouldNotBeNull();
            coord.ToString().ShouldBe(expectedResult);
            coord.XCoord.ShouldBe(xCoord);
            coord.YCoord.ShouldBe(yCoord);
        }

        [Fact]
        public void CloneCtor_UnitTests()
        {
            var coord = new Coords();
            var clone = new Coords(coord);

            clone.ShouldNotBeNull();
            clone.ShouldNotBeSameAs(coord);
            clone.ToString().ShouldBe(coord.ToString());
            clone.XCoord.ShouldBe(coord.XCoord);
            clone.YCoord.ShouldBe(coord.YCoord);
        }
    }
}
