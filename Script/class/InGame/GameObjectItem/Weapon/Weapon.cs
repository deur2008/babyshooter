using UnityEngine;
using System.Collections;
using VRTK;

//所有武器(槍，刀，盾牌)等等的Base Class
//可以從
public class Weapon : MonoBehaviour
{
    public VRTK_InteractableObject _interact;

    //開始
    protected virtual void Start()
    {
        //取得樣板
        _interact = GetComponent<VRTK_InteractableObject>();
        RegistEvent();
    }

    //註冊事件
    protected virtual void RegistEvent()
    {
        //註冊事件
        _interact.InteractableObjectGrabbed += new InteractableObjectEventHandler(DoObjectGrab);
        //被使用
        _interact.InteractableObjectUsed += new InteractableObjectEventHandler(DoObjectUse);
    }

    //抓取物件
    protected virtual void DoObjectGrab(object sender, InteractableObjectEventArgs e)
    {
        
    }

    //抓取物件
    protected virtual void DoObjectUse(object sender, InteractableObjectEventArgs e)
    {

    }

    //把物件放下
    protected virtual void DoObjectUnuse(object sender, InteractableObjectEventArgs e)
    {

    }

    //回傳是不是敵人
    protected bool isEnemy(GameObject _target)
    {
        return false;
    }
}
