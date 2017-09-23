using UnityEngine;
using System.Collections;
using System;

//敵人弱點
//可以顯示血量等等
//如果血量沒有了就會把弱點隱藏掉

//被singleWeakPoint 繼承，被singleWeakPoint 又需要繼承 EnemyAction
public class WeakPoint : EnemyAction
{
    //目前的HPBar
    public SingleHpBarInfo _hpBar;

    //目前HP
    public float _nowHP;
    bool _showHPBar;

    //距離上一次被攻擊的時間
    //如果大於某個時間就會自動回血
    public float _lastAttackTime;

    //要顯示的UI面對方向
    GameObject _FaceUITarget;

    public bool _defeat = false;
    
    //設定難度
    protected override void SetStageDifficulty(Difficulty difficulty)
    {
        //轉型
        _nowdifficulty = (SingleWeakPointParameter)difficulty;
        //把血量加進去
        _nowHP = ((SingleWeakPointParameter)difficulty).HP;
        _showHPBar = ((SingleWeakPointParameter)difficulty)._showHPBar;
    }

    //設定敵人
    public override void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
        _FaceUITarget = _enemy._target.GetComponent<SteamVR_ControllerManager>().head;
    }

    //面對玩家
    protected virtual void Update()
    {
        FaceHpBarToPlayer();
    }

    //設定難度
    public override void SetDifficulty(StageController.Difficulty difficulity)
    {
        //如果是簡單
        if (difficulity == StageController.Difficulty.easy)
        {
            SetStageDifficulty(_difficultyManager.Easy);
        }
        else if (difficulity == StageController.Difficulty.normal)
        {
            SetStageDifficulty(_difficultyManager.Normal);
        }
        else if (difficulity == StageController.Difficulty.hard)
        {
            SetStageDifficulty(_difficultyManager.Hard);
        }
        else //if (difficulity == StageController.Difficulty.insame)
        {
            SetStageDifficulty(_difficultyManager.Insame);
        }
    }


    //取得所有敵人，然後註冊通知
    public override void Initialize()
    {
        if (((SingleWeakPointParameter)_nowdifficulty)._showHPBar)
        {
            _hpBar.gameObject.SetActive(true);
            //然後更新血量顯示
            UpdateHPView();
        }
        else
        {
            _hpBar.gameObject.SetActive(false);
        }
    }

    //收到傷害
    //子彈會把傷害輸入進來
    public virtual void SetDamage(float damage)
    {
        _nowHP = _nowHP - damage;
       
        //更新被攻擊
        NotifiedAttack();
        if (_nowHP < 0)
        {
            if (_defeat == false)
            {
                this.GetComponent<Enemy>().DestoryedByWeapon();
                _defeat = true;
            }
            
        }
        else
        {
            OnHitAnimation();
        }
        //更新血量提示
        if (((SingleWeakPointParameter)_nowdifficulty)._showHPBar)
        {
            UpdateHPView();
        }
    }

    //取得參數
    public SingleWeakPointParameter GetSingleWeakPointParameter()
    {
        return ((SingleWeakPointParameter)_nowdifficulty);
    }

    //取得目前HP
    public float GetNowHP()
    {
        return _nowHP;
    }

    //被選到沒有動畫
    public override void SetStartAnimation()
    {
        //被選到不會有動畫
    }

    //設定動畫
    public override void SetStopAnimation()
    {
        //被選到不會有動畫
    }

    //設定如果被打到
    protected virtual void OnHitAnimation()
    {
        try
        {
            _animator.SetTrigger("Hit");
        }
        catch
        {

        }
        
    }

    //更新血量
    protected virtual void UpdateHPView()
    {
        //如果要顯示HPBar
        if (((SingleWeakPointParameter)_nowdifficulty)._showHPBar)
        {
            if (_enemy._target != null)
            {
                //指定面對腳色的頭部
                _hpBar.SetMaxValue(((SingleWeakPointParameter)_nowdifficulty).HP);
                _hpBar.SetValue(_nowHP);
            }
        }
    }

    //面對敵人
    protected virtual void FaceHpBarToPlayer()
    {
        if (_showHPBar)
        {
            if (_enemy._target != null)
            {
                //指定面對腳色的頭部
                _hpBar.gameObject.transform.LookAt(_FaceUITarget.transform);

            }
        }
    }

    //通知如果被攻擊
    //也會通知enemy被攻擊
    protected void NotifiedAttack()
    {
        this.GetComponent<Enemy>().EnemyHit();
    }

 


}
