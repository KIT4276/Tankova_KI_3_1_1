using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Arkanoid
{
    public abstract class CameraController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Мяч")]
        private GameObject _ball;
        
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
        }

        public void OnThrow(CallbackContext context)
        {
            if (_isPlayerHoldsBall != true) return;
            else
            {
                BallComponent.Self.BallCurrentSpeed = BallComponent.Self.BallMoveSpeed;
                _isPlayerHoldsBall = false;
            }
        }

        protected void OnCollisionEnter(Collision collision) => _isPlayerHoldsBall = true; 
    }
}
