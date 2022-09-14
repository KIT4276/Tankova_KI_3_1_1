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

        public int CurrentLevel { get; private set; }
        public int DestroyedBloks { get; set; }

        public int LevelBlocsCount 
        { get => _levelBlocsCount;
          private set => _levelBlocsCount = value;
        }

        private void Awake()
        {
            Self = this;
            CurrentLevel = 1;
            Debug.Log("CurrentLevel " + CurrentLevel);
            _levelBlocsCount = _blocksOn1Lvl.Count;
        }

        public void LvlCheck()
        {
            DestroyedBloks++;
            _levelBlocsCount--;
            if (CurrentLevel == 1) LevelChange(_blocksOn1Lvl.Count);
            if (CurrentLevel == 2) LevelChange(_blocksOn2Lvl.Count);
            if(CurrentLevel == 3) Debug.Log(CurrentLevel);
        }

        private void LevelChange(int levelBlocsCount)
        {
            if (DestroyedBloks >= levelBlocsCount)
            {
                if(CurrentLevel == 3) GameManager.Self.GameOver();//------------------------
                else Transition();
            }
        }

        public void Transition()
        {
            CurrentLevel++;
            DestroyedBloks = 0;
            if(CurrentLevel == 2) _levelBlocsCount = _blocksOn2Lvl.Count;
            if (CurrentLevel == 2) _levelBlocsCount = _blocksOn3Lvl.Count;
            Camera1AndPlatform.transform.position += new Vector3(15, 0, 0);
            Camera2AndPlatform.transform.position += new Vector3(15, 0, 0);
            LvlTransition();
        }
        public void LvlTransition()
        {
            BallComponent.Self.ToReturnBallToPlayer(Camera1AndPlatform.transform.position + new Vector3(0f, -1f, 0f), new Quaternion(0.7f, 0.0f, 0.0f, 0.7f));
            
            Debug.Log("Current Level: " + CurrentLevel);
            GameManager.Self.SetStartLifesCount();
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
                block.SetActive(true);
            }
        }
    }
}
