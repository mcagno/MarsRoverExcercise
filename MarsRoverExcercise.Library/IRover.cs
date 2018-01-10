namespace MarsRoverExcercise.Library
{
    public interface IRover
    {
        string Name { get; }
        double X { get; }
        double Y { get; }
        char Direction { get; }
        IPlateau Plateau { get; }
        void SetCurrentPosition(long x, long y, char direction);
        void Move();
        void RotateCCW();
        void RotateCW();
    }
}