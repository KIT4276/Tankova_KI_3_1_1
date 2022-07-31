using UnityEngine;

namespace Arkanoid
{
    public class Camera1Controller : CameraController
    {
        public static Camera1Controller Self;

        [SerializeField]
        [Tooltip("Скорость перемещения игрока")]
        [Range(1, 15)]
        private float _movementSpeed = 10;

        private Controls1 controls;

        protected void Awake() => controls = new Controls1();

        private void Start() => Self = this;

        protected void OnEnable()
        {
            controls.Camera1ActionMap.Enable();
            controls.Camera1ActionMap.Throw.performed += OnThrow;
        }

        protected void Update() => OnMovement();
        
        public void OnMovement()
        {
            var value = controls.Camera1ActionMap.Moving.ReadValue<Vector2>();
            transform.Translate(new Vector3(value.x, 0, value.y) * _movementSpeed * Time.deltaTime, Space.Self);
        }

        protected void OnDisable()
        {
            controls.Camera1ActionMap.Disable();
            controls.Camera1ActionMap.Throw.performed -= OnThrow;
        }
    }
}
