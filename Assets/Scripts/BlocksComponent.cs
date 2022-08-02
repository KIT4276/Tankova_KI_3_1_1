using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BlocksComponent : MonoBehaviour
    {
        [SerializeField]
        protected float _increaseSpeed = 1f;

        [SerializeField]
        protected GameObject ball;

        private LevelController _levelController;
        protected int _destroyedBloks;

        /// <summary>
        /// Событие уничтожения блока
        /// </summary>
        //public event DestroyDelegate OnDestroyEventHandler;
        //Я пыталась...

        private void Start()
        {
            transform.rotation = Random.rotation;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
           // OnDestroyEventHandler?.Invoke(this); // Инициализация события
            BallComponent.Self.BallCurrentSpeed += _increaseSpeed;
            _destroyedBloks++;
            LvlCheck();
        }

        private void LvlCheck()
        {
            Debug.Log("LvlCheck");
            // почему всегда _destroyedBloks == 1??
            Debug.Log("_destroyedBloks" + _destroyedBloks);
            if (_destroyedBloks >= LevelController.Self.Leve1BlocsCount)
            {
                LevelController.Self.CurrentLevel++;
                LevelController.Self.LvlTransition();
            }

        }
    }

    //public delegate void DestroyDelegate(BlocksComponent blocksComponent);
}
