namespace Entities.Health
{
    public class KillHandler : IKillable
    {
        public void Kill(Entity entity)
        {
            entity.GameObject.SetActive(false);
        }
    }
}