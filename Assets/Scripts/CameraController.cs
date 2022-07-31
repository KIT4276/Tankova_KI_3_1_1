using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Arkanoid
{
    public abstract class CameraController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Мяч")]
        private GameObject _ball;

        [SerializeField]
        [Tooltip("Сила броска")]
        [Range(1, 50)]
        private float _throwForce = 1;
        
        private Rigidbody _rigidBody;
        public bool _isPlayerHoldsBall;
        public static CameraController Self;
        
         public Vector3 CurrentPosition
        {
            get => transform.position;
            private set { }
        }
        public bool IsPlayerHoldsBall
        {
            get => _isPlayerHoldsBall;
            set => _isPlayerHoldsBall = value;
        }

        protected  virtual void Start()
        {
            Self = this;
            _rigidBody = _ball.GetComponent<Rigidbody>();
        }

        public void OnThrow(CallbackContext context)
        {
            Debug.Log("OnThrow");
            //Debug.Log(_isPlayerHoldsBall);
            if (_isPlayerHoldsBall != true) return;
            else
            {
                BallComponent.Self.BallCurrentSpeed = BallComponent.Self.BallMoveSpeed;
                _isPlayerHoldsBall = false;
            }
            
        }

        protected void OnCollisionEnter(Collision collision) => _isPlayerHoldsBall = true; // наверное, будет срабатывать там, где не нужно

        
    }
}
