using UnityEngine;
using UnityEngine.InputSystem;
using Scripts.Entities.Animation;

namespace Scripts.Entities.Player
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public MovementAnimation Animation;

        private Vector3 _currentDirection = Vector3.zero;
        private Vector2 _inputData = Vector2.zero;
        private bool _isMoving = false;

        public Vector3 Direction { get => _inputData; }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            _inputData = ctx.ReadValue<Vector2>();
        }

        private void Update()
        {
            _currentDirection = transform.right * _inputData.x + transform.forward * _inputData.y;
            
            if (_currentDirection.sqrMagnitude > 0.01f)
            {
                _currentDirection = _currentDirection.normalized;
                transform.Translate(_currentDirection * moveSpeed * Time.deltaTime, Space.World);

                if (!_isMoving)
                {
                    Animation?.IsWalking(true);
                    _isMoving = true;
                }
            }
            else
            {
                if (_isMoving)
                {
                    Animation?.IsWalking(false);
                    _isMoving = false;
                }
            }
        }
    }
}
