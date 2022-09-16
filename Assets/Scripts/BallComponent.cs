using UnityEngine;

namespace Arkanoid
{
    public class BallComponent : MonoBehaviour
    {
        [SerializeField]
        [Range(200, 400)]
        [Tooltip("Скорость мяча")]
        private static float _ballSpeedForse = 300;

        [SerializeField]
        private AudioSource _rebound;

        private Vector3 _currenVelocity;

        public static BallComponent Self;
        //public float BallCurrentSpeed { get; set; }

        public static float BallMoveSpeed 
        {
            get => _ballSpeedForse;
            private set { }
        }
       
        private void Start() => Self = this;

        private void Update()
        {
            _currenVelocity = transform.forward;

            //if (GameManager.IsPlaying) transform.position += BallCurrentSpeed * Time.deltaTime * transform.forward;
        }

        private void OnCollisionEnter(Collision collision) => Rebound(collision);

        private void Rebound(Collision currentCollision)
        {
            _rebound.Play();
            transform.forward = Vector3.Reflect(_currenVelocity.normalized, currentCollision.contacts[0].normal);
        }

        public void ToReturnBallToPlayer(Vector3 position, Quaternion rotation)
        {
            //BallCurrentSpeed = 0;
            
            transform.SetPositionAndRotation(position, rotation);
            Camera1Controller.Self.IsPlayerHoldsBall = true;
#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Ball returned to player");
#endif
        }
    }
}
