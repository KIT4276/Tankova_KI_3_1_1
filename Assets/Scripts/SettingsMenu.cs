using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Complexity : byte
{
    Light = 0,
    Medium = 1,
    Heavy = 2
}

namespace Arkanoid
{
    public class SettingsMenu : MonoBehaviour
    {
        [Header("Menu panels")]
        [SerializeField]
        [Tooltip("Меню настроек")]
        private GameObject _settingsMenuPanel;

        [SerializeField]
        [Tooltip("Предыдущее меню")]
        private GameObject _menuPanel;

        [Header("Menu elements")]
        [SerializeField]
        [Tooltip("Кнопка возврата")]
        private Button _backButton;

        [SerializeField]
        [Tooltip("Выключение звука")]
        private Toggle _sundOffToggle;

        [SerializeField]
        [Tooltip("Слайдер громкости")]
        private Slider _volumeSlider;

        [SerializeField]
        [Tooltip("Выпадающий список сложности игры")]
        private Dropdown _complexityDropdown;

        [Space, SerializeField]
        private AudioSource _click;
        [SerializeField]
        private AudioSource _dropDouvClick;
        [SerializeField]
        private AudioSource _ambient;

        private Complexity _complexity;

        private float _volume; //для заглушки

        private bool _sundOff;

        private void Start()
        {
            _settingsMenuPanel.SetActive(false);
            _backButton.onClick.AddListener(Back);
            SetAllSettings();
        }

        private void SetAllSettings()
        {
            _complexityDropdown.value = ((byte)DataHolder._complexity);
            _volumeSlider.value = DataHolder._volume;
            _sundOffToggle.isOn = DataHolder._sundOff;
        }

        private void Back()
        {
            _click.Play();
            _settingsMenuPanel.SetActive(false);
            _menuPanel.SetActive(true);

#if UNITY_EDITOR
            GameLogs.Self.WriteLog("Return from settings menu");
#endif
        }

        public void GetDropdown(int value)
        {
            _dropDouvClick.Play();
            switch (value)
            {
                case 0:
                    _complexity = Complexity.Light;
                    break;
                case 1:
                    _complexity = Complexity.Medium;
                    break;
                case 2:
                    _complexity = Complexity.Heavy;
                    break;
            }
            DataHolder._complexity = _complexity;
        }

        public void GetVolume()
        {
            _click.Play();
            _volume = _volumeSlider.value;
            DataHolder._volume = _volumeSlider.value;
            _ambient.volume = _volume;
        }

        public void GetSundOff()
        {
            _click.Play();
            _sundOff = _sundOffToggle.isOn;
            DataHolder._sundOff = _sundOffToggle.isOn;
            _ambient.mute = _sundOff;
        }
    }
}
