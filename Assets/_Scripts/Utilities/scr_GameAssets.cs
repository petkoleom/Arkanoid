using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_GameAssets : MonoBehaviour
    {

        private static scr_GameAssets _i;
        public static scr_GameAssets i
        {
            get
            {
                if (_i == null)
                    _i = (Instantiate(Resources.Load("pfb_GameAssets")) as GameObject).GetComponent<scr_GameAssets>();
                return _i;
            }
        }


        [Header("Prefabs")]
        public GameObject playerPrefab;
        public GameObject ballPrefab;
        public GameObject blockPrefab;
        
        [Header("VFX")]
        public GameObject explosion;
        public GameObject stain;

        [Header("SFX")]
        public AudioClip hit;


    }
}
