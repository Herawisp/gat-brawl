using UnityEngine;

namespace Apps.Scripts
{
    public class CrouchAction : MonoBehaviour, ICharacterAction<bool>
    {
        [SerializeField] private float crouchSpeedMultiplier = 0.5f;
        [SerializeField] private float crouchHeight = 0.5f;
        
        private MovementAction _movementAction;
        private CapsuleCollider _collider;
        private float _originalHeight;
        private Vector3 _originalCenter;

        private void Awake()
        {
            _movementAction = GetComponent<MovementAction>();
            _collider = GetComponent<CapsuleCollider>();
            
            if (_collider != null)
            {
                _originalHeight = _collider.height;
                _originalCenter = _collider.center;
            }
        }

        public void Execute(bool isCrouching)
        {
            if (_movementAction == null) return;

            print("FIRED");
            if (isCrouching)
            {
                _movementAction.movementSpeed = _movementAction.baseSpeed * crouchSpeedMultiplier;
                
                if (_collider != null)
                {
                    _collider.height = crouchHeight;
                    _collider.center = new Vector3(_originalCenter.x, crouchHeight / 2f, _originalCenter.z);
                }
            }
            else
            {
                _movementAction.movementSpeed = _movementAction.baseSpeed;
                
                if (_collider != null)
                {
                    _collider.height = _originalHeight;
                    _collider.center = _originalCenter;
                }
            }
        }
    }
}