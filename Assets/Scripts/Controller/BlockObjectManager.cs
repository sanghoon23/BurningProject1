using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObjectManager : MonoBehaviour 
{
    // *** Public ***
    public GameObject blockPrefab;
    public Block Temp; // 임시 Block 오브젝트
    public Block[] blockList;

    // *** Private ***
    Transform tf;
    int blockNum = 7; // 블록리스트 갯수 
    int exploNum = 1; // 폭발될 블록 순서 번호

    int blanceNum = 10;
    int listNum = 0;

    bool noneCreate = false;
    
    void Awake()
    {
        tf = GetComponent<Transform>();

        blockList = new Block[blockNum];
        blanceNum -= blockNum;
    }

    void Start()
    {
        InitializeCreateBlock();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Explosion(exploNum);
            PosChangeBlock();
            if (!noneCreate)
            {
                CreateEndBlock();
            }
        }
    }

    public void InitializeCreateBlock()
    {
        for(int i = 0; i < blockNum; i++)
        {
            GameObject go = Instantiate(blockPrefab) as GameObject;
            go.name = "block";
            go.transform.localPosition = new Vector2(Values.firstX + (Values.movePosX * i), Values.firstY); // 가로축만 i만큼씩 이동

            Block block = go.GetComponent<Block>();
            blockList[i] = block;

            block.SetData(go.transform.localPosition.x, go.transform.localPosition.y); // 위치값 저장

            Debug.Log(i + "번째 x값 = " + blockList[i]._X + " " + i + " 번째 y 값 = " + blockList[i]._Y);
        }
        
        // 랜덤 스프라이트 생성..

    }

    // 맞췄을 때 setActive = false (폭발)
    public void Explosion(int _exploNum)
    {
        blockList[_exploNum - 1].BlockSetActiveFalse();

        Temp = blockList[_exploNum - 1]; // 맨끝으로 오브젝트 옮기기 -->> 임시 Temp 저장
        Temp.SetPosition(Values.EndX, Values.firstY); // 코루틴 사용

    }

    public void PosChangeBlock() // 맞췄을 때 다같이 옆으로 이동
    {
        for(int i = 0; i < blockNum - listNum; i++)
        {
            // 위치값을 전에꺼랑 바꾸어주어야 한다.
            if(i == blockNum - 1)
            {
                blockList[i] = Temp;
                break;
            }

            //if (!blockList[i]._SetActive)
            //{
            //    continue;
            //}
            blockList[i] = blockList[i + 1];
            blockList[i].Move();
            // Debug.Log(i + "번째 x값 = " + blockList[i]._X + " " + i + " 번째 y 값 = " + blockList[i]._Y);
        }
    }

    public void CreateEndBlock() // 이동한 후 맨 끝자리 블록 true 하고 값 설정
    {
        blockList[blockNum - 1].BlockSetActiveTrue();
        StopCoroutine("CreateEndCo");
        StartCoroutine("CreateEndCo");
    }
    // **** Private ****

    IEnumerator ResetBlock() // 스테이지 끝난 다음 블록 재조정
    {

        yield return null;
    }

    IEnumerator ExploCo()
    {

        yield return null;
    }

    IEnumerator MoveCo()
    {

        yield return null;
    }

    IEnumerator CreateEndCo()
    {
        if(blanceNum > 0)
        {
            blanceNum--;
            
            // 랜덤 스프라이트 조정
        }
        else if(blanceNum <= 0)
        {
            Debug.Log("생성될 오브젝트 수 초과!!");
            listNum++;
            if(listNum == blockNum)
            {
                noneCreate = true;
            }
        }
        else
        {
            Debug.Log("CreateEndCo 에러!!");
        }

        yield return null;
    }

    // **** Property ****
    public int _BlanceNum
    {
        get { return blanceNum; }
        set { blanceNum = value; }
    }
}
