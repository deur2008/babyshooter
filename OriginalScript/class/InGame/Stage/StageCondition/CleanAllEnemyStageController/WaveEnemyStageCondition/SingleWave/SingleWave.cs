using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


//單一個wave 
//裡面包含所有的EnemyCreator
//如果滿足條件就發出通知切換到下一個wave
public class SingleWave : MonoBehaviour {
    //目前
    public WaveEnemyStageCondition _stageCondition;

    //難度
    public DifficultyManager _difficultyManager;
    //單一難度
    public SingleWaveParameter _nowCleanAllEnemyStageDifficulty;

    //目前關卡難度
    public StageController.Difficulty _difficulity = StageController.Difficulty.normal; //目前選擇

    //敵人生產器
    //目前在這一波會有哪些敵人生產器
    public List<EnemyCreator> _nowSingleWaveEnemyCreatorList;

    public List<StageAction> _listAction;

    //目標腳色
    //包含CharacterRig和Character
    GameObject _player;

    //剩下多少之後難度就會增加
    public int _remainNumber;

    //經過多少時間
    public float _processTime=0;
    float _lastTickleTime;
    int _totlaScore = 0;

    bool _finish=false;

    //=============public virtual==============

    //把主觀卡附加上去
    public void SetStageCondition(WaveEnemyStageCondition controller)
    {
        _stageCondition = controller;
        _player = _stageCondition._stageController._cameraRig;
    }

    //初始化
    public void Initialize()
    {

        //抓到所有生成器
        //目前改成手動的
        //CatchEnemyCreator();
        //初始化
        InitialAllEnemyCreator();
        //更新難度
        UpdateStageDifficulty(_stageCondition._stageController._difficulity);
        Debug.Log("Update");
    }


    //動作正在被執行
    //這邊要增加一些判斷，例如時間
    public void Execute()
    {
        //生產敵人
        foreach (EnemyCreator creator in _nowSingleWaveEnemyCreatorList)
        {
            creator.CallUpdateCreateEnemy();
        }
        _processTime = _processTime + Time.deltaTime;
        if (_processTime - _lastTickleTime > 1)
        {
            
            _lastTickleTime = _processTime;
            UpdateGUITime((int)_processTime);
            //如果時間到了
            if (_processTime > _nowCleanAllEnemyStageDifficulty._processTime)
            {
                ConditionFinish();
            }
            
        }
    }

    //更新顯示時間
    void UpdateGUITime(int time)
    {
        _player.GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>()._characterInfoGUI.SetTime(time);
    }

    //如果狀態達到
    //通知 wave 去更新
    protected void ConditionFinish()
    {
        NotifySuccess();
        //顯示Success

        //把所有Action都跑過一次
        foreach (StageAction action in _listAction)
        {
            //初始化，執行
            action.SetStageController(_stageCondition);
            action.Initialize();
            action.StartAction();
        }
        
    }



    //顯示成功
    public PanelUI GetSuccessDialog()
    {
        return _nowCleanAllEnemyStageDifficulty._showWaveFinishUI;
    }

    //顯示成功
    public PanelUI GetFailDialog()
    {
        return _nowCleanAllEnemyStageDifficulty._showWaveFailUI;
    }

    //初始化
    protected void InitialAllEnemyCreator()
    {
        foreach (EnemyCreator enemyCreator in _nowSingleWaveEnemyCreatorList)
        {
            enemyCreator.SetDifficulty(_difficulity);
            enemyCreator.SetPlayer(_player);
            enemyCreator.Initial();
            //把之前監看事件清掉
            enemyCreator._enemyDefeated -= new EnemyCreator.EnemyDefeated(DefeatedEnemy);
            //然後增加監看是件
            enemyCreator._enemyDefeated += new EnemyCreator.EnemyDefeated(DefeatedEnemy);
        }
    }

    //如果打到敵人
    //目標較少一個
    void DefeatedEnemy(SingleWeakPointParameter difficulty)
    {
        //剩餘目標-1
        _remainNumber--;
        //如果所有敵人都被打完，通知階段完成
        if (_remainNumber <= 0)
        {
            if (_finish == false)
            {
                _finish = true;
                //通知任務完成
                ConditionFinish();
            }
        }
        //打敗的分數
        _totlaScore = _totlaScore + difficulty.DefeatScore;
        //顯示敵人數量
        UpdateWaveDefeatEnemyNumber(_remainNumber, _nowCleanAllEnemyStageDifficulty._defeatEnemyNumber);
        NotifyDefeatEnemy();
    }

