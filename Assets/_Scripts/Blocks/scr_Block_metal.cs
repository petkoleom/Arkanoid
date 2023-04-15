using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_Block_metal : MonoBehaviour, int_Block
    {
        public void TakeDamage(int dmg)
        {

            scr_UnitManager.Instance.MetalBall();

            Destroy(gameObject);
        }
    }
}
