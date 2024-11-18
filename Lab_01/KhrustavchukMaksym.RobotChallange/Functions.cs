using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Common;

namespace KhrustavchukMaksym.RobotChallenge
{
    public static class Functions
    {
        public static int FindDistance(Position a, Position b)
        {
            return (int)(Math.Pow(a.X - b.X, 2.0) + Math.Pow(a.Y - b.Y, 2.0));

        }

        public static Position GetCheckpoint(Robot.Common.Robot robot, Position A, Position B)
        {
            if (FindDistance(A, B) > robot.Energy)
            {
                int num = A.X;
                int num2 = A.Y;
                if (A.X > B.X)
                    num--;
                else if (A.X < B.X)
                    num++;
                if (A.Y > B.Y)
                    num2--;
                else if (A.Y < B.Y)
                    num2++;

                return new Position(num, num2);
            }

            return B;
        }

        public static bool AreThereFreeStationsNearby(Robot.Common.Robot robot, Map map, IList<Robot.Common.Robot> robots)
        {
            List<EnergyStation> nearbyStations = map.GetNearbyResources(robot.Position, robot.Energy - 200);
            bool isFreeStationFound = false;

            Parallel.ForEach(nearbyStations, (station, state) =>
            {
                if (IsCellFree(station.Position, robot, robots))
                {
                    isFreeStationFound = true;
                    state.Stop();
                }
            });

            return isFreeStationFound;
        }

        public static Position FindNearestFreeStation(Robot.Common.Robot movingRobot, Map map, IList<Robot.Common.Robot> robots)
        {
            EnergyStation nearest = null;
            int minDistance = int.MaxValue;
            object lockObj = new object();

            Parallel.ForEach(map.Stations, station =>
            {
                if (IsStationFree(station, movingRobot, robots))
                {
                    int d = Functions.FindDistance(station.Position, movingRobot.Position);

                    lock (lockObj)
                    {
                        if (d < minDistance)
                        {
                            minDistance = d;
                            nearest = station;
                        }
                    }
                }
            });

            return nearest?.Position;
        }

        public static bool IsStationFree(EnergyStation station, Robot.Common.Robot movingRobot, IList<Robot.Common.Robot> robots)
        {
            return IsCellFree(station.Position, movingRobot, robots);
        }

        public static bool IsCellFree(Position cell, Robot.Common.Robot movingRobot, IList<Robot.Common.Robot> robots)
        {
            bool isFree = true;
            object lockObj = new object();

            Parallel.ForEach(robots, (robot, state) =>
            {
                if (robot == movingRobot)
                {
                    return;
                }

                if (robot.OwnerName == "Khrustavchuk Maksym")
                {
                    int radius = 2;
                    for (int i = cell.X - radius; i <= cell.X + radius; i++)
                    {
                        for (int j = cell.Y - radius; j <= cell.Y + radius; j++)
                        {
                            if (robot.Position.X == i && robot.Position.Y == j)
                            {
                                lock (lockObj)
                                {
                                    isFree = false;
                                    state.Stop();
                                }
                                return;
                            }
                        }
                    }
                }
                else if (robot.Position == cell && robot != movingRobot)
                {
                    lock (lockObj)
                    {
                        isFree = false;
                        state.Stop();
                    }
                    return;
                }
            });

            return isFree;
        }

        public static bool IsNearStation(Position robotPosition, Position stationPosition)
        {
            int num = Math.Abs(robotPosition.X - stationPosition.X);
            int num2 = Math.Abs(robotPosition.Y - stationPosition.Y);
            return num <= 1 && num2 <= 1;
        }
    }
}