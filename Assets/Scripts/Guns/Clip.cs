using System.Collections.Generic;
using UnityEngine;

namespace Guns
{ 
    public class Clip : MonoBehaviour
    {
        public int projectilesAmount;
        public int bulletAmount = 6;

        private int _currentBullet = 1;

        private void Update()
        {
            if (_currentBullet > bulletAmount) _currentBullet = 1;
        }
    }
}
