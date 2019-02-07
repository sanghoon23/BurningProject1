using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public BlockObjectManager objManager;

    private void Awake()
    {
        if(!objManager)
        {
            objManager = FindObjectOfType<BlockObjectManager>();
        }
        Invoke("Init", 2);
    }

    void Init()
    {
        objManager.OnCreateBlock();
    }
}
