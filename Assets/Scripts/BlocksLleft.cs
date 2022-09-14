using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class BlocksLleft : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Текстовое поле")]
        public Text _text;

        public static BlocksLleft Self;

        private void Start() => Self = this;

        private void LateUpdate()
        {
            _text.text = LevelController.Self.LevelBlocsCount.ToString();
            if (_text.text == "1") _text.color = Color.red;
            else _text.color = Color.black;
        }
    }
}
