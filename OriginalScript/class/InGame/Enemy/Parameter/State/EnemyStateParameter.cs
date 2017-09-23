using UnityEngine;
using System.Collections;

//一些共通狀態
public class EnemyStateParameter : Difficulty
{
    //還有敵人存活時間
    public float _enemyServiceTime;

    //被打敗的 權重
    public float _defeatWeight=1;

    //要不要顯示準心
    public bool _showAimmer;

    //要不要顯示邊界提示
    //如果敵人跑到視角外就會有提示
    public bool _showHint;
}
