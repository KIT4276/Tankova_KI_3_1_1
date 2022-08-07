using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

namespace Arkanoid
{
    public abstract class CameraController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Мяч")]
        private GameObject _ball;

        [Tooltip("Должно быть активно хотябы у одного в начале игры")]
        public bool _isPlayerHoldsBall;

        public static CameraController Self;

        protected Controls1 controls;

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

        private void Awake() => controls = new Controls1();

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
