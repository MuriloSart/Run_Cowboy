using Entities.Interfaces;

namespace Entities.Health
{
    public class HealHandle : IHealable
    {
        public virtual int Heal(int heal, int currentLife)
        {
            return currentLife + heal;
        }
    }
}