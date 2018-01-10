using System;

namespace MarsRoverExcercise.Library
{
    public class RoverCommander : IRoverCommander
    {

        public IRover Rover { get; }

        public RoverCommander(IRover rover)
        {
            Rover = rover;
        }

        public void SendCommand(char command)
        {
            switch (command)
            {
                case 'L':
                    Rover.RotateCCW();
                    break;
                case 'R':
                    Rover.RotateCW();
                    break;
                case 'M':
                    Rover.Move();
                    break;
                default:
                    throw new ArgumentException($"Invalid command received: {command}");
            }
        }

        public void SendCommands(string commands)
        {
            foreach (var command in commands)
            {
                SendCommand(command);
            }
        }
    }
}