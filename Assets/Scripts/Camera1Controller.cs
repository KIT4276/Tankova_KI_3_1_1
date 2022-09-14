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
        }

        //public void OnMovement(Vector2 value)
        //{
        //    transform.Translate(_movementSpeed * Time.deltaTime * new Vector3(value.x, 0, value.y), Space.Self);
        //}

        protected void OnDisable()
        {
            controls.Camera1ActionMap.Disable();
            controls.Camera1ActionMap.Throw.performed -= OnThrow;
        }
    }
}
