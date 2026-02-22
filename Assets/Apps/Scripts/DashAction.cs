using System.Collections;
using UnityEngine;

namespace Apps.Scripts
{
    public class DashAction : MonoBehaviour, ICharacterAction<Vector2>
    {
        [SerializeField] private float dashForce = 20f;
        [SerializeField] private float dashDuration = 0.2f;
        private Rigidbody _rb;
        public bool IsDashing;

        private void Awake() => _rb = GetComponent<Rigidbody>();

        public void Execute(Vector2 direction)
        {
            if (IsDashing || direction == Vector2.zero) return;
            StartCoroutine(DashCoroutine(direction));
        }

        private IEnumerator DashCoroutine(Vector2 dir)
        {
            IsDashing = true;
            
            Vector3 dashVel = new Vector3(dir.x, 0, dir.y).normalized * dashForce;
            _rb.linearVelocity = dashVel;

            yield return new WaitForSeconds(dashDuration);

            IsDashing = false;
        }
    }
}