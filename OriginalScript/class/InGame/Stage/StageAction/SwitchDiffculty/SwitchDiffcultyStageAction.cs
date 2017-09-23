using UnityEngine;
using System.Collections;

//調正目前難度
public class SwitchDiffcultyStageAction : StageAction {

    //目前關卡難度
    public StageController.Difficulty _difficulity = StageController.Difficulty.normal; //目前選擇

    //初始化
    public override void Initialize()
    {

    }

    //開始動作
    //設定這個情況是有完成
    public override void StartAction()
    {
        try
        {
            ((WaveEnemyStageCondition)_stageCondition).UpdateStageDifficulty(_difficulity);
        }
        catch
        {

        }
        
    }
}
