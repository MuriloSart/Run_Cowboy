using System.Xml;

namespace Entities.Health
{
    public interface IKillable
    {
        public void Kill(Entity entity);
    }
}