using UnityEngine;
using System.Collections;

//遊戲前過場動畫
public class BeforeGameSceneManager : SceneManager
{

    // Use this for initialization
    void Start()
    {
        //把CameraRigLoading到場景上面
        LoadCameraRigToScene();
        //處理遊戲類別
        ProcessGameType();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //切換場景
    public override void LoadScene(int level)
    {
        if (level == SceneIndex.Stage000) //表示執行遊戲
        {
            GoToInGameScene();
        }
    }

    //接換遊戲內部
    void GoToInGameScene()
    {
        //啥都不做，直接切過去
        FinishPassDataAndSwitchLavel(SceneIndex.Stage000);
    }

    //處理遊戲類別
    void ProcessGameType()
    {
        
    }

    
}
