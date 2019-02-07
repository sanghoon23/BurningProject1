using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpriteKind : int
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    CHECK
}

public class Draw : MonoBehaviour 
{
    // 싱글톤
    static Draw sInstance;

    public static Draw GetInstance
    {
        get
        {
            if (sInstance == null) sInstance = FindObjectOfType<Draw>();
            return sInstance;
        }
    }

    SpriteKind spriteKind;
    SpriteRenderer[] mRenderers;

    // **** Public ****
    public SpriteRenderer GetSprite(SpriteKind spriteKind)
    {
        return mRenderers[(int)spriteKind];
    }

    public SpriteRenderer GetSprite(int spriteNum)
    {
        return mRenderers[spriteNum];
    }

    public SpriteRenderer GetRandomSprite()
    {
        int index = GetRandomSpriteNum();
        return mRenderers[index];
    }


    // **** Private ****
    int GetRandomSpriteNum()
    {
        return Random.Range(0, mRenderers.Length);
    }
}
