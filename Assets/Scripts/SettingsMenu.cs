using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField][Tooltip("Меню настроек")]
    private GameObject _settingsMenuPanel;

    [SerializeField][Tooltip("Предыдущее меню")]
    private GameObject _menuPanel;

    [SerializeField][Tooltip("Кнопка возврата")]
    private Button _backButton;

    [SerializeField][Tooltip("Выключение звука")]
    private Toggle _sundOffToggle;

    [SerializeField][Tooltip("Слайдер громкости")]
    private Slider _volumeSlider;

    [SerializeField][Tooltip("Выпадающий список сложности игры")]
    private Dropdown _complexityDropdown;

    private float volume; //для заглушки

    private void SetVolume(float value) => volume = value; //для заглушки

    private void Start()
    {
        _settingsMenuPanel.gameObject.SetActive(false);
        _backButton.onClick.AddListener(Back);
        _sundOffToggle.isOn = false;
    }
    private void LateUpdate()
    {
        if (_sundOffToggle.isOn == true) SundOff();
        SetVolume(_volumeSlider.value); // заглушка
    }

    private void Back()
    {
        _settingsMenuPanel.gameObject.SetActive(false);
        _menuPanel.gameObject.SetActive(true);
    }

    private void SundOff(){} // заглушка
}
