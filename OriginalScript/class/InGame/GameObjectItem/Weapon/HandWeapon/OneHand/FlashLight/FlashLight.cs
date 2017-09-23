using UnityEngine;
using System.Collections;
using VRTK;

public class FlashLight : Weapon
{
    //雷射發射器
    public Light _light;

    //開始
    protected override void Start()
    {
        //取得樣板
        _interact = GetComponent<VRTK_InteractableObject>();
        RegistEvent();
    }

    //註冊事件
    protected override void RegistEvent()
    {
        //壓下板機
        _interact.InteractableObjectUsed += new InteractableObjectEventHandler(DoObjectUse);
        //把版機放開
        _interact.InteractableObjectUnused += new InteractableObjectEventHandler(DoObjectUnuse);
    }

    //====================override Class==================

    //抓取物件
    protected override void DoObjectUse(object sender, InteractableObjectEventArgs e)
    {
        _light.enabled = true;
    }

    //把物件放下
    protected override void DoObjectUnuse(object sender, InteractableObjectEventArgs e)
    {
        _light.enabled = false;
    }

}
