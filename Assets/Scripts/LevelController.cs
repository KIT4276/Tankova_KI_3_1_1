using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController Self;

        public int Leve1BlocsCount { get; set; }
        public int Leve2BlocsCount { get; set; }

        protected int _destroyedBlocs;

        [SerializeField]
        private GameObject Camera1AndPlatform;

        [SerializeField]
        private GameObject Camera2AndPlatform;

        [SerializeField]
        private List<GameObject> _blocksOn1Lvl;

        [SerializeField]
        private List<GameObject> _blocksOn2Lvl;

        public int CurrentLevel { get; set; }
        //protected int _destroyedBloks;

        private void Awake()
        {
            Self = this;
            CurrentLevel = 1;
            Leve1BlocsCount = _blocksOn1Lvl.Count;
            Leve2BlocsCount = _blocksOn2Lvl.Count;
        }
        private void Start()
        {
            //OnDestroyEventHandler += LvlCheck; //что я делаю не так?!
        }
        //public void LvlCheck(BlocksComponent blocksComponent)
        //{
        //    Debug.Log("LvlCheck");
        //    _destroyedBloks++;
        //    if (_destroyedBlocs >= Leve1BlocsCount)
        //    {
        //        CurrentLevel++;
        //        LvlTransition();
        //    }
        //}
        public void LvlTransition()
        {
            if (CurrentLevel == 2)
            {
                Camera1AndPlatform.transform.position += new Vector3(15, 0, 0);
                Camera2AndPlatform.transform.position += new Vector3(15, 0, 0);
                //ещё здесь можно использовать SetActive, чтобы сразу все уровни
                //не были активны, а включать их по мере надобности, но пока не до того
            }

            if (CurrentLevel == 3)
            {
                //в принципе, те же действия, что и для второго уровня
            }
        }
    }
}
