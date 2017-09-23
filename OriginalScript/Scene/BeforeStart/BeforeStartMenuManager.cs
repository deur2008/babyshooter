using UnityEngine;
using System.Collections;

//遊戲開始前的Logo撥放
public class BeforeStartMenuManager : SceneManager
{
    //動畫
    Animator _animator;

    // Use this for initialization
    void Start()
    {
        //把CameraRigLoading到場景上面
        LoadCameraRigToScene();
    }

    // Update is called once per frame
    void Update () {
        PressOKKey();
    }

    //
    void PressOKKey()
    {
        if (Input.GetKeyDown("space"))
        {
            _animator.SetTrigger("PressOK");
        }
    }

    //切換場景
    public override void LoadScene(int level)
    {
        if (level == SceneIndex.StartMenu)//切換到主畫面
        {
            GoToStartMenuScene();
        }
    }

    //接換到遊戲開始場景
    void GoToStartMenuScene()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.StartMenu);
    }
}
