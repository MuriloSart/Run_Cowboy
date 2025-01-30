using Entities.Interfaces;
using UnityEngine;

namespace Entities.Health
{
    public class Health : MonoBehaviour
    {
        public int maxHealth;

        public IKillable killHandler;
        public IHealable healHandler;
        private IDamageable damageHandler;

        private int _currentHealth = 1;
        public int CurrentHealth
        { 
            get => _currentHealth;
            set
            {
                if (value < 0)
                    _currentHealth = 0;
                else if (value > maxHealth)
                    _currentHealth = maxHealth;
                else
                    _currentHealth = value;
            }
        }

        private void OnValidate()
        {
            killHandler ??= new KillHandler();

            healHandler ??= new HealHandle();

            damageHandler ??= new DamageHandler();
        }

        private void Update()
        {
            if(_currentHealth == 0)
                Kill();
        }

        public void Damage(int damage)
        {
            _currentHealth = damageHandler.TakeDamage(damage, _currentHealth);
        }

        public void Heal(int heal)
        {
            _currentHealth = healHandler.Heal(heal, _currentHealth);
        }

        public void Kill()
        {
            killHandler.Kill(gameObject);
        }
    }
}
