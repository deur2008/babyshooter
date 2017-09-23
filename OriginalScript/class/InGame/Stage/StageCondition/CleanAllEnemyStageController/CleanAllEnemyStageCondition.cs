using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//目標是清光所有敵人
//如果清到一定的數量，或是維持一段時間，就會變難
public class CleanAllEnemyStageCondition : StageCondition
{
    //難度
    public DifficultyManager _difficultyManager;
    //目前關卡難度
    public StageController.Difficulty _difficulity = StageController.Difficulty.normal; //目前選擇
    //敵人生成器
    //在建置場景的時候就會把敵人的生成規則順便拉好
    public GameObject _enemyCreatorListGameObject;
    
    //敵人生產器
    public List<EnemyCreator> _enemyCreatorList;

    //目標腳色
    //包含CharacterRig和Character
    GameObject _player;

    //剩下多少之後難度就會增加
    int _remainNumber;
    CleanAllEnemyStageDifficulty _nowCleanAllEnemyStageDifficulty;

    //=============public virtual==============

    //把主觀卡附加上去
    public override void SetStageController(StageController controller)
    {
        _stageController = controller;
        _player = _stageController._cameraRig;
    }

    //設定值
    public override void SetVaule(object value)
    {

    }

    //初始化
    public override void Initialize()
    {
        
        //抓到所有生成器
        CatchEnemyCreator();
        //初始化
        InitialAllEnemyCreator();
        //更新難度
        UpdateStageDifficulty(_stageController._difficulity);
        Debug.Log("Update");
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
        foreach (EnemyCreator creator in _enemyCreatorList)
        {
            creator.CallUpdateCreateEnemy();
        }
    }

    //動作離開
    public override void OnConditionExit()
    {

    }

    //取得目前的值
    public override object GetValue()
    {
        return new object();
    }

    //如果狀態達到
    //就代表升級了
    //要顯示升級選單
    protected override void ConditionFinish()
    {
        //把所有Action都跑過一次
        foreach (StageAction action in _listAction)
        {
            //初始化，執行
            action.SetStageController(this);
            action.Initialize();
            action.StartAction();
        }
    }
   
    //=================protected===============
    //初始化敵人生產器
    protected void CatchEnemyCreator()
    {
        //初始化enemyList
        _enemyCreatorList = new List<EnemyCreator>();
        //取得所有敵人產生器
        foreach (EnemyCreator enemyCreator in _enemyCreatorListGameObject.GetComponentsInChildren<EnemyCreator>())
        {
            try
            {
                //增加
                _enemyCreatorList.Add(enemyCreator);
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
    }

    //初始化
    protected void InitialAllEnemyCreator()
    {
        foreach (EnemyCreator enemyCreator in _enemyCreatorList)
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
    void DefeatedEnemy(SingleWeakPointParameter difficulty)
    {
        //剩餘目標-1
        _remainNumber--;

        //如果所有敵人都被打完，通知階段完成
        //往上升一個難度
        if (_remainNumber == 0)
        {
            UpgradeStageDifficulty();
        }
        //通知任務完成
        ConditionFinish();
    }

    //往上升一個等級
    void UpgradeStageDifficulty()
    {
        if (_difficulity == StageController.Difficulty.easy)
        {
            UpdateStageDifficulty(StageController.Difficulty.normal);
        }
        else if (_difficulity == StageController.Difficulty.normal)
        {
            UpdateStageDifficulty(StageController.Difficulty.hard);
        }
        else if (_difficulity == StageController.Difficulty.hard)
        {
            UpdateStageDifficulty(StageController.Difficulty.insame);
        }
    }

    //更新難度
    protected void UpdateStageDifficulty(StageController.Difficulty difficulty)
    {
        //先更新難度
        _stageController.SetDifficulty(difficulty);
        _difficulity = difficulty;
        UpdateCreatorDiffculty();
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

    //更新敵人產生器的難度
    void UpdateCreatorDiffculty()
    {
        //更新難度
        foreach (EnemyCreator enemyCreator in _enemyCreatorList)
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
    protected void UpdateDifficultyParameter(CleanAllEnemyStageDifficulty difficulty)
    {
        _nowCleanAllEnemyStageDifficulty = difficulty;
    }

    /*
    //==============public==================
    //事件，通知打到敵人死翹翹惹
    public delegate void EnemyDefeated(SingleWeakPointParameter difficulty);
    public event EnemyDefeated _enemyDefeated;
    //通知，如果敵人被攻擊了 : )
    public delegate void EnemyHitterd(SingleWeakPointParameter difficulty);
    public event EnemyHitterd _enemyHitted;
    */

    //取得目前所有敵人
    public List<GameObject> GetListEnemy()
    {
        //建構
        List<GameObject> listEnemy = new List<GameObject>();
        //然後把所有enemy都加進去
        foreach (EnemyCreator creator in _enemyCreatorList)
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
        
}
