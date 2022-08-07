using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 50)]
        private int _lifesCount = 5;
        public int CurrentlifesCount { get; private set; }

        public static GameManager Self;

        private void Awake() => SetStartLifesCount();
        private void Start() => Self = this;

        public void SetStartLifesCount()
        {
            CurrentlifesCount = _lifesCount;
        }

        public void SetDamage()
        {
            CurrentlifesCount --;

            TextComponent.Self.SetText(CurrentlifesCount.ToString());
            if (CurrentlifesCount <= 0)
            {
                LevelController.Self.Transition();
            }
        }
    }
}
