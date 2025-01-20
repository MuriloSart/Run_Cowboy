using UnityEngine;

namespace Entities.Interfaces
{
    public interface IDamageable
    {
        public int TakeDamage(int damageAmount, int health);
    }
}