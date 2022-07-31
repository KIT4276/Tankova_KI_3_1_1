using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Arkanoid
{
    public class BallComponent : MonoBehaviour
    {
        public static BallComponent Self;
        [SerializeField]
        [Range(1, 20)]
        private float _ballSpeed = 1;

        [SerializeField]
        private float _increaseSpeed = 0.0005f;

        private Rigidbody _rigidbody;

        private float _ballCurrentSpeed;

        public float BallCurrentSpeed { get; set; }

        private Vector3 _currenVelocity; // с физикой

        public float BallMoveSpeed 
        {
            get => _ballSpeed;
            private set { }
        }

        
       
        private void Start()
        {
            Self = this;
            _rigidbody = GetComponent<Rigidbody>();
            //StartCoroutine(MoveForvard());

            //_rigidbody.AddForce(new Vector3(0f, 1f, 0f)); // с физикой
            Debug.Log(transform.rotation);
        }
        private void Update()
        {
            _currenVelocity = transform.forward;

            transform.position += transform.forward * BallCurrentSpeed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var r = collision.gameObject;
            Debug.Log(r);
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
