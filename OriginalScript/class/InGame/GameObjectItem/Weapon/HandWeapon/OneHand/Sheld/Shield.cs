using UnityEngine;
using System.Collections;
using VRTK;

//盾牌
//基本上沒啥用處，只能抵擋攻擊
//如果被武器碰到可以再多久內(例如0.3秒內(抵擋攻擊
public class Shield : Weapon
{

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
        //註冊事件
        _interact.InteractableObjectGrabbed += new InteractableObjectEventHandler(DoObjectGrab);
        //被使用
        _interact.InteractableObjectUsed += new InteractableObjectEventHandler(DoObjectUse);
    }

   

    // Update is called once per frame
    void Update () {
	
	}
    
    //撞到東西
    void OnCollisionEnter(Collision collision)
    {
        try
        {
           
        }
        catch
        {

        }
    }


    //==================override
    //抓取物件
    protected override void DoObjectGrab(object sender, InteractableObjectEventArgs e)
    {

    }

    //抓取物件
    protected override void DoObjectUse(object sender, InteractableObjectEventArgs e)
    {

    }

    //把物件放下
    protected override void DoObjectUnuse(object sender, InteractableObjectEventArgs e)
    {

    }
}
