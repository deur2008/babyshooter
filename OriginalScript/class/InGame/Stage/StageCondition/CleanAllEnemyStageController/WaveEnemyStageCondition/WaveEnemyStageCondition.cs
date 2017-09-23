using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//會是一波一波，如果打到敵人滿足某個數量就會道下一波
public class WaveEnemyStageCondition : ShowUIStageCondition
{
    //如果失敗了就會有一系列的Action
    public List<StageAction> _listFallAction;
    //難度
    public DifficultyManager _difficultyManager;

    //每一波
    public List<SingleWave> _listWave;

    //目前是第幾波
    public int _nowWaveIndex;

    //目前關卡難度
    public StageController.Difficulty _difficulity = StageController.Difficulty.normal; //目前選擇

    //目標腳色
    //包含CharacterRig和Character
    GameObject _player;

    //顯示結果的panel
    public ShowWaveResultDialog _resultPanel;

    //把主觀卡附加上去
    public override void SetStageController(StageController controller)
    {
        _stageController = controller;
        _player = _stageController._cameraRig;
        foreach (SingleWave wave in _listWave)
        {
            wave.SetStageCondition(this);
        }
        
    }

    //初始化
    public override void Initialize()
    {
        //抓到所有Wave
        InitalAllWave();
        //更新難度
        UpdateStageDifficulty(_stageController._difficulity);
        Debug.Log("Update");
        //註冊通知
        SetWave(_listWave[0]);
        //註冊玩家通知
        InitialPlayer();
       
    }

    //對玩家初始化
    //取得監聽玩家死掉的事件
    void InitialPlayer()
    {
        _player.GetComponent<SteamVR_CharacterController>()._character._enemyDefeated += new Enemy.EnemyDefeated(PlayerDefeat);
        _player.GetComponent<SteamVR_CharacterController>()._character._enemyHitted += new Enemy.EnemyHitterd(PlayerHit);
        UpdatePlayerPower();
    }

    //如果玩家死掉
    void PlayerDefeat(SingleWeakPointParameter parameter)
    {
        OnWaveFail();
        //更新顯示資訊
        UpdatePlayerPower();
    }

    //如果玩家被攻擊
    void PlayerHit(SingleWeakPointParameter parameter)
    {
        //更新顯示資訊
        UpdatePlayerPower();
    }

    //所有Wave
    //對所有作初始化
    void InitalAllWave()
    {
        foreach (SingleWave wave in _listWave)
        {
            wave.Initialize();
        }
    }

    //目前的wave，首先要處理一些事件等等
    void SetWave(SingleWave nowWave)
    {
        //更新到目前難度
        //UpdateCreatorDiffculty();
        //增加事件
        nowWave._enemyDefeated += new SingleWave.WaveFinish(OnWaveFinish);
        nowWave._enemyFall += new SingleWave.WaveFail(OnWaveFail);
        nowWave._enemyHitted += new SingleWave.WaveDefeatEnemy(OnEnemyDefeat);
    }

    void LeaveWave(SingleWave nowWave)
    {
        //把事件清理掉
        nowWave._enemyDefeated -= new SingleWave.WaveFinish(OnWaveFinish);
        nowWave._enemyFall -= new SingleWave.WaveFail(OnWaveFail);
        nowWave._enemyHitted -= new SingleWave.WaveDefeatEnemy(OnEnemyDefeat);
    }

    void ExecuteWave(SingleWave nowWave)
    {
        //Debug.Log("Execute");
        nowWave.Execute();
    }

    //接收到通知，提醒已經完成
    void OnWaveFinish()
    {
        //如果是在陣列裡面
        if (_nowWaveIndex < _listWave.Count - 1)
        {
            //顯示wave 完成
            ShowWaveFinish(_nowWaveIndex);
            GoToNextWave(_nowWaveIndex);
            //播放音效
            PlayWaveSuccessAudioClip(_nowWaveIndex);
            //增加一關
            _nowWaveIndex++;
            
        }
        else
        {
            AllWaveFinish();
        }
    }

    //播放音效
    void PlayWaveSuccessAudioClip(int index)
    {
        try
        {
            AudioClip clip = _listWave[index]._difficultyManager.AudioParameter.AudioClip;
            this.GetComponent<AudioSource>().clip = clip;
            this.GetComponent<AudioSource>().Play();
        }
        catch
        {

        }
    }

    //顯示wave完成
    void ShowWaveFinish(int nowWave)
    {
        SetNowShowDialog(_listWave[nowWave].GetSuccessDialog());
        SetDialogValue("完成階段 : " + (nowWave + 1) + " / " + _listWave.Count);
        ShowDialog();
    }

    //如果選單完成就把選單清掉
    protected override void OnPanelSelect()
    {
        DestroyDialog();
    }

