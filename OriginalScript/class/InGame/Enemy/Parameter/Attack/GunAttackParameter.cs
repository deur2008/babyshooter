using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//槍枝的攻擊參數
public class GunAttackParameter : EnemyDifficulty
{
    //延遲時間()
    public float _minDelayTime=0.3f;

    //延遲時間
    public float _maxDelayTime=0.4f;

    //準確度，0~100
    public float _aimPrecise;

    //對玩家傷害，設定在槍枝裡面

    //發射平率，也是設定在武器裡面

    //設定所有攻擊範圍
    public List<DetectCollisonSpot> _detectAreaList;
}
