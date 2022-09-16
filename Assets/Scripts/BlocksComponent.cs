using UnityEngine;

namespace Arkanoid
{
    public class BlocksComponent : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Приращение скорости при ударе о блоки")]
        protected float _increaseSpeed = 1f;

        [SerializeField]
        [Tooltip("Мяч")]
        protected GameObject ball;

        [Space, SerializeField]
        private AudioSource _destr;


        public static BlocksComponent Self;

        public delegate void DestroyDelegate(BlocksComponent blocksComponent);
        public event DestroyDelegate DestroyEvent;

        private void Start()
        {
            Self = this;
            transform.rotation = Random.rotation;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _destr.Play();
            gameObject.SetActive(false);
            LevelController.Self.LvlCheck();
        }
    }
}   
