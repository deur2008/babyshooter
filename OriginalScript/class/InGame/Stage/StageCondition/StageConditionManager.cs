using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//對所有仔物件進行初始化
public class StageConditionManager : MonoBehaviour {

    //目前有哪些狀態
    public enum NowState{initialize,startGame,state,AskRestartGame,gameSuccess,gameOver,gameShowResult};
    public NowState _nowStage = NowState.initialize;

    //關卡控制
    StageController _stageController;

    //關卡周期
    //用來取代Animation，這個腳本會跑掉

    //有關初始化
    public GameObject _initialize;
    //開始遊戲
    public GameObject _startGame;
    //正在跑
    public GameObject _state;
    //遊戲結束，成功
    public GameObject _gameSuccess;
    //遊戲結束，失敗
    public GameObject _gameOver;
    //顯示結果
    public GameObject _gameShowResult;

    //要回到主選單還是重新開始
    public GameObject _askRestart;

    public List<StageCondition> _nowRunlistStage;

    public void SetStageController(StageController conbtroller)
    {
        _stageController = conbtroller;
    }

    // Use this for initialization
    public void Initialize()
    {
        foreach (StageCondition condition in this.gameObject.GetComponentsInChildren<StageCondition>())
        {
            try
            {
                //設定關卡和控制器
                condition.SetStageController(_stageController);
                //初始化
                condition.Initialize();
            }
            catch
            {

            }
        }
        //更新目前選擇的狀態(測試用
        _stageController.SwitchToState(_nowStage);
    }

    //會一直執行
    void Update()
    {
        foreach (StageCondition condition in _nowRunlistStage)
        {
            condition.OnConditionStay();
        }
    }

    //更新目前狀態
    public void SwitchToState(NowState condition)
    {
        _nowStage = condition;

        if (_nowStage == NowState.initialize)//如果目前是要初始化
            StageCondition_Initialize(_initialize);
        else if (_nowStage == NowState.startGame)//開使
            StageCondition_Initialize(_startGame);
        else if(_nowStage == NowState.state)//正在遊戲
            StageCondition_Initialize(_state);
        else if(_nowStage == NowState.AskRestartGame)//要不要重新遊戲
            StageCondition_Initialize(_askRestart);
        else if(_nowStage == NowState.gameOver)//遊戲失敗
            StageCondition_Initialize(_gameOver);
        else if(_nowStage == NowState.gameSuccess)//遊戲成功
            StageCondition_Initialize(_gameSuccess);
        else if(_nowStage == NowState.gameShowResult)//顯示結果
            StageCondition_Initialize(_gameShowResult);
    }

    //初始化
    //會只挑要初始化的condition 作執行
    private void StageCondition_Initialize(GameObject targetState)
    {
        //先把之前的狀態結束掉
        foreach (StageCondition condition in _nowRunlistStage)
        {
            condition.OnConditionExit();
        }
        //把 targetState 裡面的Condition加進來
        _nowRunlistStage = new List<StageCondition>();
        foreach (StageCondition condition in targetState.GetComponentsInChildren<StageCondition>())
        {
            _nowRunlistStage.Add(condition);
            //設定關卡和控制器
            condition.OnConditionEnter();
            try
            {
               
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
           
        }
    }

}
