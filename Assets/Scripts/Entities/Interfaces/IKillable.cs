using UnityEngine;

namespace Entities.Health
{
    public interface IKillable
    {
        public void Kill(GameObject entity);
    }
}