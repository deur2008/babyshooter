using UnityEngine;
using System.Collections;


public class StartMenuLoadDataAnimator : BaseMenuStateMachineBehaviour
{

    //打開紀錄，讀取
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialize(animator);
        //把 PanelUI 榜上去
        BindPanel();
        //把操作權限設定到目前的 PanelUI 上豔
        UpdateUIToRoomUI();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //如果被通知選擇了
    protected override void OnMenuNotifiedSelect()
    {
        _animator.SetBool(StartMenuAnimatorString.isNewDataSelect, true);
    }

    //如果被通知取消了
    protected override void OnMenuNotifiedCancel()
    {
        _animator.SetBool(StartMenuAnimatorString.isNewData, false);
        //把目前選單unbind
        UnbindAll();
    }
}
