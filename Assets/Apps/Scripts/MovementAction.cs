using System;
using UnityEngine;

namespace Apps.Scripts
{
    public class MovementAction : MonoBehaviour, ICharacterAction<Vector2>
    {
        [SerializeField, Range(0, 30)] public float movementSpeed;
        
        private Rigidbody _rb;
        private Vector3 _direction;
        private DashAction _dashAction;

        public float baseSpeed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (_rb is null) Debug.LogWarning("No Rigidbody attached to the object", this);
            _dashAction = GetComponent<DashAction>();
        }

        private void Start()
        {
            baseSpeed = movementSpeed;
        }

        private void FixedUpdate()
        {
            if (_dashAction != null && _dashAction.IsDashing) {print("TEST"); return;}
            _direction.y = _rb.linearVelocity.y;
            _rb.linearVelocity = _direction;
        }

        public void Execute(Vector2 info)
        {
            _direction.x = info.x * movementSpeed;
            _direction.z = info.y * movementSpeed;
        }
    }
}