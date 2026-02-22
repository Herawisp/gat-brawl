using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        // attributes
        private MovementAction _movementAction;
        private JumpAction _jumpAction;
        private DashAction _dashAction;
        private SprintAction _sprintAction;
        private CrouchAction _crouchAction;

        private Vector2 _currentMoveInput;

        private void Awake()
        {
            _movementAction = GetComponent<MovementAction>();
            _jumpAction = GetComponent<JumpAction>();
            _dashAction = GetComponent<DashAction>();
            _sprintAction = GetComponent<SprintAction>();
            _crouchAction = GetComponent<CrouchAction>();
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            if (_movementAction is null)
            {
                Debug.LogWarning("Component MovementAction is not attached to the object", this);
                return;
            }
        
            if (ctx.performed || ctx.canceled)
            {
                _currentMoveInput = ctx.ReadValue<Vector2>();
                _movementAction.Execute(_currentMoveInput);
            }
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (ctx.performed && _jumpAction != null)
            {
                _jumpAction.Execute(1f); 
            }
        }

        public void OnDash(InputAction.CallbackContext ctx)
        {
            if (ctx.performed && _dashAction != null)
            {
                Vector2 dashDirection = _currentMoveInput == Vector2.zero ? new Vector2(0, 1) : _currentMoveInput;
                _dashAction.Execute(dashDirection);
            }
        }

        public void OnSprint(InputAction.CallbackContext ctx)
        {
            if (_sprintAction == null) return;

            if (ctx.performed)
            {
                _sprintAction.Execute(true);
                _movementAction.Execute(_currentMoveInput);
            }
            else if (ctx.canceled)
            {
                _sprintAction.Execute(false);
                _movementAction.Execute(_currentMoveInput);
            }
        }

        public void OnCrouch(InputAction.CallbackContext ctx)
        {
            if (_crouchAction == null) return;

            if (ctx.performed)
            {
                _crouchAction.Execute(true);
                _movementAction.Execute(_currentMoveInput);
            }
            else if (ctx.canceled)
            {
                _crouchAction.Execute(false);
                _movementAction.Execute(_currentMoveInput);
            }
        }
    }
}
