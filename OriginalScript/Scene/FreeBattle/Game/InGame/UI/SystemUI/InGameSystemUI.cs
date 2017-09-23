using UnityEngine;
using System.Collections;

//目前用不到
public class InGameSystemUI : GameComponentUI
{
    
    //存放各個UI;
    public GameObject StartGameUIGameObject;
    public GameObject StartStageGameObject;
    public GameObject FinishStageGameObject;
    public GameObject FinishGameObject;
    public GameObject FallGameObject;
    public GameObject ShowResultGameObject;
    public GameObject ShowHintGoToStageFinishAreaGameObject;
    public GameObject TimeOutGameObject;

    //顯示開始遊戲 ((Start
    public void ShowStartGameUI()
    {
        StartGameUIGameObject.SetActive(true);
        //然後呼叫Function
    }

    //顯示目前階段
    public void ShowStartStage(int totalGoal = 1, int finishGoal_index = 0)
    {
        StartStageGameObject.SetActive(true);
        //然後呼叫Function
    }

    //顯示目前完成階段
    public void ShowFinishtStage(int totalGoal = 1, int finishGoal_index = 0)
    {
        StartStageGameObject.SetActive(true);
        //然後呼叫Function
    }

    //顯示完成整個遊戲
    public void ShowFinish(float remainTime)
    {
        FinishGameObject.SetActive(true);
        //然後呼叫Function
    }

    //顯示失敗
    public void ShowFallUI(float remainTime=0)
    {
        FallGameObject.SetActive(true);
        //然後呼叫Function
    }

    //顯示結果
    public void ShowResultUI()
    {
        ShowResultGameObject.SetActive(true);
        //然後呼叫Function
    }

    //顯示到達指定地點
    public void ShowHintGoToStageFinishArea(int remainTime = 0)
    {
        ShowHintGoToStageFinishAreaGameObject.SetActive(true);
    }

    //顯示時間
    public void TimeOut(float remainTime)
    {
        TimeOutGameObject.SetActive(true);
    }
}

