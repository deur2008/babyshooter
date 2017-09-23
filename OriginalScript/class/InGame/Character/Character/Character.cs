using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//附著在腳色身上，就是可以被敵人攻擊的目標
//目前全部改用Enemy一樣的架構
public class Character : Enemy
{

    //開始
    void Start()
    {

        //取得人物動畫
        _enemyAnimator = this.GetComponent<Animator>();
        //預設難度是正常
        //怕如果沒有參數會出現錯誤
        SetDifficulty(_difficulty);
        //初始化所有action難度
        InitialAllAction();
        //取得弱點，如果被攻擊就會回傳通知

    }

    //不能夠把玩家直接毀掉
    protected override void DestroygameObject()
    {
        
    }

    //如果被敵人打到
    //基本上通知base class 已經做了
    public override void DestoryedByWeapon()
    {
        base.DestoryedByWeapon();
    }

    /*
    //取得動化
    public Animator _enemyAnimator;
    //腳色的一些設定狀態 對應 EnemyStateParameter
    public CharacterInfo _info;
   
    //負責處理一些腳色在沒有操作時會遇到的事情，有點像model
    //目前用不到惹
    CharacterStateProcess _characterStateProcess;

    //設定難度
    public StageController.Difficulty _difficulty = StageController.Difficulty.normal;

    //通知已經死翹翹
    public delegate void DiedHandler();
    public event DiedHandler DiedEvent;

    public List<EnemyAction> _actionList;

    // Use this for initialization
    void Start()
    {

        //取得人物動畫
        _enemyAnimator = this.GetComponent<Animator>();
        //預設難度是正常
        //怕如果沒有參數會出現錯誤
        SetDifficulty(_difficulty);
        //初始化所有action難度
        InitialAllAction();

        Initial();
    }

    //確認是否要執行
    protected bool Initial()
    {
        _characterStateProcess = this.GetComponent<CharacterStateProcess>();
        _info = this.GetComponent<CharacterInfo>();
        if (_characterStateProcess == null)
        {
            return false;
        }
        else
        {
            _characterStateProcess.Initialize();
        }
        return true;
    }
   
    void update()
    {
        
    }
   
    //取得損傷
    public void GetDamage(float _damage)
    {
        //_info.
    }

    //=======================================private class=========================================

    */

}
