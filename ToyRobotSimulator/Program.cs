using System;
using ToyRobotSimulator.CommandHandlers;
using ToyRobotSimulator.TableTop;
using ToyRobotSimulator.ToyRobot;
using ToyRobotSimulator.Validator;

namespace ToyRobotSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string startupText =

            @" Toy Robot Simulator -

List of commands for simulation:

PLACE X,Y,DIRECTION
MOVE
LEFT
RIGHT
REPORT
QUIT";

            IRobot robot = new Robot();
            ITableTop tableTop = new TableTop.TableTop(6, 6);
            ICommandParser commandParser = new CommandParser();

            ICommandHandler handler = new CommandHandler(robot, tableTop, commandParser);

            var stopApplication = false;

            Console.WriteLine(startupText);
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("QUIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = handler.HandleCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
            while (!stopApplication);
        }
    }
}
