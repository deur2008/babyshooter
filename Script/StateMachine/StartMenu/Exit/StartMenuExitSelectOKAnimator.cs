using UnityEngine;
using System.Collections;

//顯示選單
public class StartMenuExitSelectOKAnimator : BaseMenuStateMachineBehaviour
{
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
        //設定紀錄，做轉型後設定文字
        ((TextDialogUI)(_ui)).SetText("確定要離開嗎?");
    }

    //應該是不用做事情
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //如果被通知選擇了
    protected override void OnMenuNotifiedSelect()
    {
        Debug.Log("Select index");
        //選單
        if (GetSelectIndex() == 0)//yes的 index 是 0
        {
            _animator.SetBool(StartMenuAnimatorString.isOK, true);
        }
        else
        {
            OnMenuNotifiedCancel();
        }
    }

    //如果被通知取消了
    protected override void OnMenuNotifiedCancel()
    {
        _animator.SetBool(StartMenuAnimatorString.isExit, false);
        //把選單藏起來
        UnbindAll();
    }
}
