namespace Entities.Interfaces
{
    public interface IHealable
    {
        public int Heal(int amountHeal, int currentLife);
    }
}