using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_Block : MonoBehaviour, int_Block
    {
        [SerializeField]
        int maxHealth = 1;

        int health;

        private void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(int dmg)
        {
            health -= dmg;
            if(health <= 0)
            {
                
                Destroy(gameObject);
            }
        }
    }
}
