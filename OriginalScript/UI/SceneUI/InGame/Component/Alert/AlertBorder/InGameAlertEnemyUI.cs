using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//用來通知敵人
public class InGameAlertEnemyUI : InGameEnemyInfoUI
{

    //上面
    public InGameAlertEnemySligleUI _upAlert;
    //下面
    public InGameAlertEnemySligleUI _downAlert;
    //左邊
    public InGameAlertEnemySligleUI _leftAlert;
    //右邊
    public InGameAlertEnemySligleUI _rightAlert;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        if (_enable)
        {
            //從 _aimmer 裡面去取得
            //檢查邊界
            UpdateView();
        }
    }

    //這邊不需要初始化
    public override void Initialize()
    {

    }

    //更新一下目前的敵人
    //如果在敵人被更改的時候會做通知
    public override void UpdateEnemy()
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

    public bool _up;
    public bool _down;
    public bool _left;
    public bool _right;
    public bool _danger;

    //更新一下位置
    //每個Frame都要更新一次
    protected override void UpdateView()
    {
        _up = false;
        _down = false;
        _left = false;
        _right = false;
        if (_listTarget.Count > 0)
        {
            for (int i = 0; i < _listTarget.Count; i++)
            {
                try
                {

                }
                catch
                {
                    _danger = checkBorder(_listTarget[i].transform.localRotation.eulerAngles);
                }
            }
        }

        //設定顯示邊界
        SetAlertAndDanger();
    }

    //更新單一元件
    //要被繼承修改
    protected override void UpdateSingleValue(GameObject template,GameObject enemy)
    {
        
    }

    
    /*
    //取得所有可以敵人，然後過濾出需要被警告的
    List<Vector3> CheckAllAlertEnemy()
    {
        List<Vector3> target = new List<Vector3>();
        foreach (GameObject singleEnemy in _manager.listEnemy)
        {
            target.Add(singleEnemy.transform.localRotation.eulerAngles);
        }
        return target;
    }
    


    //檢查敵人
    void CheckBorder()
    {
        List<Vector3> target = CheckAllAlertEnemy();
        _up = false;
        _down = false;
        _left = false;
        _right = false;

        //目前先設定如果有敵人一定顯示危險
        for (int i = 0; i < target.Count; i++)
        {
            _danger = checkBorder(target[i]);
        }
        //設定顯示邊界
        SetAlertAndDanger();
        
    }
    */

    //要不要顯示出框架
    bool checkBorder(Vector3 vector)
    {
        bool edit = false;
        if (vector.x < 330 && vector.x > 180)//上
        {
            _up = true;
            edit = true;
        }
        if (vector.x > 30 && vector.x < 180)//下
        {
            _down = true;
            edit = true;
        }
        if (vector.y < 320 && vector.y > 180)//左
        {
            _left = true;
            edit = true;
        }
        if (vector.y > 40 && vector.y < 180)//右
        {
            _right = true;
            edit = true;
        }
        return edit;
    }

    //設定
    void SetAlertAndDanger()
    {
        _upAlert.SetDisplayDanger(_up);
        _downAlert.SetDisplayDanger(_down);
        _leftAlert.SetDisplayDanger(_left);
        _rightAlert.SetDisplayDanger(_right);
        /*
        if (_danger)
        {
            
        }
        else
        {
            _upAlert.SetDisplayAlert(_up);
            _downAlert.SetDisplayAlert(_down);
            _leftAlert.SetDisplayAlert(_left);
            _rightAlert.SetDisplayAlert(_right);
        }
        */
    }

}
