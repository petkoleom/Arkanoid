using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_BlockManager : StaticInstance<scr_BlockManager>
    {

        // 5-10 pre made levels, then autogenerated freeplay

        
        //private Dictionary<scr_Block, float> blockTypes = new Dictionary<scr_Block, float>();

        [SerializeField]
        private BlockType[] blockTypes;


        public void GenerateBlocks()
        {
            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 11; j++)
                {
                    int rand = UnityEngine.Random.Range(0, 1000);
                    GameObject block = null;
                    foreach (BlockType blockType in blockTypes)
                    {
                        if (rand >= blockType.probFrom && rand < blockType.probTo)
                        {
                            block = blockType.block;
                        }
                    }

                    GameObject blockGO = Instantiate(block, new Vector2(1.5f * (j - 5), .75f * i), Quaternion.identity);
                    blockGO.transform.SetParent(transform, false);
                }     
            }
        }

        private void Update()
        {
            if (enabled && transform.childCount == 0)
            {
                scr_GameManager.Instance.LevelDone();
                enabled = false;
            }
        }


    }
    [Serializable]
    public struct BlockType
    {
        public GameObject block;
        public int probFrom;
        public int probTo;
    }
}
