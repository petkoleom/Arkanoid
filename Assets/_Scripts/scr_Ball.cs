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

        public bool metal = false;

        [SerializeField]
        float speed;

        [SerializeField]
        int damage = 1;

        private bool free;

        private int consecutiveWallHits = 0;

        [SerializeField]
        private LayerMask blocks;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
           
        }

        private void Update()
        {

            rb.velocity = speed * (rb.velocity.normalized);

            RaycastCheck();
        }

        private void RaycastCheck()
        {
            Collider2D hit = Physics2D.OverlapArea(transform.position, rb.velocity, blocks);



            if(hit.GetComponent<Collider>() != null)
            {
                print(hit.GetComponent<Collider>().name);
                if (hit.GetComponent<Collider>().tag == "Block")
                {
                    print("hit");
                    hit.GetComponent<Collider>().GetComponent<int_Block>().TakeDamage(damage);
                }
            }
        }

        public void ResetBall()
        {
            SetFree(false);
            rb.velocity = 0 * (rb.velocity.normalized);
            consecutiveWallHits = 0;
        }

        public void NewBall()
        {
            float randomOffset = UnityEngine.Random.Range(0, 0.3f);
            rb.velocity += new Vector2(randomOffset, randomOffset);
        }

        public void MetalBall()
        {
            metal = true;
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

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, rb.velocity, Color.green);
        }


    }
}
