using UnityEngine;
using System.Collections;

//燈光系統，可以用來設定燈光的一些表現
public class SettingLightSystemManager : SceneManager
{

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
        if (level == SceneIndex.Setting)//切換到設定
        {
            GoToSettingScene();
        }
    }


    //接換到主 畫面
    void GoToSettingScene()
    {
        //存檔
        SaveResult();
        //回到主畫面
        FinishPassDataAndSwitchLavel(SceneIndex.MainMenu);
    }

    //如果是win，最後要對結果作儲存
    public void SaveResult()
    {
        //整理資料到 SceneRecordManager 裡面

        //把資料寫回硬碟
        SaveUserData();
    }
}
