using NUnit.Framework;

namespace MarsRoverExcercise.Library.Tests
{
    [TestFixture]
    public class RoverTests
    {

        [Test]
        [TestCase(1, 1, 'N', 1, 2)]
        [TestCase(1, 1, 'E', 2, 1)]
        [TestCase(1, 1, 'S', 1, 0)]
        [TestCase(1, 1, 'W', 0, 1)]
        public void Move_CorrectMove_IsDone(long startPointX, long startPointY, char startDirection, long expectedPointX, long expectedPointY)
        {
            IPlateau plateau = new Plateau(3, 3);
            IRover rover = new Rover(plateau);
            rover.SetCurrentPosition(startPointX, startPointY, startDirection);

            rover.Move();

            Assert.AreEqual(startDirection, rover.Direction);
            Assert.AreEqual(expectedPointX, rover.X);
            Assert.AreEqual(expectedPointY, rover.Y);
        }

        
        [TestCase(0, 0, 'N')]
        [TestCase(0, 0, 'E')]
        [TestCase(0, 0, 'S')]
        [TestCase(0, 0, 'W')]
        public void Move_WrongMove_Throws_OutOfPlateauException(long startPointX, long startPointY, char startDirection)
        {
            IPlateau plateau = new Plateau(1, 1);
            IRover rover = new Rover(plateau);
            rover.SetCurrentPosition(startPointX, startPointY, startDirection);

            Assert.Throws<OutOfPlateauException>(() => rover.Move());
        }

        [Test]
        [TestCase( 2, 1, 'N')]
        [TestCase( 2, 2, 'E')]
        [TestCase(-1, 0, 'S')]
        [TestCase(-1,-1, 'W')]
        public void SetPosition_WrongPosition_Throws_OutOfPlateauException(long startPointX, long startPointY, char startDirection)
        {
            IPlateau plateau = new Plateau(1, 1);
            IRover rover = new Rover(plateau);

            Assert.Throws<OutOfPlateauException>(() => rover.SetCurrentPosition(startPointX, startPointY, startDirection));
        }

        [Test]
        [TestCase('N', 'W')]
        [TestCase('W', 'S')]
        [TestCase('S', 'E')]
        [TestCase('E', 'N')]
        public void RotateCCW_ExpectedDirection(char startDirection, char expectedDirection)
        {
            IPlateau plateau = new Plateau(1, 1);
            IRover rover = new Rover(plateau);
            rover.SetCurrentPosition(0, 0, startDirection);

            rover.RotateCCW();

            Assert.AreEqual(expectedDirection, rover.Direction);
        }

        [Test]
        [TestCase('W', 'N')]
        [TestCase('S', 'W')]
        [TestCase('E', 'S')]
        [TestCase('N', 'E')]
        public void RotateCW_ExpectedDirection(char startDirection, char expectedDirection)
        {
            IPlateau plateau = new Plateau(1, 1);
            IRover rover = new Rover(plateau);
            rover.SetCurrentPosition(0, 0, startDirection);

            rover.RotateCW();

            Assert.AreEqual(expectedDirection, rover.Direction);
        }
    }

    
}
