using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace darkvoyagestudios
{
    public class scr_Block_bomb : MonoBehaviour, int_Block
    {

        [SerializeField]
        float radius = 2.5f;

        [SerializeField]
        private LayerMask blocks;

        public void TakeDamage(int dmg)
        {

            Explode();
            Remove();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Explode();
            Remove();
        }

        private void Explode()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, blocks);

            Instantiate(scr_GameAssets.i.explosionVFX, transform.position, Quaternion.identity);

            foreach (Collider2D hitCollider in hitColliders)
            {

                if (hitCollider.tag == "Block")
                {

                    hitCollider.gameObject.GetComponent<int_Block>().TakeDamage(5);
                }
            }
        }

        private void Remove()
        {
            scr_AudioManager.Instance.PlaySound(scr_GameAssets.i.explosionSFX);
            scr_BlockManager.Instance.blockList.Remove(gameObject);
            Destroy(gameObject);
        }

    }
}
