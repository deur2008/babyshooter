using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

//Panel UI
//目前是所有選單有關的UI都要繼承 PanelUI 作為Bace Class
//主要實作 選單內上下左右呼叫的
public class PanelUI : ControllerTarget
{
    //設定Tag，方便做辨識用
    public int _tag = -1;

    //禁止操作
    public bool _disable = false;

    //之後移動
    protected bool _new = false; //有新訊息
    protected bool _highLight = false;//表示被focus到
    protected bool _thisIsOnselected = false;//被選擇

    //public List<panelComponent> _listPanelComponent;

    //然後是可以註冊，目前選單狀態改變的UpdateView
    public delegate void ModelChangedEventHandler();
    public event ModelChangedEventHandler _modelChanged;

    //按下確定，也有可能是數秒呼叫
    public delegate void ModelPressSelect(); //被選擇
    public event ModelPressSelect _modelPressSelect;

    //按下取消，也有可能是數秒呼叫?
    public delegate void ModelPressCancel(); //被取消
    public event ModelPressCancel _modelPressCancel;

    //滑鼠有Hover到
    public delegate void ModelHovered(); //被取消
    public event ModelHovered _modelHovered;

    //初始化
    public override void Initialize()
    {
        foreach (panelComponent single in GetComponents<panelComponent>())
        {
            single.enabled = true;
            //初始化
            single.Initialize();
            //執行
            single.Execute();
        }
    }

    protected void OnNotifiedChange()
    {
        _modelChanged();
    }

    protected void OnNotifiedSelect()
    {
        try
        {
            _modelPressSelect();
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    protected void OnNotifiedCancel()
    {
        try
        {
            _modelPressCancel();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        
    }

    protected void OnNotifiedHover()
    {
        try
        {
            _modelHovered();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        
    }

    //當正在操作這個選單時網上按
    //
    public override void PressUp()
    {

    }

    //當正在操作這個選單時網上按
    public override void PressDown()
    {
        
    }

    //當正在操作這個選單時網上按
    public override void PressLeft()
    {
        
    }

    //當正在操作這個選單時網上按
    public override void PressRight()
    {
       
    }

    //如果在當下選單按選擇
    public override void PressTrigger()
    {
        //預設通知監聽者已經按下Select
        OnNotifiedSelect();
    }

    //如果離開選單
    public override void PressGrab()
    {
        //通知外部已經Cancel了
        OnNotifiedCancel();
    }

    //設定值進去
    public override void SetValue(object obj)
    {
        //test Application.LoadLevel(0);
    }

    //設定選單是不是被鎖定的
    //如果被鎖定就代表不能操作
    public virtual void SetAsDisable(bool disable)
    {
        _disable = disable;
    }

    //設定是不是要醒目
    public virtual void SetHighLight(bool highLight)
    {
        _highLight = highLight;
    }

    //設定目前是不是被選擇
    public virtual void SetIsOnSelected(bool selected)
    {
        _thisIsOnselected = selected;
    }


    //取得選單內得到的結果
    //回傳選擇結果
    public override object GetValue()
    {
        return new object();
    }

    //取得Type
    public virtual string Type()
    {
        return this.name;
    }

    //取得目前的狀態
    public virtual PanelUIJsonFromat GetPanelUIJsonFromat()
    {
        PanelUIJsonFromat _panelUIJsonFromat = new PanelUIJsonFromat();
        try
        {
            _panelUIJsonFromat.Index = _tag;
            _panelUIJsonFromat.Type = this.Type();
            _panelUIJsonFromat.Value = "";
        }
        catch
        {

        }
        return _panelUIJsonFromat;
    }

    //基本的panel json格式
    public class PanelUIJsonFromat
    {
        public int Index { get; set; }
        public string Type { get; set; }
        public virtual string Value { get; set; }
    }

    /*
    Ray ray;
    RaycastHit hit;
    //偵測hover
    public void DetectHover()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.name);
        }
    }
    */

}

  
