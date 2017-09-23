using UnityEngine;
using System.Collections;


//新建紀錄後的遊戲事前教學
public class BeforeGameTutorialSceneManager : SceneManager
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
        Debug.Log("Load Scene : " + level);
        //如果是要新建紀錄
        if (level == SceneIndex.StartMenu)//要移動到開始畫面
        {
            //切換場景
            FinishPassDataAndSwitchLavel(level);
        }
        else if (level == SceneIndex.MainMenu)//移動到主畫面
        {
            //把紀錄標示成已經完成教學
            SetDataIsFinishTutorial();
            //把資料存到硬碟上
            SaveUserData();
            //切換場景
            FinishPassDataAndSwitchLavel(level);
        }
    }

    //設定已經完成基本教學
    public void SetDataIsFinishTutorial()
    {
        SceneRecordManager.FinishBasicTutorial = true;
    }
    


}
