using UnityEngine;
using System.Collections;

//顯示YesNo的Dialog
public class YesNoDialogAnimator : BaseYesNoDialogAnimator
{
    //顯示內容
    public string _context;
    //顯示yes的字
    public string _yesString;
    public bool _yesStringBool;
    public string _noString;
    public bool _noStringBool;


    //背景變暗
    //顯示Dialog

    //載入選單
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //初始化
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //設定顯示文字
        ((TextDialogUI)(_ui)).SetText(_context);

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
        _animator.SetBool(_yesString, _yesStringBool);
        //把選單藏起來
        UnbindAll();
    }

    //如果選擇"不是"
    public virtual void SelectedNo()
    {
        _animator.SetBool(_noString, _noStringBool);
        //把選單藏起來
        UnbindAll();
    }

    //如果被通知取消了
    protected override void OnMenuNotifiedCancel()
    {
        SelectedNo();
    }
}
