using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController Self;

        protected int _destroyedBlocs;
        protected int _levelBlocsCount;

        [SerializeField]
        [Tooltip("Первая платформа с камерой")]
        private GameObject Camera1AndPlatform;

        [SerializeField]
        [Tooltip("Вторая платформа с камерой")]
        private GameObject Camera2AndPlatform;

        [SerializeField]
        [Tooltip("Все разрушаемые блоки первого уровня")]
        private List<GameObject> _blocksOn1Lvl;

        [SerializeField]
        [Tooltip("Все разрушаемые блоки второго уровня")]
        private List<GameObject> _blocksOn2Lvl;

        [SerializeField]
        [Tooltip("Все разрушаемые блоки третьего уровня")]
        private List<GameObject> _blocksOn3Lvl;

        //[SerializeField]
        //[Tooltip("Все объекты второго уровня")]
        //private List<GameObject> _Lvl2;

        //[SerializeField]
        //[Tooltip("Все объекты третьего уровня")]
        //private List<GameObject> _Lvl3;

        //List<GameObject> _allCurrentLevel;

        public int CurrentLevel { get; set; }
        public int DestroyedBloks { get; set; }

        private void Awake()
        {
            Self = this;
            CurrentLevel = 1;
            Debug.Log("CurrentLevel " + CurrentLevel);
        }

        public void LvlCheck()
        {
            DestroyedBloks++;
            
            if (CurrentLevel == 1) { _levelBlocsCount = _blocksOn1Lvl.Count; }
            if ( DestroyedBloks >= _levelBlocsCount)
            {
                CurrentLevel++;
                Transition();
                DestroyedBloks = 0;
            }
        }

        public void Transition()
        {
            Camera1AndPlatform.transform.position += new Vector3(15, 0, 0);
            Camera2AndPlatform.transform.position += new Vector3(15, 0, 0);
            LvlTransition();
           
        }
        public void LvlTransition()
        {
             BallComponent.Self.ToReturnBallToPlayer(Camera1AndPlatform.transform.position + new Vector3(0f, -1f, 0f), new Quaternion(0.7f, 0.0f, 0.0f, 0.7f));
            //ToActivateLevel(CurrentLevel);
            Debug.Log("Current Level " + CurrentLevel);
            GameManager.Self.SetStartLifesCount();
            
            if (CurrentLevel == 2) {_levelBlocsCount = _blocksOn2Lvl.Count; }
            if (CurrentLevel == 3) { _levelBlocsCount = _blocksOn3Lvl.Count; }
        }

        public void OnReturnBloks()
        {
            if (CurrentLevel == 1) ReturnBloks(_blocksOn1Lvl);
            if (CurrentLevel == 2) ReturnBloks(_blocksOn2Lvl);
            if (CurrentLevel == 3) ReturnBloks(_blocksOn3Lvl);
        }
        public void ReturnBloks(List<GameObject> blocks)
        {
            foreach (var block in blocks)
            {
                block.gameObject.SetActive(true);
            }
        }


        //private void ToActivateLevel (int level) // нужно доработать
        //{
        //    if (level == 2) { _allCurrentLevel = _Lvl2; }
        //    if (level == 3) { _allCurrentLevel = _Lvl3; }
        //    foreach (var item in _allCurrentLevel)
        //    {
        //        item.SetActive(true);
        //    }
        //}
    }
}
