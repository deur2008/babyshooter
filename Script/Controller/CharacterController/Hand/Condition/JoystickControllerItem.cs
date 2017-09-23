using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRTK;

//如果是控制物件需要透過這邊
//可以只派一些功能，例如抓取，選單操作，武器選擇和操作等等
//然後手把會根據排序去選擇要操作那些物件
public class JoystickControllerItem : MonoBehaviour {
    //這個行為可不可以被執行
    public bool _isExecute;
    //目前有沒有發生
    public bool _isAct;

    //過濾器
    public List<VRTK_ControllerEvents.ButtonAlias> _listFilter;

    //物件，手把管理
    SteamVR_CharacterHandController _controller;

    //對於按鈕的提示
    public JoystickHint _joystickHint;

    //目標物件
    public GameObject _target;

    //如鬼這個行為被執行後，還有哪些行為可以被執行
    public List<JoystickControllerItem> _remainJoystickControl;

    //=================public ==================
    //把要控制的物件設定上去
    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    //初始化
    public void Initialize()
    {

    }

    //
    public virtual void LoopController()
    {

    }

    //=============protected============
    //過濾行為
    protected virtual void FilterJoystickControl()
    {
        /*
        //先把所有除了_act都是true以外的都關掉
        foreach (JoystickControllerItem item in _controller._listControlItem)
        {
            if (item._isAct == false)
            {
                item._isExecute = false;
            }
        }
        //只有自己允許操作的才打開
        foreach (JoystickControllerItem item in _remainJoystickControl)
        {
            item._isExecute = true;
        }
        */
    }

    //把所有都變成enable
    protected void ReleaseControl()
    {
        /*
        //先全部都開回來
        foreach (JoystickControllerItem item in _controller._listControlItem)
        {
            item._isExecute = true;
        }
        */
    }
}

