using Shouldly;
using SondaCappta.Models;
using System;
using Xunit;

namespace SondaCappta.UnitTests.Models
{
    public class ProbeUnitTests
    {
        private readonly Field _referenceField;
        public ProbeUnitTests()
        {
            _referenceField = new Field(5, 5);
        }

        [Theory]
        [InlineData("L", Direction.E, Direction.N)]
        [InlineData("R", Direction.E, Direction.S)]
        [InlineData("L", Direction.W, Direction.S)]
        [InlineData("R", Direction.W, Direction.N)]
        [InlineData("L", Direction.S, Direction.E)]
        [InlineData("R", Direction.S, Direction.W)]
        [InlineData("L", Direction.N, Direction.W)]
        [InlineData("R", Direction.N, Direction.E)]
        public void Turn_UnitTests(string turnDirection, Direction currentDirection, Direction expectedDirection)
        {
            Enum.TryParse<TurnDirection>(turnDirection, out var direction);
            var probe = new Probe
            {
                Coords = new Coords(),
                Direction = currentDirection
            };
            
            probe.Turn(direction);

            probe.Direction.ShouldBe(expectedDirection);
        }

        [Theory]
        [InlineData(Direction.S, false, "0 0 S")]
        [InlineData(Direction.W, false, "0 0 W")]
        [InlineData(Direction.E, true, "1 0 E")]
        [InlineData(Direction.N, true, "0 1 N")]
        public void TryMoveForward_UnitTests(Direction facingDirection, bool canMove, string expectedPosition)
        {
            var probe = new Probe
            {
                Coords = new Coords(),
                Direction = facingDirection
            };

            var couldMove = _referenceField.TryMoveForward(probe);

            couldMove.ShouldBe(canMove);
            probe.GetPosition().ShouldBe(expectedPosition);
        }
    }
}
