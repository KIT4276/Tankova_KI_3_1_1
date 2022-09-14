using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu panels")]
    [SerializeField][Tooltip("Канва главного меню")]
    private GameObject _mainMenuCanvas;

    [SerializeField][Tooltip("Меню настроек")]
    private GameObject _menuSettings;

    [Header("Buttons")]
    [SerializeField][Tooltip("Кнопка новая игра")]
    private Button _newGameButton;

    [SerializeField][Tooltip("Кнопка выхода из игры")]
    private Button _exitGameButton;

    [SerializeField][Tooltip("Кнопка меню настроек")]
    private Button _settingsButton;

    private void Start()
    {
        _mainMenuCanvas.SetActive(true);
        _newGameButton.onClick.AddListener(NewGame);
        _exitGameButton.onClick.AddListener(ExitGame);
        _settingsButton.onClick.AddListener(OnSettings);
    }

    private void NewGame() => SceneManager.LoadScene(1);

    private void ExitGame() => Application.Quit();

    private void OnSettings()
    {
        _mainMenuCanvas.SetActive(false);
        _menuSettings.gameObject.SetActive(true);
    }
}
