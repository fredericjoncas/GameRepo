using System;

namespace Unit
{
    public class Health
    {
        private double currentHealth;
        private double maximumHealth;
        private double percentageHealth;private readonly double minimumHealth;
        private const double OneHundred = MagicValues.MagicValues.Hundred;
        private const double One = MagicValues.MagicValues.One;
        private const double Zero = MagicValues.MagicValues.Zero;
        private bool isDead;

        public Health()
        {
            maximumHealth = currentHealth = OneHundred;
            percentageHealth = One;
            minimumHealth = Zero;
        }

        public Health(double currentHealth, double maximumHealth, double? percentageHealth=null, double? minimumHealth = null)
        {
            this.maximumHealth = maximumHealth;
            this.minimumHealth = minimumHealth ?? Zero;
            this.currentHealth = currentHealth;
            this.percentageHealth = percentageHealth ?? One;
        }

        public double GetCurrentHealth()
        {
            return currentHealth;
        }

        public bool GetIsDead()
        {
            return isDead;
        }

        public double GetPercentHealth()
        {
            return percentageHealth;
        }

        public double GetMaximumHealth()
        {
            return maximumHealth;
        }

        public double GetMinimumHealth()
        {
            return minimumHealth;
        }

        public void AddHealth(double health, bool isPercent)
        {
            double myHealth;
            double maxHealth;
            if (isPercent)
            {
                myHealth = percentageHealth;
                maxHealth = One;
            }
            else
            {
                myHealth = currentHealth;
                maxHealth = maximumHealth;
            }
            var futureHealth = myHealth + health;
            AddHealth(futureHealth, maxHealth, isPercent);
        }

        private void AddHealth(double futureHealth, double maxHealth, bool isPercent)
        {
            var newHealth = futureHealth > maxHealth ? maxHealth : futureHealth;

            if (newHealth <= minimumHealth)
            {
                isDead = true;
                currentHealth = minimumHealth;
                percentageHealth = minimumHealth / maximumHealth;
                return;
            }

            if (isPercent)
            {
                percentageHealth = newHealth;
            }
            else
            {
                currentHealth = newHealth;
            }
            EqualizeHealth(isPercent);
        }

        private void EqualizeHealth(bool isPercent)
        {
            if (isPercent)
            {
                currentHealth = percentageHealth * maximumHealth;
            }
            else
            {
                percentageHealth = currentHealth / maximumHealth;
            }
        }
    }
}
