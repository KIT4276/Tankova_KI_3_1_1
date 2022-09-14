using UnityEngine;

namespace Arkanoid
{
    public class Camera1Controller : CameraController
    {
        public static Camera1Controller Self;

        public Vector3 CurrentPosition
        {
            get => transform.position;
            private set { }
        }

        private void Start() => Self = this;
        

        protected void OnEnable()
        {
            controls.Camera1ActionMap.Enable();
            controls.Camera1ActionMap.Throw.performed += OnThrow;
        }

        protected void Update()
        {
            var value = controls.Camera1ActionMap.Moving.ReadValue<Vector2>();
            OnMovement(value);
#if UNITY_EDITOR
            var value2 = controls.Camera1ActionMap.Moving2.ReadValue<Vector2>();
            OnMovement(value2);
#endif
        }

        protected void OnDisable()
        {
            controls.Camera1ActionMap.Disable();
            controls.Camera1ActionMap.Throw.performed -= OnThrow;
        }
    }
}
