using System.Collections.Generic;
using System.Linq;

namespace SondaCappta.Models
{
    /// <summary>
    /// (Rectangular) Field to be explored by the probe
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Generates a <c>Field</c> with the given dimensions. Defaults to a 1x1 field with only coords (0, 0)
        /// </summary>
        /// <param name="xDimension"></param>
        /// <param name="yDimension"></param>
        public Field(int xDimension = 0, int yDimension = 0)
        {
            XDimension = xDimension;
            YDimension = yDimension;
            Probes = new List<Probe>();
        }

        /// <summary>
        /// How many rows the field has
        /// </summary>
        public int XDimension { get; set; } = 0;

        /// <summary>
        /// How many columns the field has
        /// </summary>
        public int YDimension { get; set; } = 0;

        /// <summary>
        /// Probes currently on the field
        /// </summary>
        public List<Probe> Probes { get; set; }

        /// <summary>
        /// Tries to move the Probe on the current facing direction
        /// </summary>
        /// <returns><c>false</c> if the probe couldn't be moved</returns>
        public bool TryMoveForward(Probe probe)
        {
            var attemptDestination = new Coords(probe.Coords);

            switch (probe.Direction)
            {
                case Direction.N:
                    attemptDestination.YCoord++;
                    break;
                case Direction.S:
                    attemptDestination.YCoord--;
                    break;
                case Direction.E:
                    attemptDestination.XCoord++;
                    break;
                case Direction.W:
                    attemptDestination.XCoord--;
                    break;
                default:
                    break;
            }

            var possibleMove = !IsOutOfBounds(attemptDestination) && !IsProbeBlockingTheWay(attemptDestination);
            probe.Coords = possibleMove ? probe.Coords = attemptDestination : probe.Coords;

            return possibleMove;
        }

        private bool IsOutOfBounds(Coords coord) => IsEitherCoordGreaterThanDimension(coord) || IsEitherCoordNegative(coord);

        private bool IsEitherCoordNegative(Coords coord) => coord.XCoord < 0 || coord.YCoord < 0;

        private bool IsEitherCoordGreaterThanDimension(Coords coord) => coord.XCoord > XDimension || coord.YCoord > YDimension;

        private bool IsProbeBlockingTheWay(Coords coord) => Probes.Any(p => p.Coords.Equals(coord));
    }
}
