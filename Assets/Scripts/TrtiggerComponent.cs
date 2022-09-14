using UnityEngine;

namespace Arkanoid
{
    public class TrtiggerComponent : MonoBehaviour 
    {
        [SerializeField]
        private bool _isGates1;
        [SerializeField]
        private bool _isGates2;
        [SerializeField]
        private bool _isTunnel;
        [SerializeField]
        private GameObject ball;

        public static TrtiggerComponent Self;

        private void Start()
        {
            Self = this;
            var collider = GetComponent<Collider>();

            if (_isGates1 || _isGates2) collider.isTrigger = true;
            else collider.isTrigger = false;
        }

        private void OnTriggerEnter(Collider other)
        {

            if (_isGates1 || _isGates2)
            {
                Vector3 cameraPosition;//
                if (_isGates1)
                {
                    cameraPosition = Camera1Controller.Self.CurrentPosition + new Vector3(0f, -1f, 0f);
                    var triggerRotation = new Quaternion(0.7f, 0.0f, 0.0f, 0.7f);
                    BallComponent.Self.ToReturnBallToPlayer(cameraPosition, triggerRotation);
                    GameManager.Self.SetDamage();
                }
                else if (_isGates2)
                {
                    cameraPosition = Camera2Controller.Self.CurrentPosition + new Vector3(0f, 1f, 0f);
                    var triggerRotation = new Quaternion(-0.7f, 0.0f, 0.0f, 0.7f);
                    BallComponent.Self.ToReturnBallToPlayer(cameraPosition, triggerRotation);
                    GameManager.Self.SetDamage();
                }
            }
        }
    }
}
