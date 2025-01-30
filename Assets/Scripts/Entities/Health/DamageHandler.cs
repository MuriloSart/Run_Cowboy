using Entities.Interfaces;

namespace Entities.Health
{
    public class DamageHandler : IDamageable
    {
        public virtual int TakeDamage(int damageAmount, int health) => health - damageAmount;
    }
}