    //如果全部都做完了
    //執行listAction
    void AllWaveFinish()
    {
        //先把結果統計好
        CollectGameResult();
        //狀態達到，執行Action
        //切換到成功畫面
        ConditionFinish();
    }

    //到下一個wave
    void GoToNextWave(int nowWave)
    {
        //先離開
        LeaveWave(_listWave[nowWave]);
        //設定關卡
        SetWave(_listWave[nowWave + 1]);
        //然後顯示UI
    }

    //如果wave失敗
    void OnWaveFail()
    {
        //蒐集結果
        CollectGameResult();
        //執行失敗的Action;
        CondiitionFallAction();
    }

    //如果有敵人被打敗
    void OnEnemyDefeat()
    {
        //更新分數顯示
        UpdateScore();
    }

    //如果狀態達到
    protected void CondiitionFallAction()
    {
        //把所有Action都跑過一次
        foreach (StageAction action in _listFallAction)
        {
            //初始化，執行
            action.SetStageController(this);
            action.Initialize();
            action.StartAction();
        }
    }

    //更新難度
    public void UpdateStageDifficulty(StageController.Difficulty difficulty)
    {
        //先更新難度
        _stageController.SetDifficulty(difficulty);
        _difficulity = difficulty;
        //然後是要打敗的敵人數量
        if (_difficulity == StageController.Difficulty.easy)
        {
            UpdateDifficultyParameter((CleanAllEnemyStageDifficulty)_difficultyManager.Easy);
        }
        else if (_difficulity == StageController.Difficulty.normal)
        {
            UpdateDifficultyParameter((CleanAllEnemyStageDifficulty)_difficultyManager.Normal);
        }
        else if (_difficulity == StageController.Difficulty.hard)
        {
            UpdateDifficultyParameter((CleanAllEnemyStageDifficulty)_difficultyManager.Hard);
        }
        else if (_difficulity == StageController.Difficulty.insame)
        {
            UpdateDifficultyParameter((CleanAllEnemyStageDifficulty)_difficultyManager.Insame);
        }
    }

    //設定值
    //目前難度都是存在SingleWave裡面
    protected void UpdateDifficultyParameter(CleanAllEnemyStageDifficulty difficulty)
    {
        
    }


    //動作被執行的一開始
    public override void OnConditionEnter()
    {

    }

    //動作正在被執行
    //這邊要增加一些判斷，例如時間
    public override void OnConditionStay()
    {
        //生產敵人
        //只有目前那一波敵人才生產
        ExecuteWave(_listWave[_nowWaveIndex]);
    }

    //動作離開
    public override void OnConditionExit()
    {

    }

    //更新目前場上有幾隻敵人
    //還有對應WaveRemainTime
    //用來顯示玩家壓力
    void UpdatePlayerPower()
    {
        /*
        //更先顯示狀態
        //目前敵人數量
        int totlaEnemyNumber = 0;

        //目前場上所有敵人
        foreach (SingleWave wave in _listWave)
        {
            totlaEnemyNumber = totlaEnemyNumber + wave.GetListEnemy().Count;
        }
        //所有(要打敗的)數量
        int totalProductEnemy = _listWave[_nowWaveIndex]._nowCleanAllEnemyStageDifficulty._defeatEnemyNumber;

        //隊單位進行換算
        float power = 1 - (1-hp / maxHp) * (1 / 3) - (totlaEnemyNumber / totalProductEnemy) * (2 / 3);
        */
        
        SingleWeakPointParameter parameter = (SingleWeakPointParameter)_player.GetComponent<SteamVR_CharacterController>()._character.GetComponent<SingleWeakPoint>()._nowdifficulty;
        float maxHp = parameter.HP;
        float hp = _player.GetComponent<SteamVR_CharacterController>()._character.GetComponent<SingleWeakPoint>()._nowHP;
        //顯示目前HP
        _player.GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>()._characterInfoGUI.SetMaxTeamProgress(hp/maxHp);
    }

    //更新HP顯示
    void UpdateScore()
    {
        int score=0;
        foreach (SingleWave wave in _listWave)
        {
            score = score + wave.GetTotalScore();
        }
        //取得GUI並且更新
        _player.GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>()._characterInfoGUI.SetHP(score);
    }

    //把遊戲結果蒐集起來
    public void CollectGameResult()
    {
        List<SingleWave.SingleWaveResult> _result = new List<SingleWave.SingleWaveResult>();
        if (_listWave.Count > 0)
        {
            for (int i = 0; i <= _nowWaveIndex; i++)
            {
                try
                {
                    _result.Add(_listWave[i].GetSingleWaveResult());
                }
                catch
                {

                }
            }
        }
        _resultPanel.gameObject.SetActive(true);
        //然後設定結果上去
        _resultPanel.SetInput(_result);
        _resultPanel.gameObject.SetActive(false);
    }
}
