using System;
using System.Collections.Generic;
using MarsRoverExcercise.Library;

namespace MarsRoverExcercise
{
    class Program
    {
        static void Main()
        {
            
            var plateauWidth = ReadInteger("Enter plateau width: ");
            var plateauLength = ReadInteger("Enter plateau length: ");

            List<IRover> rovers = new List<IRover>();
            while (true)
            {
                var name = ReadString("Enter the name of the rover (type . to stop): ");

                if (name == ".")
                {
                    break;
                }

                ReadRoverStartPosition($"Enter the rover {name} start position x, y, direction: ", out var startX,
                    out var startY, out var direction);

                var command = ReadString($"Enter the command to send to rover {name}: ");

                IPlateau plateau = new Plateau(plateauWidth, plateauLength);
                IRover rover = new Rover(name, plateau);
                rovers.Add(rover);

                rover.SetCurrentPosition(startX, startY, direction);

                IRoverCommander commander = new RoverCommander(rover);
                try
                {
                    commander.SendCommands(command);
                    Console.WriteLine($"Rover {name} succesfully moved.");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Something went wrong: {exception.Message}");
                }
            }
            PrintRoverPositions(rovers);

            Console.WriteLine("Press a key to exit");
            Console.Read();

        }

        private static void PrintRoverPositions(List<IRover> rovers)
        {
            foreach (var rover in rovers)
            {
                Console.WriteLine($"Rover {rover.Name}: {rover.X}, {rover.Y}, {rover.Direction}");
            }
        }

        private static string ReadString(string message)
        {
            Console.Write(message);
            var command = Console.ReadLine();
            return command;
        }

        private static void ReadRoverStartPosition(string message, out long startX, out long startY, out char direction)
        {
            bool inputValid;

            do
            {
                startX = 0;
                startY = 0;
                direction = '.';
                Console.Write(message);
                var readLine = Console.ReadLine();
                inputValid = true;
                if (string.IsNullOrEmpty(readLine))
                {
                    inputValid = false;
                }
                else
                {
                    var values = readLine.Split(',');
                    if (values.Length == 3)
                    {
                        if (!long.TryParse(values[0].Trim(), out startX))
                        {
                            inputValid = false;
                        }
                        if (!long.TryParse(values[1].Trim(), out startY))
                        {
                            inputValid = false;
                        }
                        direction = values[2][0];
                    }
                    else
                    {
                        inputValid = false;
                    }
                }
                
                if (!inputValid)
                {
                    Console.WriteLine("Wrong input, please retry.");
                }
            } while (!inputValid);
        }

        private static int ReadInteger(string message)
        {
            bool inputValid;
            int result;
            do
            {
                Console.Write(message);
                var readLine = Console.ReadLine();
                inputValid = int.TryParse(readLine, out result);
                if (!inputValid)
                {
                    Console.WriteLine("Wrong input, please retry.");
                }
            } while (!inputValid);
            return result;
        }
    }
}
