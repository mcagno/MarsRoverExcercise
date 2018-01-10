namespace MarsRoverExcercise.Library
{
    public interface IRoverCommander
    {
        IRover Rover { get; }
        void SendCommand(char command);
        void SendCommands(string v);
    }
}