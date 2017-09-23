using UnityEngine;
using System.Collections;

//遊戲主選單
public class MainMenuAnimator : BaseMenuStateMachineBehaviour
{

    //在進入狀態
    //把StartMenuLoad近來
    //把控制權附上去
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base class
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //
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

    //如果按下返回按鈕
    protected override void OnMenuNotifiedCancel()
    {
        Debug.Log("GetCanael");
        _animator.SetBool(MainMenuManagerString.isBack, true);
    }

    //設定選單要換的位置
    void ChangeStateMachine(int index)
    {
        Debug.Log("Select index=" + index);

        if (index == 0)//教學
        {
            _animator.SetBool(MainMenuManagerString.isTurtorial, true);
        }
        else if (index == 1)//單人遊玩
        {
            _animator.SetBool(MainMenuManagerString.isSinglePlay, true);
        }
        else if (index == 2)//多人
        {
            _animator.SetBool(MainMenuManagerString.isMultiplePlay, true);
        }
        else if (index == 3)//好友管理
        {
            _animator.SetBool(MainMenuManagerString.isFriendList, true);
        }  
        else if (index == 4)//解鎖地圖
        {
            _animator.SetBool(MainMenuManagerString.isUnlock, true);
        }
        else if (index == 5)//劇情
        {
            _animator.SetBool(MainMenuManagerString.isStoryMode, true);
        }
        else if (index == 6)//商店
        {
            _animator.SetBool(MainMenuManagerString.isStore, true);
        }
        else if (index == 7)//設定
        {
            _animator.SetBool(MainMenuManagerString.isSetting, true);
        }
        else if (index == 8)//個人資料
        {
            _animator.SetBool(MainMenuManagerString.isViewProfile, true);
        }
    }

    //把所有都設定成false;
    void SetAllFalse()
    {
        _animator.SetBool(MainMenuManagerString.isTurtorial, false);
        _animator.SetBool(MainMenuManagerString.isSinglePlay, false);
        _animator.SetBool(MainMenuManagerString.isMultiplePlay, false);
        _animator.SetBool(MainMenuManagerString.isFriendList, false);
        _animator.SetBool(MainMenuManagerString.isUnlock, false);
        _animator.SetBool(MainMenuManagerString.isStoryMode, false);
        _animator.SetBool(MainMenuManagerString.isStore, false);
        _animator.SetBool(MainMenuManagerString.isSetting, false);
        _animator.SetBool(MainMenuManagerString.isViewProfile, false);
    }
}
