using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//base class
//如果只是要單純切換場景也可以使用
public class LoadLevelBaseStateMachineBehaviour : BaseStateMachineBehaviour {


    //這邊可以用DropDown呈現
    //要移動的Scene
    public SceneIndex.SceneTypes _goToScene;

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

    //切換關卡
    protected virtual void SwitchScene(Animator animator)
    {
        try
        {
            //取得選擇的場景
            int gotoIndex = SceneIndex.GetEnumItemTypesResult(_goToScene);
            FindStateMachineManager(animator).LoadScene(gotoIndex);

            //切換場景
            //也可能是呼叫SceneManager
            //UnityEngine.SceneManagement.SceneManager.LoadScene(gotoIndex);

            //Scene _scene = new Scene();
            //_scene.
            //SceneManager.LoadScene(5);

        }
        catch (Exception ex)
        {

        }

    }
}
