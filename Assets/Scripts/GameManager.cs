using System;
using System.IO;
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

        public static string Path { get; set; }

        public static bool IsPlaying { get; set; }

        private void Awake()
        {
            Path = @"C:\Users\Log.txt";
            SceneManager.UnloadSceneAsync(1);
            Debug.Log("Старт игровой сцены");
            var time = DateTime.Now.ToLongTimeString();
            File.AppendAllText(Path, '[' + time + ']' + "Game scene start" + "\n");
            SetStartLifesCount();
            IsPlaying = true;
        }
        private void Start() => Self = this;

        public void SetStartLifesCount() => CurrentlifesCount = _lifesCount;

        public void SetDamage()
        {
            Debug.Log("Мяч упущен");
            File.AppendAllText(Path, "Ball missed" + "\n");
            CurrentlifesCount --;

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
            var time = DateTime.Now.ToLongTimeString();
            File.AppendAllText(Path, '[' + time + ']' + " Exit Game" + "\n");
            Debug.Log("Выполнен выход из игры");
            //SceneManager.LoadScene(0);
            Application.Quit();
        }
    }
}
