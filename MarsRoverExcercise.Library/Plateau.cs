namespace MarsRoverExcercise.Library
{
    public class Plateau : IPlateau
    {
        public long Width { get; }
        public long Length { get; }

        public Plateau(long width, long length)
        {
            Width = width;
            Length = length;
        }
    }
}