    //更新顯示敵人數量
    //還剩下幾隻就要換新的Wave了
    void UpdateWaveDefeatEnemyNumber(int now,int total)
    {
        _player.GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>()._characterInfoGUI.SetEnemyProgress(1-((float)now / (float)total));
    }

    //更新難度
    protected void UpdateStageDifficulty(StageController.Difficulty difficulty)
    {
        //先更新難度
        _stageCondition._stageController.SetDifficulty(difficulty);

        _difficulity = difficulty;
        UpdateCreatorDiffculty();
        //然後是要打敗的敵人數量
        if (_difficulity == StageController.Difficulty.easy)
        {
            UpdateDifficultyParameter((SingleWaveParameter)_difficultyManager.Easy);
        }
        else if (_difficulity == StageController.Difficulty.normal)
        {
            UpdateDifficultyParameter((SingleWaveParameter)_difficultyManager.Normal);
        }
        else if (_difficulity == StageController.Difficulty.hard)
        {
            UpdateDifficultyParameter((SingleWaveParameter)_difficultyManager.Hard);
        }
        else if (_difficulity == StageController.Difficulty.insame)
        {
            UpdateDifficultyParameter((SingleWaveParameter)_difficultyManager.Insame);
        }
    }

    //更新敵人產生器的難度
    void UpdateCreatorDiffculty()
    {
        //更新難度
        foreach (EnemyCreator enemyCreator in _nowSingleWaveEnemyCreatorList)
        {
            try
            {
                //設定難度
                enemyCreator.SetDifficulty(_difficulity);
            }
            catch
            {

            }
        }
    }

    //設定值
    protected void UpdateDifficultyParameter(SingleWaveParameter difficulty)
    {
        _nowCleanAllEnemyStageDifficulty = difficulty;
        //需要清掉的敵人數量
        _remainNumber = _nowCleanAllEnemyStageDifficulty._defeatEnemyNumber;
    }

    
    //==============public==================
    //事件，通知打到敵人死翹翹惹
    public delegate void WaveFinish();
    public event WaveFinish _enemyDefeated;
    //如果wave 失敗，應該是用不到
    public delegate void WaveFail();
    public event WaveFail _enemyFall;
    //如果wave 失敗，應該是用不到
    public delegate void WaveDefeatEnemy();
    public event WaveDefeatEnemy _enemyHitted;

    //通知wqve成功
    void NotifySuccess()
    {
        if (_enemyDefeated != null)
            _enemyDefeated();
        Debug.Log("Wave Success");
    }

    //通知有敵人被打到
    void NotifyDefeatEnemy()
    {
        if (_enemyHitted!=null)
            _enemyHitted();
    }

    //取得目前所有敵人
    public List<GameObject> GetListEnemy()
    {
        //建構
        List<GameObject> listEnemy = new List<GameObject>();
        //然後把所有enemy都加進去
        foreach (EnemyCreator creator in _nowSingleWaveEnemyCreatorList)
        {
            //如果那個生產器是生產可以攻擊的敵人
            if (creator._isTargetEnemy)
            {
                foreach (GameObject enemy in creator._createdEnemyList)
                {
                    listEnemy.Add(enemy);
                }
            }
        }
        return listEnemy;
    }


    public SingleWaveResult GetSingleWaveResult()
    {
        SingleWaveResult wave = new SingleWaveResult();
        //數量
        wave.DefeatEnemy = _nowCleanAllEnemyStageDifficulty._defeatEnemyNumber-_remainNumber;
        wave.UseTime = _processTime;
        wave.SingleWaveTime = _nowCleanAllEnemyStageDifficulty._processTime;//處理時間
        wave.Score = _totlaScore; //分數
        return wave;
    }
   
    //結果
    public class SingleWaveResult
    {
        public int Score; //包含節省時間換算的分數
        public float SingleWaveTime; //單一的wave
        public float UseTime; //時間
        public int DefeatEnemy; //敵人
    }

    public int GetTotalScore()
    {
        return _totlaScore;
    }
}
