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
            health = new Unit.Health(50, 100, 0.5, 0);
        }

        [TestMethod]
        public void FlatHealth_AddHealth_ShouldAddHealth()
        {
            var currentAmount = health.GetCurrentHealth();
            var addAmount = 25.0;

            health.AddHealth(addAmount, false);

            Assert.AreEqual(currentAmount + addAmount, health.GetCurrentHealth());
        }

        [TestMethod]
        public void RemoveFlatHealth_AddHealth_ShouldRemoveHealth()
        {
            var currentAmount = health.GetCurrentHealth();
            var addAmount = -25.0;

            health.AddHealth(addAmount, false);

            Assert.AreEqual(currentAmount + addAmount, health.GetCurrentHealth());
        }

        [TestMethod]
        public void PercentHealth_AddHealth_ShouldAddHealth()
        {
            var currentAmount = health.GetPercentHealth();
            var addAmount = 0.25;

            health.AddHealth(addAmount, true);

            Assert.AreEqual(currentAmount + addAmount, health.GetPercentHealth());
        }

        [TestMethod]
        public void RemovePercentHealth_AddHealth_ShouldRemoveHealth()
        {
            var currentAmount = health.GetPercentHealth();
            var addAmount = -0.25;

            health.AddHealth(addAmount, true);

            Assert.AreEqual(currentAmount + addAmount, health.GetPercentHealth());
        }

        [TestMethod]
        public void PercentHealthIncreasesOverMax_AddHealth_ShouldAddHealthToMax()
        {
            var addAmount = 1;
            
            health.AddHealth(addAmount, true);

            Assert.AreEqual(MagicValues.MagicValues.One, health.GetPercentHealth() / MagicValues.MagicValues.One);
        }
       
        [TestMethod]
        public void FlatHealthIncreasesOverMax_AddHealth_ShouldAddHealthToMax()
        {
            var addAmount = 100;

            health.AddHealth(addAmount, false);

            Assert.AreEqual(health.GetMaximumHealth(),  health.GetCurrentHealth());
        }

        [TestMethod]
        public void FlatHealthReducesBelowMin_AddHealth_ShouldSetHealthToMin()
        {
            var addAmount = -100;

            health.AddHealth(addAmount, false);

            Assert.IsTrue(health.GetMinimumHealth() == health.GetCurrentHealth() && health.GetIsDead() 
                &&  health.GetMinimumHealth()/health.GetMaximumHealth() == health.GetPercentHealth());
        }

        [TestMethod]
        public void PercentHealthReducesBelowMin_AddHealth_ShouldSetHealthToMin()
        {
            var addAmount = -1;

            health.AddHealth(addAmount, true);

            Assert.IsTrue(health.GetMinimumHealth() == health.GetCurrentHealth() && health.GetIsDead()
                          && health.GetMinimumHealth() / health.GetMaximumHealth() == health.GetPercentHealth());
        }

        [TestMethod]
        public void FlatHealth_AddCurrentHealth_ShouldMakePercentHealthEven()
        {
            var currentAmount = health.GetCurrentHealth();
            var addAmount = 25.0;

            health.AddHealth(addAmount, false);

            Assert.AreEqual((currentAmount + addAmount) /health.GetMaximumHealth(), health.GetPercentHealth());
        }

        [TestMethod]
        public void PercentHealth_AddCurrentHealth_ShouldMakeFlatHealthEven()
        {
            var currentAmount = health.GetPercentHealth();
            var addAmount = 0.25;

            health.AddHealth(addAmount, true);

            Assert.AreEqual(currentAmount + addAmount, health.GetCurrentHealth()/health.GetMaximumHealth());
        }


    }
}
