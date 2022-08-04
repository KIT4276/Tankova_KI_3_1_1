using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Кнопка меню настроек")]
    private Button _settingsButton;

    [SerializeField]
    [Tooltip("Кнопка новая игра")]
    private Button _newGameButton;

    [SerializeField]
    [Tooltip("Кнопка возобновления игры")]
    private Button _resumeButton;

    [SerializeField]
    [Tooltip("Кнопка выхода из игры")]
    private Button _exitButton;

    [SerializeField]
    private GameObject _menuPausePanel;

    private Controls1 controls;

    private void Awake() => controls = new Controls1();
    private void Start() => _menuPausePanel.gameObject.SetActive(false);

    protected void OnEnable()
    {
        controls.Camera1ActionMap.Enable();
        controls.Camera1ActionMap.Pause.performed += SowPauseMenu;
    }

    private void SowPauseMenu(CallbackContext context)
    {
        _menuPausePanel.gameObject.SetActive(true);
    }





}
