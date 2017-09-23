using UnityEngine;
using System.Collections;

//對戰前的裝備準備
public class FreeBattleSceneManager : SceneManager
{
   

	// Use this for initialization
	void Start () {
        //把CameraRigLoading到場景上面
        LoadCameraRigToScene();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //切換場景
    public override void LoadScene(int level)
    {
        if (level == SceneIndex.MainMenu)//切換到主畫面
        {
            GoToMainMenuScene();
        }
        else if(level==SceneIndex.StartMenu) //表示選擇角社選單
        {
            GoToBeforeGameScene();
        }
    }
    
    
    //儲存角色參數的Class

    //接換到遊戲選單
    void GoToMainMenuScene()
    {
        //離開
        FinishPassDataAndSwitchLavel(SceneIndex.MainMenu);
    }

    //接換到遊戲開始場景
    void GoToBeforeGameScene()
    {
        //把參數打包

        //離開
        FinishPassDataAndSwitchLavel(SceneIndex.StartMenu);
    }

    //在FreeBattle裡面會用到的
    public class FreeBattleSceneManagerJsonFormat : SceneManagerJsonFormat
    {

    }

    
}
