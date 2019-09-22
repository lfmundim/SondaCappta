namespace SondaCappta.Models
{
    /// <summary>
    /// Basic coordinates model
    /// </summary>
    public class Coords
    {
        /// <summary>
        /// Instantiates a new <c>Coords</c> instance with the given values
        /// </summary>
        /// <param name="x">Value for the <c>XCoord. Defaults to 0</c></param>
        /// <param name="y">Value for the <c>YCoord. Defaults to 0</c></param>
        public Coords(int x = 0, int y = 0)
        {
            XCoord = x;
            YCoord = y;
        }

        /// <summary>
        /// Clones an existing <paramref name="coords"/>
        /// </summary>
        /// <param name="coords"></param>
        public Coords(Coords coords)
        {
            XCoord = coords.XCoord;
            YCoord = coords.YCoord;
        }

        /// <summary>
        /// Coords on the X Axis
        /// </summary>
        public int XCoord { get; set; } = 0;

        /// <summary>
        /// Coords on the Y Axis
        /// </summary>
        public int YCoord { get; set; } = 0;

        /// <summary>
        /// Prints the coordinates in a user-friendly way
        /// </summary>
        /// <returns><c>string</c> formatted as 'X Y'</returns>
        public override string ToString()
        {
            return $"{XCoord} {YCoord}";
        }
    }
}