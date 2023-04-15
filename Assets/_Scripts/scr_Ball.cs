using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_Ball : MonoBehaviour
    {
        Rigidbody2D rb;

        [SerializeField]
        float speed;




        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
 
        }

        private void Update()
        {

            rb.velocity = speed * (rb.velocity.normalized);
        }

        public void ResetBall()
        {
            
            rb.velocity = 0 * (rb.velocity.normalized);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.tag == "Finish")
            {
                scr_GameManager.Instance.LostLife();
            }

            
        }

        public void Launch()
        {
            transform.parent = null;
            Vector2 dir = new Vector2(UnityEngine.Random.Range(-.5f, .5f), 1);
            print(dir);
            rb.velocity = dir;
        }




    }
}
