using System;

namespace ToyRobotSimulator.ToyRobot
{
    public class Robot : IRobot
    {
        public Placement Placement { get; set; }

        public Direction Direction { get; set; }

        public void Place(Placement placement, Direction direction)
        {
            Placement = placement;
            Direction = direction;
        }

        public void Move(Placement placement)
        {
            Placement = placement;
        }


        public void RotateRight()
        {
            Rotate(1);
        }

        public void RotateLeft()
        {
            Rotate(-1);
        }

        private void Rotate(int rotationNumber)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));

            Direction newDirection;

            if ((Direction + rotationNumber) < 0)
            {
                newDirection = directions[directions.Length - 1];
            }
            else
            {
                var index = ((int)(Direction + rotationNumber)) % directions.Length;
                newDirection = directions[index];
            }

            Direction = newDirection;
        }

        public Placement GetNextPosition()
        {
            var newPlacement = new Placement(Placement.X, Placement.Y);

            switch (Direction)
            {
                case Direction.North:
                    newPlacement.Y = newPlacement.Y + 1;
                    break;
                case Direction.South:
                    newPlacement.Y = newPlacement.Y - 1;
                    break;
                case Direction.East:
                    newPlacement.X = newPlacement.X + 1;
                    break;
                case Direction.West:
                    newPlacement.X = newPlacement.X - 1;
                    break;
            }
            return newPlacement;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", Placement.X,
                Placement.Y, Direction.ToString().ToUpper());
        }
    }
}
