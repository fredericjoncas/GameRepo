using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class HealthTest
    {
        private Unit.Health health;  

        [TestInitialize()]
        public void TestInitialize()
        {
            health = new Unit.Health(50, 100, 0.5);
        }

        [TestMethod]
        public void Health_AddCurrentHealth_ShouldAddHealth()
        {
            var currentAmount = health.getCurrentHealth();
            var healAmount = 25.0;

            health.AddCurrentHealth(healAmount);

            Assert.AreEqual(currentAmount + healAmount, health.getCurrentHealth());
        }

        [TestMethod]
        public void Health_AddPercentageHealth_ShouldAddHealth()
        {
            var currentAmount = health.getPercentHealth();
            var healAmount = 0.25;

            health.AddPercentageHealth(healAmount);

            Assert.AreEqual(currentAmount + healAmount, health.getPercentHealth());
        }
    }
}
