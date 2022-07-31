using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

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

        //public Vector3 CurrentPosition
        //{
        //    get => transform.position;
        //    private set { }
        //}

        protected void Awake()
        {
            controls = new Controls1();
        }
        private void Start()
        {
            Self = this;
            Debug.Log(transform.rotation);
        }
        protected void OnEnable()
        {
            controls.Camera2ActionMap.Enable();
            controls.Camera2ActionMap.Throw.performed += OnThrow;
        }

        protected void Update()
        {
            OnMovement();
        }
        public void OnMovement()
        {
            var value = controls.Camera2ActionMap.Moving.ReadValue<Vector2>();
            transform.Translate(new Vector3(value.x, 0, value.y) * _movementSpeed * Time.deltaTime, Space.Self);
        }

        protected void OnDisable()
        {
            controls.Camera2ActionMap.Disable();
            controls.Camera2ActionMap.Throw.performed -= OnThrow;
        }
        
    }
}
