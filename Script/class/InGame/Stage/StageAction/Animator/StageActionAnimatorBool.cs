using UnityEngine;
using System.Collections;

//如果是要執行把Animator Controller 切換到其他 狀態
public class StageActionAnimatorBool : StageAction
{
    //設定bool
    public string _animatorString;
    //bool
    public bool _isBool;


    //開始動作
    public override void StartAction()
    {
        _stageCondition.StageController._animator.SetBool(_animatorString, _isBool);
    }
}
