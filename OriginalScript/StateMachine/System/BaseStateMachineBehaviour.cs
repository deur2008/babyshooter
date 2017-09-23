using UnityEngine;
using System.Collections;

//所有狀態機都要繼承的base class
public class BaseStateMachineBehaviour : StateMachineBehaviour
{
    //取得 StateMachineManager，然後再透過轉型呼叫
    public StateMachineManager FindStateMachineManager(Animator animator)
    {
        return animator.gameObject.GetComponent<StateMachineManager>();
    }

    public float GetDeltaTime(Animator animator)
    {
        return animator.gameObject.GetComponent<StateMachineManager>().GetDeltaTime();
    }

}
