using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkanoid
{
    // пробные
    interface Interface1 
    {
        public void ToReturnBallToPlayer();
       
    }

    interface Interface2
    {
        public void OnReturnBallToPlayer(Interface1 component);
    }


}
