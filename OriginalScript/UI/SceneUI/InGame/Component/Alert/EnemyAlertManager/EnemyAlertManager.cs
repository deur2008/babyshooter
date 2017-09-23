using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//敵人管理器
//如果有要顯示提示或是上下左右都要從這邊去取得清單
public class EnemyAlertManager : GameComponentUI
{

    //目前敵人列表
    public List<GameObject> _listEnemy;

    //目前顯示器列表
    public List<InGameEnemyInfoUI> _UIList;

    // Use this for initialization
    void Start () {
        InitialUIList();
    }
	
	// Update is called once per frame
	void Update () {
        //更新敵人數量然後顯示出來
        UpdateListEnemy();
    }

    //更新所有敵人
    //如果敵人數量有改變，就會被通知到
    //從外部呼叫
    //如果敵人狀態有改變
    public void  UpdateListEnemy()
    {
        _listEnemy = new List<GameObject>();
        //找到所有敵人
        GameObject[] rowEnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        //更新敵人
        foreach (GameObject enemy in rowEnemyList)
        {
            if(rowEnemyList!=null)
                _listEnemy.Add(enemy);
        }

        UpdateAllUIList();
    }

    //對所有顯示有關敵人的做初始化
    public void InitialUIList()
    {
        foreach(InGameEnemyInfoUI singleUI in _UIList)
        {
            //先指定上去
            singleUI._manager = this;
            //初始化
            singleUI.Initialize();
        }
    }

    //如果敵人數量改變或是有做更新，就會從這邊去呼叫
    void UpdateAllUIList()
    {
        foreach (InGameEnemyInfoUI singleUI in _UIList)
        {
            singleUI.UpdateEnemy();
        }
    }
}
