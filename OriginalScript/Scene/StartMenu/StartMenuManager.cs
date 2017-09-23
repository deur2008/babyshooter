using UnityEngine;
using System.Collections;

//用來管理目前Menu選到的選單，還有根據對應的Animator去做操作
//新建紀錄 >> 紀錄 >>詢問
//讀取紀錄 >> 紀錄
//設定
//離開 >> 確認

//這邊主要是提供一些Function，給Animator呼叫，大體上跟Character差不多吧?
public class StartMenuManager : SceneManager {
    //動畫
    Animator _animator;
    //選得的index
    int _selectDataIndex;



    // Use this for initialization
    void Start()
    {
        //把CameraRigLoading到場景上面
        LoadCameraRigToScene();
        //然後把上一個封包的東西解開
        GetlastScenePassData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //離開遊戲
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    //設定選取的Data
    public void SelectData(int dataIndex)
    {
        _selectDataIndex = dataIndex;
    }

    //背景管理
    public void LoadBackGround()
    {

    }

    //要返回到上一個場景
    public override void BackToPreviousScene()
    {
        LoadScene(GetPreviousSceneIndex());
    }

    //切換場景
    public override void LoadScene(int level)
    {
        Debug.Log("Load Scene : " + level);
        //如果是要新建紀錄
        if (level == SceneIndex.BeforeGameTutorial)//要移動到教學
        {
            //準備資料
            PrepareNewUserData(_selectDataIndex);
            //最後是切換場景
            FinishPassDataAndSwitchLavel(level);
        }
        else if (level == SceneIndex.MainMenu)//移動到主畫面
        {
            GetOldUserData(_selectDataIndex);
            FinishPassDataAndSwitchLavel(level);
        }
        else if (level == SceneIndex.Setting)//移動到設定畫面
        {
            FinishPassDataAndSwitchLavel(level);
        }
    }

    //準備使用者資料
    public void PrepareNewUserData(int index)
    {
        //從序列化裡面取得資料
    }

    //讀取資料
    public void GetOldUserData(int index)
    {
        //SceneRecordManager
        SerializeDataManager.GetRecord(index);
    }

    public virtual StateMachineJsonFormat PreparePassData()
    {
        return new StateMachineJsonFormat();
    }
}
