using UnityEngine;
using System.Collections;

//場景解鎖
public class UnlockSceneManager : SceneManager {

    // Use this for initialization
    void Start()
    {
        //把CameraRigLoading到場景上面
        LoadCameraRigToScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //切換場景
    public override void LoadScene(int level)
    {
        if (level == SceneIndex.MainMenu)//切換到主畫面
        {
            GoToMainMenuScene();
        }
        else if (level == SceneIndex.StartMenu)
        {
            GoToBeforeGameScene();
        }
    }

    //接換到FreeBattle 畫面
    void GoToMainMenuScene()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.MainMenu);
    }

    //切換到 BeforeGame
    void GoToBeforeGameScene()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.StartMenu);
    }
     
}
