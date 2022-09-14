using UnityEngine;

namespace Arkanoid
{
    public class BallComponent : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 20)]
        [Tooltip("Скорость мяча")]
        private float _ballSpeed = 1;

        private Vector3 _currenVelocity;

        public static BallComponent Self;
        public float BallCurrentSpeed { get; set; }

        public float BallMoveSpeed 
        {
            get => _ballSpeed;
            private set { }
        }
       
        private void Start() => Self = this;

        private void Update()
        {
            _currenVelocity = transform.forward;

            if (GameManager.IsPlaying) transform.position += BallCurrentSpeed * Time.deltaTime * transform.forward;
        }

        private void OnCollisionEnter(Collision collision) => Rebound(collision);

        private void Rebound(Collision currentCollision)
        {
            transform.forward = Vector3.Reflect(_currenVelocity.normalized, currentCollision.contacts[0].normal);
        }

        public void ToReturnBallToPlayer(Vector3 position, Quaternion rotation)
        {
            BallCurrentSpeed = 0;
            transform.SetPositionAndRotation(position, rotation);
            Camera1Controller.Self.IsPlayerHoldsBall = true;
        }
    }
}
