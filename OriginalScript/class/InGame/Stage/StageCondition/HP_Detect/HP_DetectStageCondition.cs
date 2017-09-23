using UnityEngine;
using System.Collections;

//檢查HP，如果<0就切換到遊戲死翹翹
public class HP_DetectStageCondition : StageCondition {

    public Character _character;
    //初始化
    //把character 丟進來並且監聽裡面的single Weak Point
    public override void Initialize()
    {
        //取得腳色
        _character = _stageController._character;
        //註冊會死翹翹的事件
        _character._enemyDefeated += new Enemy.EnemyDefeated(EnemyCreatorEnemyDefeated);
    }

    //如果達成就執行Action
    //Action 是切換到GameOver;
    private void EnemyCreatorEnemyDefeated(SingleWeakPointParameter difficulty)
    {
        ConditionFinish();
    }

}
