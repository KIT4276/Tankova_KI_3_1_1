using UnityEngine;

namespace Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField][Range(5,50)]
        private float _lifesCount = 5;

        public static GameManager Self;

        private void Start()
        {
            Self = this;
            Debug.Log("Lifes count  " + _lifesCount);
        }

        public void SetDamage()
        {
            _lifesCount --;
            Debug.Log("Lifes count  "+_lifesCount);
        }
    }
}
