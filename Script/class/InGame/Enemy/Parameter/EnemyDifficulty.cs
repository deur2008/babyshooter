using UnityEngine;
using System.Collections;

//所有Enemy 難度設定都要繼承
public class EnemyDifficulty : Difficulty {

    //抽重機率
    public float _ratio = 100;

    //最小loop
    public float _minSecond = 1;
    //最大連續
    public float _maxSecond = 1;
    
}
