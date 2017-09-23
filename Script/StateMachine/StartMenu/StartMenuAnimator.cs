using UnityEngine;
using System.Collections;

//繼承 BaseMenuStateMachineBehaviour
public class StartMenuAnimator : BaseMenuStateMachineBehaviour
{

    //在進入狀態
    //把StartMenuLoad近來
    //把控制權附上去
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialize(animator);
        //把 PanelUI 榜上去
        BindPanel();
        //把那四個選項都設定成false;
        SetAllFalse();
        //把操作權限設定到目前的 PanelUI 上豔
        UpdateUIToRoomUI();
        //設定控制
        SetRoomUIAsTarget();
    }

    //Loop
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //離開
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UnbindAll();
    }

    //如果被通知選擇了
    protected override void OnMenuNotifiedSelect()
    {
        Debug.Log("GetSelect");
        try
        {
            //取得選單序號
            int index = GetSelectIndex();
            //設定結果
            ChangeStateMachine(index);
            //然後把目前頁面隱藏
            UnbindAll();
        }
        catch
        {

        }
    }

    //設定選單要換的位置
    void ChangeStateMachine(int index)
    {
        Debug.Log("Select index=" + index);
        if (index == 0)
        {
            _animator.SetBool(StartMenuAnimatorString.isNewData, true);
        }
        else if (index == 1)
        {
            _animator.SetBool(StartMenuAnimatorString.isLoadData, true);
        }
        else if (index == 2)
        {
            _animator.SetBool(StartMenuAnimatorString.isSetting, true);
        }
        else if (index == 3)
        {
            _animator.SetBool(StartMenuAnimatorString.isExit, true);
        }
    }

    //把所有都設定成false;
    void SetAllFalse()
    {
        _animator.SetBool(StartMenuAnimatorString.isNewData, false);
        _animator.SetBool(StartMenuAnimatorString.isLoadData, false);
        _animator.SetBool(StartMenuAnimatorString.isSetting, false);
        _animator.SetBool(StartMenuAnimatorString.isExit, false);
    }
}
