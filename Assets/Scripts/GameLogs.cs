using System;
using System.IO;
using UnityEngine;

namespace Arkanoid
{

    public class GameLogs : MonoBehaviour
    {
        public static GameLogs Self;

        private string _path;
        private string _time;

        private void Awake()
        {
            Self = this;
            _path = "Logs.txt";
            _time = DateTime.Now.ToLongTimeString();
        }


        private void Update() => _time = DateTime.Now.ToLongTimeString();

        public void WriteLog(string text)
        {
            if (!File.Exists(_path)) File.Create(_path);
            Debug.Log(text);
            File.AppendAllText(_path, '[' + _time + ']' + text + "\n");
        }

        public string Getpath() => _path;
    }
}
