namespace Character
{
    public class Health
    {
        public int Current => _current;
        private int _current;

        private int _max;
        public int Max => _max;

        public Health(int maxHealth)
        {
            _max = maxHealth;
            _current = maxHealth;
        }

        public void TakeDamage(int amount) => _current -= amount;
    }
}