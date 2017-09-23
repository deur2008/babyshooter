using UnityEngine;
using System.Collections;

//主要是對設定選單做管理
public class SettingManager : SceneManager
{
    //系統紀錄參數
    SystemRecord _record;

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
        //先取得上次登入的是哪個場景，int level是當作參考用

        if (level == SceneIndex.StartMenu)//切換到主畫面
        {
            GoToStartMenuScene();
        }
        else if (level == SceneIndex.MainMenu)
        {
            GoToMainMenuScene();
        }
    }

    //接換到遊戲開始場景
    void GoToStartMenuScene()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.StartMenu);
    }

    //接換到遊戲開始場景
    void GoToMainMenuScene()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.MainMenu);
    }

    //要傳遞給Scene接收的資料格式
    public class SettingSceneManagerJsonFormat : SceneManagerJsonFormat
    {

    }



}
