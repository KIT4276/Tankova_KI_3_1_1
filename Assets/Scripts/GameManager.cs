using UnityEngine;

namespace Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 50)]
        private int _lifesCount = 5;
        public int CurrentlifesCount { get; set; }

        public static GameManager Self;

        private void Start()
        {
            Self = this;
            SetLifesCount();
        }

        public void SetLifesCount()
        {
            CurrentlifesCount = _lifesCount;
            Debug.Log("Lifes count  " + CurrentlifesCount);
        }

        public void SetDamage()
        {
            CurrentlifesCount --;
            Debug.Log("Lifes count  "+CurrentlifesCount);
            if (CurrentlifesCount <= 0)
            {
                LevelController.Self.LvlTransition();
            }
        }
    }
}
