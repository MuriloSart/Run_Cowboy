using UnityEngine;

namespace Entities.Health
{
    public class Health : MonoBehaviour
    {
        public int maxHealth;
        public DamageHandler damageHandler;
        public HealHandle healHandler;
        public KillHandler killHandler;

        private int _currentHealth;
        private Entity _entity;

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

        private void Start()
        {
            if (_entity == null)
                _entity = GetComponent<Entity>();
        }

        public void Damage(int damage)
        {
            damageHandler.TakeDamage(damage, _currentHealth);
        }

        public void Heal(int heal)
        {
            healHandler.Heal(heal, _currentHealth);
        }

        public void Kill()
        {
            killHandler.Kill(_entity);
        }
    }
}
