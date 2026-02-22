using UnityEngine;

namespace Apps.Scripts
{
    public class SprintAction : MonoBehaviour, ICharacterAction<bool>
    {
        [SerializeField] private float sprintMultiplier = 2f;
        private MovementAction _movementAction;

        private void Awake()
        {
            _movementAction = GetComponent<MovementAction>();
        }

        public void Execute(bool isSprinting)
        {
            if (_movementAction == null) return;

            if (isSprinting)
            {
                _movementAction.movementSpeed = _movementAction.baseSpeed * sprintMultiplier;
            }
            else
            {
                _movementAction.movementSpeed = _movementAction.baseSpeed;
            }
        }
    }
}