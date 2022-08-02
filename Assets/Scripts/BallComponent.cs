using UnityEngine;

namespace Arkanoid
{
    public class BallComponent : MonoBehaviour
    {
        public static BallComponent Self;
        [SerializeField]
        [Range(1, 20)]
        private float _ballSpeed = 1;

        private Vector3 _currenVelocity;
        public float BallCurrentSpeed { get; set; }

        public float BallMoveSpeed 
        {
            get => _ballSpeed;
            private set { }
        }
       
        private void Start()
        {
            Self = this;
        }
        private void Update()
        {
            _currenVelocity = transform.forward;
            transform.position += transform.forward * BallCurrentSpeed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Rebound(collision);
        }

        private void Rebound(Collision currentCollision)
        {
            transform.forward = Vector3.Reflect(_currenVelocity.normalized, currentCollision.contacts[0].normal);
        }

        public void ToReturnBallToPlayer(Vector3 position, Quaternion rotation)
        {
            BallComponent.Self.BallCurrentSpeed = 0;
            transform.position = position;
            transform.rotation = rotation;

            Camera1Controller.Self.IsPlayerHoldsBall = true;
            Camera2Controller.Self.IsPlayerHoldsBall = true;
        }
    }
}
