namespace Unit
{
    public class Health
    {
        private double currentHealth;
        private double maximumHealth;
        private double percentageHealth;
        private const double oneHundred = MagicValues.MagicValues.hundred;
        private const double one = MagicValues.MagicValues.one;

        public Health()
        {
            maximumHealth = currentHealth = oneHundred;
            percentageHealth = one;
        }

        public Health(double currentHealth, double maximumHealth, double? percentageHealth=null)
        {
            this.maximumHealth = maximumHealth;
            this.currentHealth = currentHealth;
            this.percentageHealth = percentageHealth ?? one;
        }

        public double getCurrentHealth()
        {
            return currentHealth;
        }

        public double getPercentHealth()
        {
            return percentageHealth;
        }

        public double getMaximumHealth()
        {
            return maximumHealth;
        }

        public void AddCurrentHealth(double health)
        {
            var futureHealth = currentHealth + health;
            currentHealth = AddHealth(futureHealth, maximumHealth, currentHealth);
        }

        public void AddPercentageHealth(double health)
        {
            var futureHealth = percentageHealth + health;
            percentageHealth = AddHealth(futureHealth, one, percentageHealth);
        }

        private double AddHealth(double futureHealth, double maxHealth, double actualHealth)
        {
            if(futureHealth > maxHealth)
            {
                actualHealth = maxHealth;
            }
            else
            {
                actualHealth = futureHealth;
            }
            return actualHealth;
        }
    }
}
