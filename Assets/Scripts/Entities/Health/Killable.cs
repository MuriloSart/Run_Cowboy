using UnityEngine;

namespace Entities.Health
{
    public class KillHandler : IKillable
    {
        public void Kill(GameObject entity)
        {
            entity.SetActive(false);
        }
    }
}