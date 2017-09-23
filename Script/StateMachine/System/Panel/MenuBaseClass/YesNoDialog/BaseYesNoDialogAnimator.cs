using UnityEngine;
using System.Collections;

public class BaseYesNoDialogAnimator : BaseMenuStateMachineBehaviour
{

    //背景變暗
    //顯示Dialog

    //載入選單
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_roomUIObject == null)
        {
            LoadDefaultYesNoDialog(ref _roomUIObject);
        }
        Initialize(animator);
        //把 PanelUI 榜上去
        BindPanel();
        //把操作權限設定到目前的 PanelUI 上豔
        UpdateUIToRoomUI();
        //設定控制全
        SetRoomUIAsTarget();
        //設定紀錄，做轉型後設定文字
        ((TextDialogUI)(_ui)).SetText("確定要載入新紀錄嗎?");

    }

    //如果_roomUIObject 是空的
    public void LoadDefaultYesNoDialog(ref GameObject _object)
    {
        _object = GameObject.Find("/Assets/Prefab/UI/System/Dialog/SmallDialog/YesNoDialog/YesNoDialog");
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
        //選單
        if (GetSelectIndex() == 0)//yes的 index 是 1
        {
            SelectedYes();
        }
        else
        {
            SelectedNo();
        }
    }

   

    //如果選擇"是"
    public virtual void SelectedYes()
    {
        
        //把選單藏起來
        UnbindAll();
    }

    //如果選擇"不是"
    public virtual void SelectedNo()
    {
        //把選單藏起來
        UnbindAll();
    }

    //如果被通知取消了
    protected override void OnMenuNotifiedCancel()
    {
        SelectedNo();
    }
}
