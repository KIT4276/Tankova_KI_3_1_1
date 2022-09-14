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
            gameObject.SetActive(false);
            LevelController.Self.LvlCheck();
        }
    }
}   
