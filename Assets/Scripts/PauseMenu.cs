using UnityEngine;
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

        [SerializeField] [Tooltip("Кнопка перезапуска уровня")]
        private Button _resumeLevelButton;

        [SerializeField] [Tooltip("Кнопка возобновления игры")]
        private Button _rstartButton;

        [SerializeField] [Tooltip("Кнопка выхода из игры")]
        private Button _exitButton;

        private Controls1 controls;

        private void Awake() => controls = new Controls1();
        private void Start()
        {
            _menuPause.gameObject.SetActive(false);
            _rstartButton.onClick.AddListener(Resume);
            _resumeLevelButton.onClick.AddListener(RestartLevel);
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
            _menuPause.gameObject.SetActive(true);
            UnityEditor.EditorApplication.isPaused = true;
        }

        private void Resume()
        {
            _menuPause.gameObject.SetActive(false);
            UnityEditor.EditorApplication.isPaused = false;
        }

        private void RestartLevel()// не работает. почему?
        {
            _menuPause.gameObject.SetActive(false);
            UnityEditor.EditorApplication.isPaused = false;
            LevelController.Self.OnReturnBloks();
            GameManager.Self.SetStartLifesCount();
        }

        private void OnDisable()
        {
            controls.Camera1ActionMap.Disable();
            controls.Camera1ActionMap.Pause.performed -= SowPauseMenu;
        }

        private void ExitGame()
        {
            _menuPause.gameObject.SetActive(false);
            _menuSettings.gameObject.SetActive(false);
            UnityEditor.EditorApplication.isPlaying = false;
        }

        private void OnSettings()
        {
            _menuPause.gameObject.SetActive(false);
            _menuSettings.gameObject.SetActive(true);
        }
    }
}
