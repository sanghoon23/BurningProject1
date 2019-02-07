using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour 
{
    // **** Public ****

    public Block[] blockList;

    public GameObject blocks;

    public GameObject[] upBlocks;
    public GameObject[] downBlocks;
    public GameObject[] rightBlocks;
    public GameObject[] leftBlocks;

    public Transform tf;

    // **** Private ****
    private int blockNum = 6;

    private void Awake()
    {
        tf = GetComponent<Transform>();

        GameSet_Start();
    }

    private void Start()
    {
        
    }

    // 처음 켜졌을 때 생성된 후 랜덤 setActive = true;
    void GameSet_Start()
    {
        // 블록 생성(오브젝트 풀)
        CreateUpBlock();
        //CreateDownBlock();
        //CreateRightBlock();
        //CreateLeftBlock();

        
    }

    // world 좌표로 오브젝트를 넣어야 한다.
    void CreateUpBlock()
    {
        blockList = new Block[blockNum];

        for (int i = 0; i < blockNum; i++)
        {
            //blockList[i] = GameObject.Instantiate(blocks, tf.position + new Vector3(i, 0, 0), Quaternion.identity) as GameObject;
            //blockList[i].SetActive(false);

            GameObject go = Instantiate(blocks,  new Vector2(Values.firstX, Values.firstY), Quaternion.identity) as GameObject;
        }
    }

    //public void InitializeBlock()
    //{
    //    for (int x = 0; x < width; ++x)
    //    {
    //        //TODO : check match and reset color
    //        for (int y = 0; y < height; ++y)
    //        {
    //            GameObject go = Instantiate(blockPrefab) as GameObject;
    //            go.transform.parent = transform;
    //            go.name = "block";
    //            go.transform.localPosition = new Vector2(x, y);

    //            Block block = go.GetComponent<Block>();
    //            blockList[x, y] = block;

    //            block.SetData(x, y);
    //        }
    //    }

        //void CreateDownBlock()
        //{
        //    downBlocks = new GameObject[blockNum];

        //    for(int i = 0; i < blockNum; i++)
        //    {
        //        downBlocks[i] = GameObject.Instantiate(blocks[1], tf.position + new Vector3(i,0,0), Quaternion.identity) as GameObject;
        //        downBlocks[i].SetActive(false);
        //    }
        //}

        //void CreateRightBlock()
        //{
        //    rightBlocks = new GameObject[blockNum];

        //    for (int i = 0; i < blockNum; i++)
        //    {
        //        rightBlocks[i] = GameObject.Instantiate(blocks[2], tf.position + new Vector3(i, 0, 0), Quaternion.identity) as GameObject;
        //        rightBlocks[i].SetActive(false);
        //    }
        //}

        //void CreateLeftBlock()
        //{
        //    leftBlocks = new GameObject[blockNum];

        //    for (int i = 0; i < blockNum; i++)
        //    {
        //        leftBlocks[i] = GameObject.Instantiate(blocks[3], tf.position + new Vector3(i, 0, 0), Quaternion.identity) as GameObject;
        //        leftBlocks[i].SetActive(false);
        //    }
        //}
    }
