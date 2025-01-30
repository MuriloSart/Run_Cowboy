using UnityEngine;
using UnityEngine.InputSystem;
using Scripts.Entities.Animation;
using Zenject;

namespace Scripts.Entities.Player
{
    public class Movement : MonoBehaviour, IMove
    {
        [Header("Velocity")]
        public float moveSpeed = 5f;

        public IMoveAnimation _animation;

        private Vector3 _currentDirection = Vector3.zero;

        private Vector2 _inputData = Vector2.zero;

        private bool _isMoving = false;

        public Vector3 Direction { get => _inputData; }

        [Inject]
        public void Construct(IMoveAnimation moveAnimation)
        {
            _animation = moveAnimation;
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            _inputData = ctx.ReadValue<Vector2>();
        }

        public virtual void Move()
        {
            _currentDirection = transform.right * _inputData.x + transform.forward * _inputData.y;

            if (_currentDirection.sqrMagnitude > 0.01f)
            {
                _currentDirection = _currentDirection.normalized;
                transform.Translate(_currentDirection * moveSpeed * Time.deltaTime, Space.World);

                if (!_isMoving)
                {
                    _animation?.IsMoving(true);
                    _isMoving = true;
                }
            }
            else
            {
                if (_isMoving)
                {
                    _animation?.IsMoving(false);
                    _isMoving = false;
                }
            }
        }

        private void Update()
        {
            Move();
        }
    }
}
