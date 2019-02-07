using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : PangObject 
{
    // 상태값
    public enum State : int
    {
        EMPTY, // 빈 공간
        IDLE, // 온전
        MOVE, // 이동
        EXPLO, // 폭파
    }

    bool mSetActive = true;
    State mState;
    BlockData mData;

    public void SetData(float x, float y) // SetData 오버로드
    {
        mData = new BlockData(x, y);
    }

    public void SetData(BlockData data) // SetData 오버로드
    {
        mData = data;
    }

    public void SetData() // SetData 오버로드
    {
        mData.PosX = transform.position.x;
        mData.PosY = transform.position.y;
    }

    public void Move()
    {
        StopCoroutine("MoveCo");
        StartCoroutine("MoveCo");
    }

    public void Explosion()
    {
        StopCoroutine("ExploCo");
        StartCoroutine("ExploCo");
    }

    public void SetPosition()
    {
        _LocalPosition = new Vector2(mData.PosX, mData.PosY);
        SetData();
    }

    public void SetPosition(float x, float y)
    {
        _LocalPosition = new Vector2(x, y);
        mData.PosX = x;
        mData.PosY = y;
    }

    public void On() // setActive = true;
    {
        gameObject.SetActive(true);
        mSetActive = true;
        mState = State.IDLE;
    }

    public void Off() // 맞췄을 때 setactive = false
    {
        gameObject.SetActive(false);
        mSetActive = false;
        mState = State.EMPTY;
    }

    public void SetRandomSpriteRenderer() // 맞췄을 때 스프라이트 set
    {

    }

    public void EachSpwan() // 개별 스폰.
    {

    }

    public void EachReset() // 개별 리셋.
    {
        
    }

    // **** Defult Method ****
    IEnumerator MoveCo()
    {
        Vector2 startPos = _LocalPosition;
        Vector2 endPos =  new Vector2(mData.PosX - Values.movePosX, mData.PosY);
        float startTime = Time.time;
        //float duration = Vector2.Distance(startPos, endPos) / speed;
        float duration = .2f;
        mState = State.MOVE;

        SetData(endPos.x, endPos.y);

        while (Time.time - startTime <= duration)
        {
            _LocalPosition = Vector2.Lerp(startPos, endPos, (Time.time - startTime) / duration);
            yield return null;
        }
    }

    IEnumerator ExploCo()
    {
        float startTime = Time.time;
        float duration = .2f;
        mState = State.EXPLO;

        while(Time.time - startTime <= duration)
        {
            // 폭발 파티클 실행..
            yield return null;
        }
    }

    // **** Property ****
    public State _State
    {
        get { return mState; }
    }
    public BlockData _BlockData
    {
        get { return mData; }
    }

    public bool _SetActive
    {
        get { return mSetActive; }
    }

    public float _X // (BlockData)의 x 좌표 값.
    {
        get { return mData.PosX; }
    }

    public float _Y // (BlockData)의 y 좌표 값.
    {
        get { return mData.PosY; }
    }

    public Vector2 _LocalPosition
    {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }
}