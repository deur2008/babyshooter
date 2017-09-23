using UnityEngine;
using System.Collections;

//彈出對話框，是否要載入紀錄
public class StartMenuNewDataOKAnimator : BaseYesNoDialogAnimator
{

	//背景變暗
    //顯示Dialog
    
    //載入選單
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //base class
        base.OnStateEnter(animator,stateInfo, layerIndex);
        //然後設定文字
        ((TextDialogUI)(_ui)).SetText("確定要載入新紀錄嗎?");
        
    }

	//應該是不用做事情
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

    //離開
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        UnbindAll();
    }

    //如果選擇"是"
    public override void SelectedYes()
    {
        _animator.SetBool(StartMenuAnimatorString.isOK, true);
        //把選單藏起來
        UnbindAll();
    }

    //如果選擇"不是"
    public override void SelectedNo()
    {
        _animator.SetBool(StartMenuAnimatorString.isNewDataSelect, false);
        //把選單藏起來
        UnbindAll();
    }
}
