using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

//敵人
//可以說是會動，會造成傷害的目標
//是BaseClass，所以只會站在原地
public class Enemy : MonoBehaviour {
    //設定難度
    public StageController.Difficulty _difficulty= StageController.Difficulty.normal;
    //難度參數
    public DifficultyManager _enemyDifficulityManager;
    //目前使用難度
    public EnemyStateParameter _nowEnemyDifficulty;
    //取得動化
    public Animator _enemyAnimator;

    //目前目標物，目前預設都是玩家
    //裡面包含Character 和 cameraRig
    //顯示是要瞄準cameraRig 裡面的Camera
    public GameObject _target;

    //目前存活時間
    public float _serviceRemainTime;
    //多久之後要更新動作
    public float _updateActionTime;

    public List<EnemyAction> _actionList;

    // Use this for initialization
    void Start () {

        //取得人物動畫
        _enemyAnimator = this.GetComponent<Animator>();
        //預設難度是正常
        //怕如果沒有參數會出現錯誤
        SetDifficulty(_difficulty);
        //初始化所有action難度
        InitialAllAction();
    }
	
	//更新
	void Update ()
    {
        //計算存活時間
        CalTime();
        //
        _updateActionTime = _updateActionTime - Time.deltaTime;
        if (_updateActionTime < 0)
        {
            CalNextStep();
        }
    }

    //初始化所有動作
    protected void InitialAllAction()
    {
        
        //設定所有基本參數
        foreach (EnemyAction action in _actionList)
        {
            try
            {
                try
                {
                    action.SetAnimator(_enemyAnimator);
                }
                catch
                {

                }
                //設定目前難度
                action.SetDifficulty(_difficulty);
                //敵人本身
                action.SetEnemy(this);
                //Initialize
                action.Initialize();
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
    }

    //計算要用哪一個步驟
    void CalNextStep()
    {
        if (_actionList.Count > 0)
        {
            //先求出total
            float total = 0;
            for (int i = 0; i < _actionList.Count; i++)
            {
                total = total + _actionList[i]._nowdifficulty._ratio;
                //先停止手邊動作
                _actionList[i].StopAction();
            }
            //算出要道的位置
            float _number= UnityEngine.Random.Range(0, total);
            for (int i = 0; i < _actionList.Count; i++)
            {
                _number = _number - _actionList[i]._nowdifficulty._ratio;
                //表示抽中動作
                if (_number < 0)
                {
                    //執行動作
                    _actionList[i].ExecAction();
                    //要經過多久時間才會繼續下一個動作
                    _updateActionTime = _actionList[i].GetRemainTime();
                    break;
                }
            }
        }

    }

    //計時銷毀
    void CalTime()
    {
        _serviceRemainTime = _serviceRemainTime - Time.deltaTime;
        if (_serviceRemainTime < 0)
        {
            Destory();
            DestroygameObject();
        }
    }

    //設定難度
    protected void SetStageDifficulty(Difficulty difficulty)
    {
        _nowEnemyDifficulty = (EnemyStateParameter)difficulty;
    }

    //死掉
    //IEnumerator DestroygameObject()
    protected virtual void DestroygameObject()
    {
        //延遲一秒才Destroy
        Destroy(this.gameObject,1.0f);
    }

    void Destory()
    {
        _enemyAnimator.SetTrigger("Dead");
    }

    //敵人自己被毀掉
    public virtual void DestoryedByWeapon()
    {
        
        //先通知自己死翹翹惹
        try
        {
            //然後顯示死翹翹動化
            Destory();
            DestroygameObject();
            //然後通知被打到了
            NotifyEnemyDefeat();
        }
        catch
        {

        }
    }

    //被打到，要發出通知
    public virtual void EnemyHit()
    {
        SetEnemyHit((SingleWeakPointParameter)this.GetComponent<WeakPoint>()._nowdifficulty);
    }

    //通知敵人被打敗
    protected void NotifyEnemyDefeat()
    {
        try
        {
            //Debug.Log("Notify Enemy Defeat");
            //找一下目前裡面有沒有參數
            SetEnemyDeath((SingleWeakPointParameter)this.GetComponent<WeakPoint>()._nowdifficulty);
        }
        catch
        {
            //如果沒有就回傳new 的進去
            SetEnemyDeath(new SingleWeakPointParameter());
        }
    }

    //==============================public==========================
    //通知，如果敵人死翹翹了 : )
    public delegate void EnemyDefeated(SingleWeakPointParameter difficulty);
    public event EnemyDefeated _enemyDefeated;
    //通知，如果敵人被攻擊了 : )
    public delegate void EnemyHitterd(SingleWeakPointParameter difficulty);
    public event EnemyHitterd _enemyHitted;

    //設定難度
    public void SetDifficulty(StageController.Difficulty difficulity)
    {
        _difficulty = difficulity;
        //如果是簡單
        if (_difficulty == StageController.Difficulty.easy)
        {
            SetStageDifficulty(_enemyDifficulityManager.Easy);
        }
        else if (_difficulty == StageController.Difficulty.normal)
        {
            SetStageDifficulty(_enemyDifficulityManager.Normal);
        }
        else if (_difficulty == StageController.Difficulty.hard)
        {
            SetStageDifficulty(_enemyDifficulityManager.Hard);
        }
        else if (_difficulty == StageController.Difficulty.insame)
        {
            SetStageDifficulty(_enemyDifficulityManager.Insame);
        }
        _serviceRemainTime = _nowEnemyDifficulty._enemyServiceTime;
    }

    //如果是玩家碰到敵人，玩家就會從這邊取得攻擊
    public float GetDamageFormEnemy()
    {
        try
        {
            EnemyTouchAttack touchAttack = this.GetComponent<EnemyTouchAttack>();
            if (touchAttack != null)
            {
                return touchAttack.GetTouchDamage();
            }
            else
            {
                return 0;
            }

        }
        catch
        {

        }
        return 0;
    }

    //設定目標物
    public void SetTarget(GameObject player)
    {
        _target = player;
    }

    //==================================內部public=================================

    //如果Enemy被打到
    //要大於0才會發出通知
    public void SetEnemyHit(SingleWeakPointParameter difficulty)
    {
        if (_enemyHitted != null)
            _enemyHitted(difficulty);
    }

    //如果Enemy被打敗
    public void SetEnemyDeath(SingleWeakPointParameter difficulty)
    {
        if(_enemyDefeated != null)
            _enemyDefeated(difficulty);
    }


}
