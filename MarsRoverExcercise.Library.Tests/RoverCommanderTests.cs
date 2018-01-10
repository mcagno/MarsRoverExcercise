using System;
using NSubstitute;
using NUnit.Framework;

namespace MarsRoverExcercise.Library.Tests
{
    [TestFixture]
    class RoverCommanderTests
    {
        [Test]
        public void SendCommand_L_RotateRoverCCW()
        {
            IRover mockedRover = Substitute.For<IRover>();
            IRoverCommander commander = new RoverCommander(mockedRover);

            commander.SendCommand('L');

            mockedRover.Received(1).RotateCCW();
        }

        [Test]
        public void SendCommand_R_RotateRoverCW()
        {
            IRover mockedRover = Substitute.For<IRover>();
            IRoverCommander commander = new RoverCommander(mockedRover);

            commander.SendCommand('R');

            mockedRover.Received(1).RotateCW();
        }

        [Test]
        public void SendCommand_M_Move()
        {
            IRover mockedRover = Substitute.For<IRover>();
            IRoverCommander commander = new RoverCommander(mockedRover);

            commander.SendCommand('M');

            mockedRover.Received(1).Move();
        }

        [Test]
        [TestCase('Y')]
        [TestCase('U')]
        [TestCase('N')]
        [TestCase('.')]
        public void SendCommand_WrongCommand_ExceptionThrown(char command)
        {
            IRover mockedRover = Substitute.For<IRover>();
            IRoverCommander commander = new RoverCommander(mockedRover);

            Assert.Throws<ArgumentException>(() => commander.SendCommand(command));
        }

        [Test]
        public void SendLongCommand_ExpectedCalls()
        {
            IRover mockedRover = Substitute.For<IRover>();
            IRoverCommander commander = new RoverCommander(mockedRover);

            commander.SendCommands("MRLLRRMMMLL");

            mockedRover.Received(4).Move();
            mockedRover.Received(3).RotateCW();
            mockedRover.Received(4).RotateCCW();
        }
    }
}
