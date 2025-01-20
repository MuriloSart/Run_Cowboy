using UnityEngine;
using Entities.Interfaces;

namespace Entities.Health
{
    public class DamageHandler : MonoBehaviour, IDamageable
    {
        public virtual int TakeDamage(int damageAmount, int health) => health - damageAmount;
    }
}