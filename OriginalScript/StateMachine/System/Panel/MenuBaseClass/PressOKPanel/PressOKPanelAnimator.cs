using UnityEngine;
using System.Collections;

//按下OK之後就可以跳到下一個場
public class PressOKPanelAnimator : BaseMenuStateMachineBehaviour
{
    //單位是秒
    public float _waitTime;
    //計時時間
    float _time;
    //如果是按下OK，通通都是用trigger觸發好了 : )
    public string _pressOKString;

    //背景變暗
    //顯示Dialog

    //載入選單
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialize(animator);
        //把 PanelUI 榜上去
        BindPanel();
        //把操作權限設定到目前的 PanelUI 上豔
        UpdateUIToRoomUI();
        //設定控制全
        SetRoomUIAsTarget();
    }

    //計時
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //算出間距時間
        _time = _time + GetDeltaTime(animator);
    }

    //如果要離開
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //把選單藏起來
        UnbindAll();
    }

    //如果被通知選擇了
    protected override void OnMenuNotifiedSelect()
    {
        //表示時間到了，可以切到下一頁
        if (_time > _waitTime)
        {
            _animator.SetTrigger(_pressOKString);
        }
    }

    
    //如果被通知取消了
    protected override void OnMenuNotifiedCancel()
    {
       
    }
}
