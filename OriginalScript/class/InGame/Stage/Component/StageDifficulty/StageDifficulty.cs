using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//儲存難度參數
public class StageDifficulty : Difficulty {
    //某個難度的BGM
    public AudioClip _DifficultyAudio;

    //敵人數量倍率 
    //因為在 EnemyCreator 裡面就可以設定了，所以取消
    //public List<float> _numberOfEnemyRatio;

    //時間
    public float _time;
    //要打敗的敵人數量
    public int _defeatEnemyNumber;
}
