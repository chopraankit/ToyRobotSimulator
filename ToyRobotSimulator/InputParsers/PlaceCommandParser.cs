using System;
using ToyRobotSimulator.ToyRobot;

namespace ToyRobotSimulator.Validator
{
    public class PlaceCommandParser
    {
        private const int ParameterCount = 3;

        private const int CommandInputCount = 2;

        public PlaceCommandParameters ValidateAndParseParams(string[] input, bool robotOnTheTable, Direction lastDirection)
        {
            Direction direction;
            Placement placement = null;

            if (input.Length != CommandInputCount)
                throw new ArgumentException("Invalid command. Please try again with the following format: PLACE X,Y,DIRECTION");

            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
            {
                foreach (var param in commandParams)
                {
                    if (!Int32.TryParse(param, out int numValue))
                    {
                        throw new ArgumentException("Invalid command. Please try again with the following format: PLACE X,Y,DIRECTION");
                    }
                }

                if (!robotOnTheTable)
                {
                    throw new ArgumentException("Invalid command. Please try again with the following format: PLACE X,Y,DIRECTION");
                }
            }

            if (commandParams.Length == 3)
            {
                // Checks the direction which the toy is going to be facing.
                if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                    throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH,SOUTH,EAST,WEST");
            }
            else
            {
                direction = lastDirection;
            }


            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            placement = new Placement(x, y);

            return new PlaceCommandParameters(placement, direction);

        }
    }

    public class PlaceCommandParameters
    {
        public Placement Placement { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameters(Placement placement, Direction direction)
        {
            Placement = placement;
            Direction = direction;
        }
    }
}
