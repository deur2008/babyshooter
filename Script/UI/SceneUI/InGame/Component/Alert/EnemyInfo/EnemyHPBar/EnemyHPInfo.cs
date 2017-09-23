using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//顯示敵人的HP
public class EnemyHPInfo : InGameEnemyInfoUI
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_enable)
        {
            UpdateView();
        }
	}

    //把所有東西都指定上去
    public override void Initialize()
    {
        //把物件從硬碟上面複製下來
        base.Initialize();
    }

    //更新一下目前的敵人
    //如果在敵人被更改的時候會做通知
    public override void UpdateEnemy()
    {
        //目前是跟原本一樣
        base.UpdateEnemy();
    }

    //更新一下位置
    //每個Frame都要更新一次
    protected override void UpdateView()
    {
        //也是跟之前一樣
        base.UpdateView();
    }

    //更新單一元件
    //要被繼承修改
    protected override void UpdateSingleValue(GameObject template, GameObject target)
    {
        //如果只有一個弱點
        try
        {
            if (target.GetComponent<SingleWeakPoint>() != null)
            {
                UpdateSingleWeakPointEnemyValue(template, target);
            }
        }
        catch
        {
        }

        //有多個弱點
        try
        {
            if (target.GetComponent<WeakPointList>() != null)
            {
                UpdateMultiWeakPointEnemyValue(template, target);
            }
        }
        catch
        {
        }
    }

    //如果只有一個弱點
    void UpdateSingleWeakPointEnemyValue(GameObject template, GameObject target)
    {
        //這邊要取得 template 裡面的 bar ，然後對裡面的參數做修改

        //取得最大HP
        template.GetComponent<SingleHpBarInfo>().SetMaxValue(((SingleWeakPointParameter)target.GetComponent<SingleWeakPoint>()._nowdifficulty).HP);
        //目前HP
        template.GetComponent<SingleHpBarInfo>().SetValue(target.GetComponent<SingleWeakPoint>().GetNowHP());
    }

    //如果有多個弱點的敵人一定會顯示
    void UpdateMultiWeakPointEnemyValue(GameObject template, GameObject target)
    {
        //先取得加總HP，和加總目前
        float maxHP = 0;
        float nowHP = 0;
        foreach (WeakPoint point in template.GetComponent<WeakPointList>()._enemyWeakPointList)
        {
            //取得最大
            maxHP = maxHP + ((SingleWeakPointParameter)point._nowdifficulty).HP;
            //所有
            nowHP = nowHP + point.GetNowHP();
        }
        //取得最大HP
        template.GetComponent<SingleHpBarInfo>().SetMaxValue(maxHP);
        //目前HP
        template.GetComponent<SingleHpBarInfo>().SetValue(nowHP);
    }
}
