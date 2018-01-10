using System;

namespace MarsRoverExcercise.Library
{
    public class OutOfPlateauException : Exception
    {
        public OutOfPlateauException() : base("The rover has gone out of the plateau")
        {
            
        }
    }
}
