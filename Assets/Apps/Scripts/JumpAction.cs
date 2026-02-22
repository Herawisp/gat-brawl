using UnityEngine;

namespace Apps.Scripts
{
    public class JumpAction : MonoBehaviour, ICharacterAction<float>
    {
        [SerializeField] private float jumpPower = 5f;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (_rb is null) Debug.LogWarning("No Rigidbody attached to the object", this);
        }

        public void Execute(float info)
        {
            if (_rb == null) return;
            Vector3 currentVel = _rb.linearVelocity;
            _rb.linearVelocity = new Vector3(currentVel.x, jumpPower, currentVel.z);
        }
    }
}