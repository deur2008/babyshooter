using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//所以顯示敵人狀態裡面都會繼承
public class InGameEnemyInfoUI : GameComponentUI
{

    //是否要啟用
    public bool _enable = true;

    //樣板
    public GameObject _template;

    //所有目前要處理的敵人
    public List<GameObject> _listTarget;

    

    //管理器
    public EnemyAlertManager _manager;

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
    public virtual void Initialize()
    {
        //把物件從硬碟上面複製下來
        _template = GameObject.Instantiate(_template);
    }

    //更新一下目前的敵人
    //如果在敵人被更改的時候會做通知
    public virtual void UpdateEnemy()
    {
        _listTarget = new List<GameObject>();
        foreach (GameObject target in _manager._listEnemy)
        {
            if (true)
            {
                _listTarget.Add(target);
            }
        }
    }

    //更新一下位置
    //每個Frame都要更新一次
    protected virtual void UpdateView()
    {
        
    }

    //更新單一元件
    //要被繼承修改
    protected virtual void UpdateSingleValue(GameObject template, GameObject target)
    {

    }
    
       
}
