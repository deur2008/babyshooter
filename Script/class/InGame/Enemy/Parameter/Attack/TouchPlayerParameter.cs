using UnityEngine;
using System.Collections;

//碰到玩家時對玩家的傷害
public class TouchPlayerParameter : EnemyDifficulty
{

    //碰到傷害
    public float Damage=10;

    //時間，間隔多久一次
    public float Time=1;
}
