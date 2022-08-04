using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _settingsMenuPanel;
    private void Start() => _settingsMenuPanel.gameObject.SetActive(false);
}
