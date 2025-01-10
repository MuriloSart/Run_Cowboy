using UnityEngine;
using UnityEngine.InputSystem;
namespace Scripts.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Settings")]
        public float moveSpeed = 5f;
        public Transform cameraTransform;
        public Movement playerMovement;

        private Vector3 _direction;

        private void Update()
        {
            _direction = playerMovement.Direction;
            if (_direction.sqrMagnitude > 0.01f)
            {
                Vector3 forward = cameraTransform.forward;
                Vector3 right = cameraTransform.right;

                forward.y = 0;
                right.y = 0;

                forward.Normalize();
                right.Normalize();

                Vector3 moveDirection = forward * _direction.z + right * _direction.x;

                Quaternion targetRotation = Quaternion.LookRotation(forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }
}
