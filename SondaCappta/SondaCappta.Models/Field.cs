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
        /// Checks if a given <paramref name="coord"/> is out of the field
        /// </summary>
        /// <param name="coord"></param>
        /// <returns><c>true</c> if the given coord is outside of the field</returns>
        public bool IsOutOfBounds(Coords coord) => IsEitherCoordGreaterThanDimension(coord) || IsEitherCoordNegative(coord);

        private bool IsEitherCoordNegative(Coords coord) => coord.XCoord < 0 || coord.YCoord < 0;

        private bool IsEitherCoordGreaterThanDimension(Coords coord) => coord.XCoord > XDimension || coord.YCoord > YDimension;
    }
}
