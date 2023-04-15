using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_UnitManager : Singleton<scr_UnitManager>
    {

        [SerializeField]
        Vector3 spawn;

        GameObject player;
        GameObject ball;

        [SerializeField]
        Vector3 ballOffset;

        public void Spawn()
        {
            player = Instantiate(scr_GameAssets.i.playerPrefab, spawn, Quaternion.identity);
            ball = Instantiate(scr_GameAssets.i.ballPrefab, spawn + ballOffset, Quaternion.identity);
            ball.transform.parent = player.transform;
        }

        public void NewBall()
        {
            var newBall = Instantiate(scr_GameAssets.i.ballPrefab, ball.transform.position, Quaternion.identity);
            //newBall.GetComponent<scr_Ball>().NewBall();
        }

        public void MetalBall()
        {
            ball.GetComponent<scr_Ball>().MetalBall();

        }

        public void ResetPositions()
        {
            ball.transform.parent = player.transform;
            ball.transform.position = player.transform.position + ballOffset;
            ball.GetComponent<scr_Ball>().ResetBall();
        }

        public void Despawn()
        {
            Destroy(player);
            Destroy(ball);
        }
    }
}
