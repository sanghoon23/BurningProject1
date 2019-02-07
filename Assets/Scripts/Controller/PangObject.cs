using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangObject : MonoBehaviour 
{
    SpriteRenderer mRenderer;

    private void Awake()
    {
        mRenderer = GetComponent<SpriteRenderer>();
    }

    public SpriteRenderer _Render
    {
        get { return mRenderer; }
        set { mRenderer = value; }
    }

}
