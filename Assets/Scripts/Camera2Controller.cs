using UnityEngine;

namespace Arkanoid
{
    public class Camera2Controller : CameraController
    {
        public static Camera2Controller Self;

        [SerializeField]
        [Tooltip("Скорость перемещения игрока")]
        [Range(1, 15)]
        private float _movementSpeed = 10;

        private Controls1 controls;

        protected void Awake() => controls = new Controls1();
        
        private void Start() => Self = this;
        
        protected void OnEnable()
        {
            controls.Camera2ActionMap.Enable();
            controls.Camera2ActionMap.Throw.performed += OnThrow;
        }

        protected void Update() => OnMovement();

        public void OnMovement()
        {
            var value = controls.Camera2ActionMap.Moving.ReadValue<Vector2>();
            transform.Translate(_movementSpeed * Time.deltaTime * new Vector3(value.x, 0, value.y), Space.Self);
        }

        protected void OnDisable()
        {
            controls.Camera2ActionMap.Disable();
            controls.Camera2ActionMap.Throw.performed -= OnThrow;
        }
    }
}
