using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Канва главного меню")]
    private GameObject _mainMenuCanvas;

    [Header("Buttons")]
    [SerializeField][Tooltip("Кнопка новая игра")]
    private Button _newGameButton;

    [SerializeField][Tooltip("Кнопка выхода из игры")]
    private Button _exitGameButton;

    private void Start()
    {
        _mainMenuCanvas.gameObject.SetActive(true);
        _newGameButton.onClick.AddListener(NewGame);
        _exitGameButton.onClick.AddListener(ExitGame);
    }

    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
