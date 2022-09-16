using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

namespace Arkanoid
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] [Tooltip("Меню паузы")]
        private GameObject _menuPause;

        [SerializeField] [Tooltip("Меню настроек")]
        private GameObject _menuSettings;

        [Header("Buttons")]
        [SerializeField] [Tooltip("Кнопка меню настроек")]
        private Button _settingsButton;

        [SerializeField] [Tooltip("Кнопка перезапуска")]
        private Button _resumeLevelButton;

        [SerializeField] [Tooltip("Кнопка возобновления игры")]
        private Button _rstartButton;

        [SerializeField] [Tooltip("Кнопка выхода из игры")]
        private Button _exitButton;

        [Space, SerializeField]
        private AudioSource _click;

        private Controls1 controls;

        private void Awake() => controls = new Controls1();
        private void Start()
        {
            _menuPause.SetActive(false);
            _rstartButton.onClick.AddListener(Restart);
            _resumeLevelButton.onClick.AddListener(Resume);
            _exitButton.onClick.AddListener(ExitGame);
            _settingsButton.onClick.AddListener(OnSettings);
        }

        protected void OnEnable()
        {
            controls.Camera1ActionMap.Enable();
            controls.Camera1ActionMap.Pause.performed += SowPauseMenu;
        }

        private void SowPauseMenu(CallbackContext context)
        {
            _menuPause.SetActive(true);
            GameManager.IsPlaying = false;
#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Pause pressed");
#endif
        }

        private void Resume()
        {
            _click.Play();
            _menuPause.SetActive(false);
            GameManager.IsPlaying = true;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = false;
            GameLogs.Self.WriteLog("Resume pressed");
#endif
        }

        public void Restart()
        {
            _click.Play();
            _menuPause.SetActive(false);
            GameManager.IsPlaying = true;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = false;
            GameLogs.Self.WriteLog("Restart pressed");
#endif
            SceneManager.LoadScene(1);
        }

        private void ExitGame()
        {
            _click.Play();
            _menuPause.SetActive(false);
            _menuSettings.SetActive(false);

            GameManager.Self.GameOver();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            UnityEditor.EditorApplication.isPaused = false;
#endif
        }

        private void OnSettings()
        {
            _click.Play();
            _menuPause.SetActive(false);
            _menuSettings.SetActive(true);
#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Enter settings");
#endif
        }

        private void OnDisable()
        {
            controls.Camera1ActionMap.Disable();
            controls.Camera1ActionMap.Pause.performed -= SowPauseMenu;
        }
    }
}
