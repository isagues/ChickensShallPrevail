using Interface;

namespace Command
{
    public class CmdApplyDamage : ICommand
    {
        private IDamageable _damageable;
        private int _damage;

        public CmdApplyDamage(IDamageable damageable, int damage)
        {
            _damageable = damageable;
            _damage = damage;
        }

        public void Execute() => _damageable.TakeDamage(_damage);
    }
}