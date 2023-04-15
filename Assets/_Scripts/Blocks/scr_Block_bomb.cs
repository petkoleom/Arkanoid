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
        int radius = 3;

        public void TakeDamage(int dmg)
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, 6);
            foreach (Collider hitCollider in hitColliders)
            {
                print(hitColliders.Length);
                if (hitCollider.tag == "Block")
                {
                    print("hit");
                    hitCollider.gameObject.GetComponent<int_Block>().TakeDamage(5);
                }
            }
            Destroy(gameObject);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            //Use the same vars you use to draw your Overlap Sphere to draw your Wire Sphere.
            Gizmos.DrawWireSphere(transform.position, radius);
        }

    }
}
