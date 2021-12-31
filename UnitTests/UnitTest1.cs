using LineDrawer.Services;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEquationFromPointsTests()
        {
            var service = new MathOperationService();

            var x1 = service.GetEquationFromPoints(1, 5, 5, 4);
            var y1 = service.GetEquationFromPoints(1, 1, 2, 2);
            var x2 = service.GetEquationFromPoints(2, 1, 3, 4);
            var y2 = service.GetEquationFromPoints(2, 3, 3, 1);

            Assert.AreEqual(3, x1.ThirdPower);
            Assert.AreEqual(-12, x1.SecondPower);
            Assert.AreEqual(12, x1.FirstPower);
            Assert.AreEqual(1, x1.NoPower);

            Assert.AreEqual(-2, y1.ThirdPower);
            Assert.AreEqual(3, y1.SecondPower);
            Assert.AreEqual(0, y1.FirstPower);
            Assert.AreEqual(1, y1.NoPower);

            Assert.AreEqual(-4, x2.ThirdPower);
            Assert.AreEqual(9, x2.SecondPower);
            Assert.AreEqual(-3, x2.FirstPower);
            Assert.AreEqual(2, x2.NoPower);

            Assert.AreEqual(-1, y2.ThirdPower);
            Assert.AreEqual(-3, y2.SecondPower);
            Assert.AreEqual(3, y2.FirstPower);
            Assert.AreEqual(2, y2.NoPower);
        }
    }
}