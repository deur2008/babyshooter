using UnityEngine;
using System.Collections;
using VRTK;

//弓箭生產器，這個腳本是附著在弓箭產生器上面
//如果發射會從子物件上面複製箭然後設出去
public class ArrorCreator : Weapon
{
    //弓箭
    private GameObject arrow;
    //可以被抓起來
    private VRTK_InteractableObject obj;
    

    //開始
    protected override void Start()
    {
        arrow = transform.FindChild("Arrow").gameObject;
        RegistEvent();
        obj = GetComponent<VRTK_InteractableObject>();
    }

    //如果碰到弓上面，就會轉移一分到弓上面
    private void OnTriggerEnter(Collider collider)
    {
        //弓
        var handle = collider.GetComponentInParent<BowHandle>();
        //如果把箭架在弓上面，然後板機把弓箭放出去
        if (handle != null && obj != null && handle.aim.IsHeld() && obj.IsUsing())
        {
            handle.nockSide = collider.transform;
            //把弓箭複製出去
            GameObject coptaArrow = GameObject.Instantiate(arrow);

            coptaArrow.transform.parent = handle.arrowNockingPoint;
            CopyNotchToArrow();
            collider.GetComponentInParent<BowAim>().SetArrow(coptaArrow);

            //Destroy(gameObject);
        }
    }

    //複製一份
    private void CopyNotchToArrow()
    {
        GameObject notchCopy = Instantiate(gameObject, transform.position, transform.rotation) as GameObject;
        notchCopy.name = name;
        arrow.GetComponent<Arrow>().SetArrowHolder(notchCopy);
        arrow.GetComponent<Arrow>().OnNock();
    }

    //註冊事件
    protected override void RegistEvent()
    {
        //註冊事件
        _interact.InteractableObjectGrabbed += new InteractableObjectEventHandler(DoObjectGrab);
        //被使用
        _interact.InteractableObjectUsed += new InteractableObjectEventHandler(DoObjectUse);
        //板機被放開
        _interact.InteractableObjectUnused += new InteractableObjectEventHandler(DoObjectUnuse);
    }

    //抓取物件
    //基本上不做事前
    protected override void DoObjectGrab(object sender, InteractableObjectEventArgs e)
    {
        
    }

    //案下板機
    
    protected override void DoObjectUse(object sender, InteractableObjectEventArgs e)
    {
        
    }

    //板機放開，把弓箭放出去 
    //把弓箭複製出來，然後呼叫裡面的
    protected override void DoObjectUnuse(object sender, InteractableObjectEventArgs e)
    {
        
    }
}
