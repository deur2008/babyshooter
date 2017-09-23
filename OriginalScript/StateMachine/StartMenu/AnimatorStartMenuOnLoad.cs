using UnityEngine;
using System.Collections;

//當切換到某個場景時，要先一些從上一個場景內的物件pass過來
//先暫時不實作
public class AnimatorStartMenuOnLoad : StateMachineBehaviour
{
    //呼叫一次
    //然後就會跳過了
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //基本上不會經過這邊
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //基本上不會經過這邊
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
