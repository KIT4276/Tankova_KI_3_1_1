using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 50)]
        private int _lifesCount = 10;

        public int CurrentlifesCount { get; private set; }

        public static GameManager Self;

        public static bool IsPlaying { get; set; }

        private void Awake()
        {
            SceneManager.UnloadSceneAsync(1);
#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Game scene start");
#endif
            SetStartLifesCount();
            IsPlaying = true;
        }
        private void Start() => Self = this;

        public void SetStartLifesCount() => CurrentlifesCount = _lifesCount;

        public void SetDamage()
        {
#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Ball missed");
#endif
            CurrentlifesCount--;

            TextComponent.Self.SetText(CurrentlifesCount.ToString());
            if (CurrentlifesCount <= 0)
            {
                if (LevelController.Self.CurrentLevel == 3) GameOver();
                else LevelController.Self.Transition();
            }
        }
        public void GameOver()
        {
            IsPlaying = false;
            GameLogs.Self.WriteLog("Exit Game" + "\n");
            Application.Quit();
        }
    }
}
