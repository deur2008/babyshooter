using UnityEngine;
using System.Collections;

public class WeakPointListSingleItem : WeakPoint
{
    //通知，如果物體進入
    public delegate void PointGetDamage(WeakPoint point);
    public event PointGetDamage _getDamage;

    //如果HP<0
    //回傳自身，方便移除
    public delegate void HPZero(WeakPoint point);
    public event HPZero _hpZero;


    //目前的HPBar
    public SingleHpBarInfo _hpBar;

    //取得所有敵人，然後註冊通知
    public override void Initialize()
    {
        if (((SingleWeakPointParameter)_nowdifficulty)._showHPBar)
        {
            _hpBar.gameObject.SetActive(true);
        }
        else
        {
            _hpBar.gameObject.SetActive(false);
        }
    }

    //面對玩家
    void Update()
    {
        if (((SingleWeakPointParameter)_nowdifficulty)._showHPBar)
        {
            if (_enemy._target != null)
            {
                _hpBar.gameObject.transform.LookAt(_enemy._target.transform);
            }
        }
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

    //設定動畫
    public override void SetStartAnimation()
    {
        //被選到不會有動畫
    }

    //設定動畫
    public override void SetStopAnimation()
    {
        //被選到不會有動畫
    }

}
