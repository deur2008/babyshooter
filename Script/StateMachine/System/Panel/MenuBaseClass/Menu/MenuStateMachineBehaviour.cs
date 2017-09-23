using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//顯示選單
public class MenuStateMachineBehaviour : BaseMenuStateMachineBehaviour
{
    //顯示選單
    public List<string> _choiceStateMachineString;

    //顯示返回的string
    public string _backStateMachineString;
    public bool _backStateMachineStringBool;

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

    //應該是不用做事情
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
        Debug.Log("Select index");
        for (int i = 0; i < _choiceStateMachineString.Count; i++)
        {
            //如果選到選項
            if (GetSelectIndex() == i)
            {
                _animator.SetBool(_choiceStateMachineString[i], true);
            }
        }
    }

    //如果被通知取消了
    protected override void OnMenuNotifiedCancel()
    {
        _animator.SetBool(_backStateMachineString, _backStateMachineStringBool);
    }

}
