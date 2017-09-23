using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

//會切換到其他Scene  
public class AnimatorLoadLevel : LoadLevelBaseStateMachineBehaviour
{
    //移動到某個Scene
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //把要傳遞的值準備好

        //切換關卡
        SwitchScene(animator);
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
