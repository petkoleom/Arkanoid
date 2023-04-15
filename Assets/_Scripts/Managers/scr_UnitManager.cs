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
            print("test");
            player = Instantiate(scr_GameAssets.i.playerPrefab, spawn, Quaternion.identity);
            ball = Instantiate(scr_GameAssets.i.ballPrefab, spawn + ballOffset, Quaternion.identity);
            ball.transform.parent = player.transform;
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
        }
    }
}