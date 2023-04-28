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

            Remove();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Remove();
        }

        private void Remove()
        {
            scr_AudioManager.Instance.PlaySound(scr_GameAssets.i.hitSFX);
            scr_BlockManager.Instance.blockList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
