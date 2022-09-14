using System;
using System.IO;
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

    public static string Path { get; set; }

    private void Awake()
    {
        Debug.Log("Игра запущена");
        Path = @"C:\Users\Log.txt";
        var time = DateTime.Now.ToLongTimeString();

        if (!File.Exists(Path)) File.Create(Path);
        File.WriteAllText(Path, '[' + time + ']' + " Start Game" + "\n");

        Debug.Log("Файл Log создан");
    }
    private void Start()
    {
        _mainMenuCanvas.SetActive(true);
        _newGameButton.onClick.AddListener(NewGame);
        _exitGameButton.onClick.AddListener(ExitGame);
        _settingsButton.onClick.AddListener(OnSettings);
    }

    private void NewGame() => SceneManager.LoadScene(1);

    private void ExitGame()
    {
        var time = DateTime.Now.ToLongTimeString(); ;
        File.AppendAllText(Path, '[' + time +']' + " Exit Game from main menu" + "\n");
        Debug.Log("Выполнен выход из игры в главном меню");
        Application.Quit();
    }

    private void OnSettings()
    {
        _mainMenuCanvas.SetActive(false);
        _menuSettings.gameObject.SetActive(true);
    }
}
