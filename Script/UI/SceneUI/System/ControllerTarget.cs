using UnityEngine;
using System.Collections;

//可以被Controller控制的class
//基本上會被Panel，SystemManager繼承 //20161002 已取消
public class ControllerTarget : MonoBehaviour {

    //初始化
    //從這邊去註冊事件，可以監聽
    public virtual void Initialize()
    {

    }

    //當正在操作這個選單時網上按
    public virtual void PressUp()
    {

    }

    //當正在操作這個選單時網上按
    public virtual void PressDown()
    {

    }

    //當正在操作這個選單時網上按
    public virtual void PressLeft()
    {
        
    }

    //當正在操作這個選單時網上按
    public virtual void PressRight()
    {
        
    }

    //如果在當下選單板機
    public virtual void PressTrigger()
    {
        
    }

    //如果抓取握把
    public virtual void PressGrab()
    {

    }

    //如果按下選單紐
    public virtual void PressApplicationMenu()
    {

    }

    //回傳選擇結果
    public virtual object GetValue()
    {
        return new object();
    }

    public virtual void SetValue(object Value)
    {

    }

}
