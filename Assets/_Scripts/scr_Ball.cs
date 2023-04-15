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

        [SerializeField]
        int damage = 1;

        private bool free;

        private int consecutiveWallHits = 0;


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
            SetFree(false);
            rb.velocity = 0 * (rb.velocity.normalized);
            consecutiveWallHits = 0;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.tag == "Player")
            {
                Vector2 cPoint = collision.contacts[0].point;
                float relPoint = collision.transform.position.x - cPoint.x;
                Vector2 newDir = new Vector2(5 * -relPoint, rb.velocity.y);
                rb.velocity = newDir;
                consecutiveWallHits = 0;
            }

            else if(collision.transform.tag == "Finish")
            {
                scr_GameManager.Instance.LostLife();
                consecutiveWallHits = 0;
            }

            else if (collision.transform.tag == "Block")
            {
                collision.gameObject.GetComponent<int_Block>().TakeDamage(damage);
                consecutiveWallHits = 0;
            }

            else
            {
                consecutiveWallHits++;
                if(consecutiveWallHits == 6) 
                {
                    ResetBall();
                }
            }
        }


        public bool isFree() { return free; }
        public void SetFree(bool free) => this.free = free;


        public void Launch()
        {
            SetFree(true);
            transform.parent = null;
            Vector2 dir = new Vector2(UnityEngine.Random.Range(-.5f, .5f), 1);
            rb.velocity = dir;
        }




    }
}
