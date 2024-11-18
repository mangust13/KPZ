using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhrustavchukMaksym.RobotChallenge;
using Robot.Common;

namespace KhrustavchukMaksym.RobotChallenge
{
    public class KhrustavchukMaksymAlgorithm : IRobotAlgorithm
    {
        public int ChildrenCount { get; set; } = 0;
        public int RoundCount { get; set; } = 0;

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            Robot.Common.Robot robot = robots[robotToMoveIndex];
            
            Position position = Functions.FindNearestFreeStation(robot, map, robots);
            Position checkpoint = Functions.GetCheckpoint(robot, robot.Position, position);

            if (robot.Energy >= 217 && Functions.AreThereFreeStationsNearby(robot, map, robots) && ChildrenCount <= 90)
            {
                if (Functions.IsNearStation(robot.Position, position))
                {
                    ++ChildrenCount;
                    return new CreateNewRobotCommand
                    {
                        NewRobotEnergy = robot.Energy - 200
                    };
                }
            }

            if (RoundCount > 30)
            {
                RobotCommand attackCommand = TryAttack(robot, map, robots);
                if (attackCommand != null)
                    return attackCommand;
            }

            if (checkpoint == null)
                return null;

            if (Functions.IsNearStation(robot.Position, position))
            {
                return new CollectEnergyCommand();
            }

            return new MoveCommand() { NewPosition = checkpoint };
        }

        private RobotCommand TryAttack(Robot.Common.Robot robot, Map map, IList<Robot.Common.Robot> robots)
        {
            List<KeyValuePair<int, Position>> source = FindAttackTargets(map, robot.Position, robots, Author);
            if (!source.Any())
            {
                return null;
            }

            Position value = source.First().Value;
            int distanceCost = Functions.FindDistance(robot.Position, value);
            int num = 130;
            if (robot.Energy > distanceCost + num)
            {
                return new MoveCommand
                {
                    NewPosition = value
                };
            }

            return null;
        }

        List<KeyValuePair<int, Position>> FindAttackTargets(Map map, Position robotPosition, IList<Robot.Common.Robot> robots, string author)
        {
            return (from robot in robots
                    where robot.OwnerName != author && robot.Energy >= 800 && IsWithinRadius(robotPosition, robot.Position, 10)
                    select new KeyValuePair<int, Position>(CalculateKillPriority(robotPosition, robot), robot.Position) into k
                    orderby k.Key descending
                    select k).ToList();
        }

        int CalculateKillPriority(Position from, Robot.Common.Robot targetRobot)
        {
            int distanceCost = Functions.FindDistance(from, targetRobot.Position);
            int num = (int)((double)targetRobot.Energy * 0.1);
            return distanceCost + 30 - num;
        }

        bool IsWithinRadius(Position center, Position point, int radius)
        {
            return Math.Abs(center.X - point.X) <= radius && Math.Abs(center.Y - point.Y) <= radius;
        }

        public KhrustavchukMaksymAlgorithm()
        {
            Logger.OnLogRound += LogRound;
        }
        private void LogRound(object sender, LogRoundEventArgs e)
        {
            ++RoundCount;
        }
        public string Author => "Khrustavchuk Maksym";
        public string Description => "Final version";
    }
}