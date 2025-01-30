using UnityEngine;

namespace Scripts.Entities.Animation
{
    public class MovementAnimation : MonoBehaviour, IMoveAnimation
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void IsMoving(bool areRunning)
        {
            animator.SetBool("Walk", areRunning);
        }
    }
}

