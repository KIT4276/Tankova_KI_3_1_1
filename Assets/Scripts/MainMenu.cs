using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Menu panels")]
        [SerializeField]
        [Tooltip("Канва главного меню")]
        private GameObject _mainMenuCanvas;

        [SerializeField]
        [Tooltip("Меню настроек")]
        private GameObject _menuSettings;

        [Header("Buttons")]
        [SerializeField]
        [Tooltip("Кнопка новая игра")]
        private Button _newGameButton;

        [SerializeField]
        [Tooltip("Кнопка выхода из игры")]
        private Button _exitGameButton;

        [SerializeField]
        [Tooltip("Кнопка меню настроек")]
        private Button _settingsButton;

        [SerializeField]
        private AudioSource _clickSound;

        private void Start()
        {
            GameLogs.Self.WriteLog("Start Game");
            _mainMenuCanvas.SetActive(true);
            _newGameButton.onClick.AddListener(NewGame);
            _exitGameButton.onClick.AddListener(ExitGame);
            _settingsButton.onClick.AddListener(OnSettings);
        }

        private void NewGame()
        {
            _clickSound.Play();
            SceneManager.LoadScene(1);
        }

        private void ExitGame()
        {
            _clickSound.Play();
            GameLogs.Self.WriteLog("Exit Game" + "\n");
            Application.Quit();
        }

        private void OnSettings()
        {
            _clickSound.Play();
            _mainMenuCanvas.SetActive(false);
            _menuSettings.gameObject.SetActive(true);
#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Settings pressed");
#endif
        }
    }
}
