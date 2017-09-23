using UnityEngine;
using System.Collections;

//上下左右邊其中一個
public class InGameAlertEnemySligleUI : MonoBehaviour {

    //顯示警告
    public InGameAlertEnemySligleAlertAnimateUI _alertUI;

    //顯示危險
    public InGameAlertEnemySligleDangerAnimateUI _dangerUI;

    //警告
    public bool _alert=false;

    //危險
    public bool _danger =false;

    //================================ public ==============================

    void Start()
    {
        UpdateView();
    }

    //是否要顯示
    public void SetDisplayAlert(bool display)
    {
        if (display)
        {
            if (_danger)
            {
                _danger = false;
            }
        }
        if (display == false)
        {
            if (_alert == true || _danger == true)
            {
                _alert = false;
                _danger = false;
                UpdateView(); 
            }
        }
        else if (_alert != display)
        {
            _alert = display;
            UpdateView();
        }
    }

    //是否要顯示
    public void SetDisplayDanger(bool display)
    {
        if (display)
        {
            if (_alert)
            {
                _alert = false;
            }
        }
        //danger 的轉換
        if (display == false)
        {
            if (_alert == true || _danger == true)
            {
                _alert = false;
                _danger = false;
                UpdateView();
            }
        }
        else if(_danger != display)
        {
            _danger = display;
            UpdateView();
        }
    }

    //更新View
    void UpdateView()
    {
        _alertUI.Display(_alert);
        _dangerUI.Display(_danger);
    }
   
}
