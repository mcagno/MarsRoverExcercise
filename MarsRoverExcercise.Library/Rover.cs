namespace MarsRoverExcercise.Library
{
    public class Rover : IRover
    {
        public string Name { get; }
        public double X { get; protected set; }
        public double Y { get; protected set; }
        public char Direction { get; protected set; }

        public IPlateau Plateau { get; }

        public Rover(IPlateau plateau) : this(string.Empty, plateau)
        {
            
        }

        public Rover(string name, IPlateau plateau)
        {
            Name = name;
            Plateau = plateau;
        }

        public void SetCurrentPosition(long x, long y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;

            if(!IsCurrentPositionValid())
            {
                throw new OutOfPlateauException();
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case 'N':
                    Y++;
                    break;
                case 'E':
                    X++;
                    break;
                case 'S':
                    Y--;
                    break;
                case 'W':
                    X--;
                    break;
            }

            if (!IsCurrentPositionValid())
            {
                throw new OutOfPlateauException();
            }
        }

        private bool IsCurrentPositionValid()
        {
            return !(X < 0 || Y < 0 || X >= Plateau.Width || Y >= Plateau.Length);

        }

        public void RotateCCW()
        {
            switch (Direction)
            {
                case 'N':
                    Direction = 'W';
                    break;
                case 'E':
                    Direction = 'N';
                    break;
                case 'S':
                    Direction = 'E';
                    break;
                case 'W':
                    Direction = 'S';
                    break;
            }
        }

        public void RotateCW()
        {
            switch (Direction)
            {
                case 'W':
                    Direction = 'N';
                    break;
                case 'N':
                    Direction = 'E';
                    break;
                case 'E':
                    Direction = 'S';
                    break;
                case 'S':
                    Direction = 'W';
                    break;
            }
        }
    }
}