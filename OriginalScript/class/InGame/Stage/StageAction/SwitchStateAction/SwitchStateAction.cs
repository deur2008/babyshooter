using UnityEngine;
using System.Collections;

public class SwitchStateAction : StageAction
{
    //從這邊可以預先設定要切換到哪一種狀態
    public StageConditionManager.NowState state = StageConditionManager.NowState.initialize;

    //初始化
    public override void Initialize()
    {

    }

    //開始動作
    //設定這個情況是有完成
    public override void StartAction()
    {
        _stageCondition.StageController.SwitchToState(state);
    }
}
