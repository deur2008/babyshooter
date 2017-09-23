using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//在某個狀態下可以判斷的所有條件
public class StageConditionListStateMachineBehaviour : StateMachineBehaviour
{
    //那個條件的parent的tag名稱
    public string _ConditionTagName;
    //所有條件
    public List<StageCondition> _listStageCondition;

    //通知Stage Controller 來到這個狀態了(?
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //取得目前場地管理器
        StageController controller = animator.GetComponent<StageController>();
        //把目前任務載入上來
        
        foreach (GameObject conditionList in controller._stageConditionManager.gameObject.transform)
        {
            //根據物件名稱
            if (conditionList.gameObject.name == _ConditionTagName)
            {
                _listStageCondition = new List<StageCondition>();
                foreach (StageCondition condition in conditionList.GetComponentsInChildren<StageCondition>())
                {
                    _listStageCondition.Add(condition);
                }
            }
        }

        //
        foreach (StageCondition condition in _listStageCondition)
        {
            condition.OnConditionEnter();
        }
    }

    //持續進行
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (StageCondition condition in _listStageCondition)
        {
            condition.OnConditionStay();
        }
    }

    //離開
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (StageCondition condition in _listStageCondition)
        {
            condition.OnConditionExit();
        }
    }

}
