namespace SondaCappta.Models
{
    /// <summary>
    /// Probe reference class
    /// </summary>
    public class Probe
    {
        public Probe()
        {
            Coords = new Coords();
            Field = new Field();
        }

        /// <summary>
        /// Probe's current coords
        /// </summary>
        public Coords Coords { get; set; }

        /// <summary>
        /// Probe's current facing direction
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Current field the probe is on
        /// </summary>
        public Field Field { get; set; }

        /// <summary>
        /// Builds a <c>string</c> for the Probe's current position and direction
        /// </summary>
        /// <returns><c>string</c> in the format 'X Y D', where X and Y are the coordinates and D the direction</returns>
        public string GetPosition()
        {
            return $"{Coords} {Direction}";
        }

        /// <summary>
        /// Turns the probe to a regarding <paramref name="direction"/>
        /// </summary>
        /// <param name="direction">The <c>TurnDirection</c> to turn the probe to</param>
        public void Turn(TurnDirection direction)
        {
            var turnLeft = direction.Equals(TurnDirection.L);

            switch (Direction)
            {
                case Direction.N:
                    Direction = turnLeft ? Direction.W : Direction.E;
                    break;
                case Direction.S:
                    Direction = turnLeft ? Direction.E : Direction.W;
                    break;
                case Direction.E:
                    Direction = turnLeft ? Direction.N : Direction.S;
                    break;
                case Direction.W:
                    Direction = turnLeft ? Direction.S : Direction.N;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Tries to move the Probe on the current facing direction
        /// </summary>
        /// <returns><c>false</c> if the probe couldn't be moved</returns>
        public bool TryMoveForward()
        {
            var attemptDestination = new Coords(Coords);

            switch (Direction)
            {
                case Direction.N:
                    attemptDestination.YCoord++;
                    break;
                case Direction.S:
                    attemptDestination.YCoord--;
                    break;
                case Direction.E:
                    attemptDestination.XCoord--;
                    break;
                case Direction.W:
                    attemptDestination.XCoord++;
                    break;
                default:
                    break;
            }

            var possibleMove = !Field.IsOutOfBounds(attemptDestination);
            Coords = possibleMove ? Coords = attemptDestination : Coords;
            return possibleMove;
        }
    }
}
