using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_Block_secBall : MonoBehaviour, int_Block
    {
        public void TakeDamage(int dmg)
        {

            scr_UnitManager.Instance.NewBall();

            Destroy(gameObject);
        }
    }
}
