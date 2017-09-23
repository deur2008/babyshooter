using UnityEngine;
using System.Collections;

//用來管理 主選單
public class MainMenuManager : SceneManager{
    //選單
    public GameObject _StageMenu;
    //是否要進入關卡
    public GameObject _YesNoMenu;
    //目前選到的關卡
    public int _nowSelectedStage = -1;
    //目前選到的名稱
    public string _selectedName;

    //如果按鈕被按到
    public void StageIsSelected(int number)
    {
        //如果沒有顯示確認方塊
        if (_YesNoMenu.gameObject.activeInHierarchy == false)
        {
            _nowSelectedStage = number;
            _YesNoMenu.SetActive(true);
            Debug.Log("Button Click : " + _nowSelectedStage);
        }
    }

    // Use this for initialization
    void Start()
    {
        //把CameraRigLoading到場景上面
        LoadCameraRigToScene();
        //然後把 _YesNoMenu 隱藏
        _YesNoMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //是否要進入關卡
    public void SureStage(bool sure)
    {
        if (sure)
        {
            LoadScene(_nowSelectedStage);
        }
        else
        {
            _YesNoMenu.SetActive(false);
        }
    }

    //進入選單
    public override void LoadScene(int level)
    {
        if (level == SceneIndex.Stage000)//Stage000
        {
            GoToStage000();
        }
        else if (level == SceneIndex.Stage001)//Stage001
        {
            GoToStage001();
        }
        else if (level == SceneIndex.Stage002)//Stage002
        {
            GoToStage002();
        }
        else if (level == SceneIndex.Stage003)//Stage003
        {
            GoToStage003();
        }
        else if (level == SceneIndex.Stage004)//Stage004
        {
            GoToStage004();
        }
        else if (level == SceneIndex.Stage005)//Stage005
        {
            GoToStage005();
        }
        else if (level == SceneIndex.Stage006)//Stage006
        {
            GoToStage006();
        }
        else if (level == SceneIndex.Stage007)//Stage007
        {
            GoToStage007();
        }
        else if (level == SceneIndex.Stage008)//Stage008
        {
            GoToStage008();
        }

    }

    //接換到教學
    //好像目前都不需要準備資料
    void GoToStage000()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage000);
    }

    //FreeBattle
    void GoToStage001()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage001);
    }

    //遊戲好友
    void GoToStage002()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage002);
    }

    //解鎖
    void GoToStage003()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage003);
    }

    //接換到Story
    void GoToStage004()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage004);
    }

    //接換到Store
    void GoToStage005()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage005);
    }

    //接換到設定
    void GoToStage006()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage006);
    }

    //接換到Profile
    void GoToStage007()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage007);
    }

    //退回到開始畫面
    void GoToStage008()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.Stage008);
    }

    
}

