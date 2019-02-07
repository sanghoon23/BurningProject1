using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// MonoBehavior 때고 글로벌 클래스 선언.
// const 를 붙이면 reference Type으로 변환(?) 되서
// Values.InitMovePosX 와 같이 참조가능?
// 
public class Values 
{
    public const float firstX = -2.5f;
    public const float firstY = 2f;
    public const float EndX = 3.5f;

    public const float blockScale = 1.0f;
    public const float movePosX = 1.0f; // 
}
