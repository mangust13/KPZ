using Robot.Common;
using KhrustavchukMaksym.RobotChallenge;

namespace KhrustavchukMaksym.RobotChallengeTest
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        public void TestCollect()
        {
            Variant.Initialize(9);
            var algorithm = new KhrustavchukMaksymAlgorithm();

            var map = new Map();
            map.Stations.Add(new EnergyStation() { Energy = 100, Position = new Position(0, 0), RecoveryRate = 1 });
            map.Stations.Add(new EnergyStation() { Energy = 100, Position = new Position(2, 2), RecoveryRate = 1 });
            map.Stations.Add(new EnergyStation() { Energy = 100, Position = new Position(1, 1), RecoveryRate = 1 });

            var robots = new List<Robot.Common.Robot>()
            {
                new Robot.Common.Robot() { Energy = 0, Position = new Position(0, 0) }
            };

            var command = algorithm.DoStep(robots, 0, map).ChangeModel(robots, 0, map);
            Assert.AreEqual(robots[0].Energy, 300);
        }

        [TestMethod]
        public void TestMovementToNearestStation()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();

            var stationPosition = new Position(3, 3);
            map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition, RecoveryRate = 1 });
            var robots = new List<Robot.Common.Robot>()
            {
                new Robot.Common.Robot() { Energy = 100, Position = new Position(0, 0) }
            };
            var command = algorithm.DoStep(robots, 0, map);
            Assert.IsTrue(command is MoveCommand);
            Assert.AreEqual(((MoveCommand)command).NewPosition, stationPosition);
        }

        [TestMethod]
        public void TestCollectEnergyAtStation()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();
            var stationPosition = new Position(0, 1);
            map.Stations.Add(new EnergyStation() { Energy = 1000, Position = stationPosition });
            var robots = new List<Robot.Common.Robot>()
                { new Robot.Common.Robot() { Energy = 100, Position = stationPosition } };
            var command = algorithm.DoStep(robots, 0, map);
            Assert.IsTrue(command is CollectEnergyCommand);
        }

        [TestMethod]
        public void TestCreateNewRobot()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();

            map.Stations.Add(new EnergyStation() { Energy = 1000, Position = new Position(2,2) });
            var robots = new List<Robot.Common.Robot>()
            {
                new Robot.Common.Robot() { Energy = 350, Position = new Position(2, 2) }
            };

            var command = algorithm.DoStep(robots, 0, map);
            Assert.IsTrue(command is CreateNewRobotCommand);
            Assert.AreEqual(((CreateNewRobotCommand)command).NewRobotEnergy, 150);
        }

        [TestMethod]
        public void TestFindNearestFreeStation()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();
            map.Stations.Add(new EnergyStation() { Position = new Position(3, 3), Energy = 1000 });
            map.Stations.Add(new EnergyStation() { Position = new Position(5, 5), Energy = 1000 });
            var robot = new Robot.Common.Robot() { Position = new Position(0, 0) };

            var nearestStation = Functions.FindNearestFreeStation(robot, map, new List<Robot.Common.Robot>());
            Assert.AreEqual(new Position(3, 3), nearestStation);
        }

        [TestMethod]
        public void TestAreThereFreeStationsNearby()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();
            map.Stations.Add(new EnergyStation() { Position = new Position(2, 2), Energy = 1000 });
            var robot = new Robot.Common.Robot() { Energy = 400, Position = new Position(0, 0) };

            bool freeStationsNearby = Functions.AreThereFreeStationsNearby(robot, map, new List<Robot.Common.Robot>());
            Assert.IsTrue(freeStationsNearby);
        }

        [TestMethod]
        public void TestIsStationFree()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var station = new EnergyStation() { Position = new Position(2, 2) };
            var robot = new Robot.Common.Robot() { Position = new Position(1, 1) };
            var robots = new List<Robot.Common.Robot>() { robot };

            bool isFree = Functions.IsStationFree(station, robot, robots);
            Assert.IsTrue(isFree);
        }

        [TestMethod]
        public void TestIsCellFreeOccupied()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var robot1 = new Robot.Common.Robot() { Position = new Position(2, 2) };
            var robot2 = new Robot.Common.Robot() { Position = new Position(2, 2) };
            var robots = new List<Robot.Common.Robot>() { robot1, robot2 };

            bool isFree = Functions.IsCellFree(new Position(2, 2), robot1, robots);
            Assert.IsFalse(isFree); // The cell is occupied
        }

        [TestMethod]
        public void TestGetCheckpointWhenEnergyIsLow()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var robot = new Robot.Common.Robot() { Energy = 5, Position = new Position(0, 0) };
            var targetPosition = new Position(5, 5); // Станція знаходиться далеко, а енергії недостатньо

            var checkpoint = Functions.GetCheckpoint(robot, robot.Position, targetPosition);

            Assert.AreEqual(new Position(1, 1), checkpoint); // Робот повинен рухатися на одну клітинку
        }
    }
}