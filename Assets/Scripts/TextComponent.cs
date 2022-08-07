using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class TextComponent : MonoBehaviour
    {
        [SerializeField][Tooltip("Текстовое поле")]
        public Text _text;

        public static TextComponent Self;

        private void Start() => Self = this;

        private void LateUpdate()
        { 
            _text.text = GameManager.Self.CurrentlifesCount.ToString();
            if (_text.text == "1") _text.color = Color.red;
        }

        public void SetText(string newText)
        {
            _text.text = newText;
        }
    }
}
