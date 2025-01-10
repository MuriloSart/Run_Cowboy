using UnityEngine;

namespace Scripts.Entities.Animation
{
    public class MovementAnimation : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void IsWalking(bool areRunning)
        {
            animator.SetBool("Walk", areRunning);
        }
    }
}

