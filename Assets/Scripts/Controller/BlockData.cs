using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockData 
{
    // 어차피 블록 순서는 blockList[i] 로 쓰면 된다.
    // public int Number;
    public float PosX;
    public float PosY;

    //public BlockData(int _Number)
    //{
    //    this.Number = _Number;
    //}

    public BlockData(float PosX, float PosY)
    {
        this.PosX = PosX;
        this.PosY = PosY;
    }

    //public BlockData(int _Number, float _PosX, float _PosY)
    //{
    //    this.Number = _Number;
    //    this.PosX = _PosX;
    //    this.PosY = _PosY;
    //}
}
