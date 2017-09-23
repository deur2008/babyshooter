using UnityEngine;
using System.Collections;

//教學頁面
public class TutorialMenuSceneManager : SceneManager
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
        if (level == SceneIndex.MainMenu)//切換到主畫面
        {
            GoToMainMenuScene();
        }
    }

    //接換到主 畫面
    void GoToMainMenuScene()
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
