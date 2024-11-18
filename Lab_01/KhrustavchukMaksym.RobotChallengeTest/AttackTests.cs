using KhrustavchukMaksym.RobotChallenge;
using Robot.Common;

namespace KhrustavchukMaksym.RobotChallengeTest
{
    [TestClass]
    public class AttackTests
    {
        [TestMethod]
        public void TestAttackEnemyRobot()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();

            algorithm.RoundCount = 35;

            var myRobot = new Robot.Common.Robot()
            { Energy = 100, Position = new Position(0, 0), OwnerName = "Khrustavchuk Maksym" };

            var robots = new List<Robot.Common.Robot>() { myRobot };

            map.Stations.Add(new EnergyStation() { Energy = 1000, Position = new Position(15, 15) });

            var methodInfo = typeof(KhrustavchukMaksymAlgorithm)
                .GetMethod("TryAttack",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var res = methodInfo.Invoke(algorithm, new object[] { myRobot, map, robots });

            Assert.IsNull(res);
        }

        [TestMethod]
        public void TestNotEnoughEnergyForAttack()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();

            algorithm.RoundCount = 35;

            var enemyRobot = new Robot.Common.Robot()
            { Energy = 1000, Position = new Position(2, 2), OwnerName = "Enemy" };
            var myRobot = new Robot.Common.Robot()
            { Energy = 50, Position = new Position(0, 0), OwnerName = "Khrustavchuk Maksym" };

            var robots = new List<Robot.Common.Robot>() { myRobot, enemyRobot };

            map.Stations.Add(new EnergyStation() { Energy = 1000, Position = new Position(15, 15) });

            var methodInfo = typeof(KhrustavchukMaksymAlgorithm)
                .GetMethod("TryAttack",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var res = methodInfo.Invoke(algorithm, new object[] { myRobot, map, robots });

            Assert.IsNull(res);
        }

        [TestMethod]
        public void TestExactEnergyForAttack()
        {
            var algorithm = new KhrustavchukMaksymAlgorithm();
            var map = new Map();

            var enemyPosition = new Position(2, 2);
            var myPosition = new Position(0, 0);
            algorithm.RoundCount = 35;

            var distanceCost = Functions.FindDistance(myPosition, enemyPosition);
            var myRobotEnergy = distanceCost + 150;

            var enemyRobot = new Robot.Common.Robot() { Energy = 1000, Position = enemyPosition, OwnerName = "Enemy" };
            var myRobot = new Robot.Common.Robot()
            { Energy = myRobotEnergy, Position = myPosition, OwnerName = "Khrustavchuk Maksym" };

            var robots = new List<Robot.Common.Robot>() { myRobot, enemyRobot };

            map.Stations.Add(new EnergyStation() { Energy = 1000, Position = new Position(15, 15) });

            // Тут очікуємо, що буде атака, оскільки енергії вистачає точно
            var command = algorithm.DoStep(robots, 0, map);

            Assert.IsTrue(command is MoveCommand);
            Assert.AreEqual(((MoveCommand)command).NewPosition, enemyPosition);
        }
    }
}