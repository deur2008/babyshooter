using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//裡面儲存敵人所有攻擊弱點
public class WeakPointList : EnemyAction
{
    //顯示血量
    public SingleHpBarInfo _hpBar;
    //所有敵人弱點
    public List<WeakPointListSingleItem> _enemyWeakPointList;

    //各個弱點的相關參數
    public List<DifficultyManager> _enemyWeakPointParameterList;


    //設定難度把所有難度轉進去
    public override void SetDifficulty(StageController.Difficulty difficulty)
    {
        if (_enemyWeakPointList.Count > 0)
        {
            //設定相關事件，還有把parameter丟進去
            for (int i = 0; i < _enemyWeakPointList.Count; i++)
            {
                try
                {
                    _enemyWeakPointList[i]._difficultyManager = _enemyWeakPointParameterList[i];
                    //設定難度
                    //如果是簡單
                    _enemyWeakPointList[i].SetDifficulty(difficulty);
                   
                    //註冊事件
                    _enemyWeakPointList[i]._getDamage += new WeakPointListSingleItem.PointGetDamage(SpotDamage);
                    //註冊事件
                    _enemyWeakPointList[i]._hpZero += new WeakPointListSingleItem.HPZero(SpotHPzero);
                }
                catch
                { }
            }
        }
    }

    //取得所有敵人，然後註冊通知
    public override void Initialize()
    {
        if (_enemyWeakPointList.Count > 0)
        {
            //設定相關事件，還有把parameter丟進去
            for (int i = 0; i < _enemyWeakPointList.Count; i++)
            {
                try
                {
                    //初始化
                    _enemyWeakPointList[i].Initialize();
                }
                catch
                {

                }
            }
        }
	}

    //某個點被攻擊
    //要裝作很痛苦的樣子
    void SpotDamage(WeakPoint point)
    {

    }

    //一個點被打掉
    //把點清除
    void SpotHPzero(WeakPoint weapon)
    {

    }

    //如果碰撞到，回傳通知
    //或是直接扣HP   


    //如果一個點被擊敗了
    //就直接把那個list踢掉好了

    //剩下幾個點


}
