using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//管理遊戲狀態流程
//也是根據狀態機的位置，然後在對這邊的函數做呼叫
public class GameSceneManager : SceneManager{

    //傳進來的值
    GameSceneManagerJsonFormat _passParameter;

    //是否成功，成功由GameSceneManager 顯示
    public bool _successGame;
    //目前的階段
    public int _stage = 0;

    //所有的場景
    public List<StageController> _listSceneManager;

    //目前的廠景
    //已經在Scene上面了
    //目前是依附在GameSceneManager 上面
    public StageController _nowState;

    // Use this for initialization
    void Start()
    {
        //從上一個場景把資料loading進來
        _passParameter=(GameSceneManagerJsonFormat)GetlastScenePassData();
        //如果沒有資料的話就建立假的
        if (_passParameter == null)
        {
            _passParameter = CreateFakeData();
        }
        //把CameraRig Loading到場景上面
        LoadCameraRigToScene();
        //處理傳遞的資訊
        ProcessPassData(_passParameter);

        //設定腳色這個是遊戲一開始start
        //如果之後遊戲死掉回復就不會顯示start

        //把目前需要的stage Loading到Scene上面
        if (SwitchToStage(_stage))
        {
            Debug.Log("SwitchToStageSuccess");
        }
        else
        {
            //表示沒有場景
            Debug.Log("SwitchToStageFail");
        }
        
    }

    //把[CameraRig]Loadint到場景上面?
    public override void LoadCameraRigToScene(Vector3 positino = new Vector3())
    {
        //也是把CameraRig Loading進來
        base.LoadCameraRigToScene();
        //然後註冊一些事件
        //例如 HP Empty
        //時間到了等等
        _player.GetComponent<SteamVR_CharacterController>()._playerTimeOut += new SteamVR_CharacterController.PlayerTimeOut(SystemTimeOut);
        _player.GetComponent<SteamVR_CharacterController>()._playerHPEmpty += new SteamVR_CharacterController.PlayerHPEmpty(HPempty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //把轉移到指定場景
    bool SwitchToStage(int stageIndex)
    {
        try
        {
            //先指定
            _nowState = _listSceneManager[stageIndex];
        }
        catch
        {
            return false;
        }
        

        //把場景複製過來
        //_nowState = Instantiate(_listStage[stageIndex]);
        //_nowState.transform.parent = this.transform;

        //還有設定關卡的參數
        _nowState._difficulity = _passParameter.difficulity;
        //把玩家設定上去
        _nowState.SetPlayer(_player);
        //然後是設定事件
        _nowState._playerFinishStage += new StageController.PlayerFinishStage(StageFinishGoal); //完成關卡，就跳到下一個關卡，如果沒關卡了就顯示結果
        _nowState._playerStageFall += new StageController.PlayerStageFall(StageFall); // 直接切回第一個關卡?
        _nowState._playerExitGame += new StageController.PlayExitGame(GoToMainMenuScene); //直接離開遊戲
        _nowState._playerRestartGame += new StageController.PlayerRestartGame(Restart); //重新開始遊戲

        //如果要設定時間
        if (_passParameter.limitStageTime)
        {
            //_nowState.GetComponent<StageController>().SetTimeLimit();
        }
        //把人物設定是在哪個場景
        _player.GetComponent<SteamVR_CharacterController>().SetNowAtStageController(_nowState.GetComponent<StageController>());
        //在通知廠景要開始惹
        _nowState.GetComponent<StageController>().StartGame();

        //如果時間不是9999，就代表使用系統時間

        try
        {
            

        }
        catch (Exception ex)
        {
            Debug.Log("Scene Error :" +ex.Message);
        }
        return true;
    }

    //如果關卡完成階段
    //會根據不同階段數去顯示目前是第幾階段，或是已經完成要求
    void StageFinishGoal()
    {
        int totalGoal = 1;
        int finishGoal_index = 0;
    }

    void StageFall()
    {
        int totalGoal = 1;
        int finishGoal_index = 0;
    }

    //到達指定地點
    //看要不要根據提早時間加分
    void StageFinishStage(float remainTime = 0)
    {
        if (_passParameter.stageList.Count > (_stage + 1))
        {
            //如果還有階段就跳到下一個階段
            _stage++;
            SwitchToStage(_stage);
        }
        else
        {
            //如果沒有就顯示完成
        }
    }

    //關卡內部時間到惹
    void StageAlertRemainTime(float remainTime = 0)
    {

    }

    //系統時間到惹
    //被呼叫
    void SystemTimeOut(int remainTime = 0)
    {

    }

    //檢查玩家是不是死掉惹
    //被呼叫
    //從player註冊事件
    void HPempty()
    {

    }

    //更新UI顯示
    //只有在腳色改變狀態時會呼叫
    public void UpdateCharacterUI()
    {

    }

    //暫停遊戲
    public void PauseGame(bool pause)
    {

    }

    //處理傳遞過來的物件
    public override void ProcessPassData(StateMachineJsonFormat Format=null)
    {
        //傳進去
        _passParameter = (GameSceneManagerJsonFormat)Format;
        //然後作處理
    }

    //如果要結束這個場景，要把物件整理好傳遞給下一個場景
    public override StateMachineJsonFormat PreparePassData()
    {
        return new StateMachineJsonFormat();
    }

    //把紀錄保存起來，記錄成檔案
    public void SaveResultToImage()
    {

    }

    //把目前狀態弄成紀錄
    public void MakeRecord()
    {

    }

    //載入地圖
    public void LoadTerrain()
    {

    }

    //切換場景
    public override void LoadScene(int level)
    {
        //如果切換到的是freeBattle的選單頁面
        if (level == SceneIndex.MainMenu)//對戰選單
        {
            GoToFreeBattleScene();
        }
        else if (level == SceneIndex.MainMenu)//切換到主畫面
        {
            GoToMainMenuScene();
        }
    }

    //接換到FreeBattle 畫面
    void GoToFreeBattleScene()
    {
        FinishPassDataAndSwitchLavel(SceneIndex.MainMenu);
    }

    //接換到主 畫面
    void GoToMainMenuScene()
    {
        //存檔
        if (_successGame)
            SaveResult();
        //回到主畫面
        FinishPassDataAndSwitchLavel(SceneIndex.MainMenu);
    }

    //重新開始
    //直接重新載入整個場景
    public void Restart()
    { 
        FinishPassDataAndSwitchLavel(SceneIndex.GetEnumItemTypesResult(_sceneIndexType));
    }

    //如果是win，最後要對結果作儲存
    public void SaveResult()
    {
        //整理資料到 SceneRecordManager 裡面
        //把資料寫回硬碟
        SaveUserData();
    }

    //在FreeBattle裡面會用到的
    //主要是儲存一些預Load進來時的一些腳色參數
    //因為navMask 沒辦法用prefab的方式
    //所以每個Stage都會做成一個Scene 來使用
    public class GameSceneManagerJsonFormat : SceneManagerJsonFormat
    {
        //建構
        public GameSceneManagerJsonFormat()
        {
            stageList = new List<global::StageGameObjectSingleItem>();
        }
        //要載入的關卡list
        //裡便包含關卡路徑(Scene位置) 和
        public List<StageGameObjectSingleItem> stageList;

        //接下來是一些系統參數
        public int BGM;//BGM，目前不實作
        public int PlayTime;//遊玩時間
        public int winCondition;//勝利條件 
        public bool limitStageTime; //限制每個關卡需要的時間
        public bool if_FailBackToFirstStage = false; //如果死掉就要回到第一關
        public int nowStage位置; //目前所在場景位置

        //難度 : 關卡
        //public enum Difficulity { easy, snormalword, hard, insame }; //難度
        public StageController.Difficulty difficulity= StageController.Difficulty.normal; //目前選擇，預設難度是正常
    }

    //建立假的資料，方便測試
    public GameSceneManagerJsonFormat CreateFakeData()
    {
        GameSceneManagerJsonFormat format = new GameSceneManagerJsonFormat();

        //把目前先暫時拉上去的都當作傳進來的
        /*
        foreach (GameObject stage in _listStage)
        {
            StageGameObjectSingleItem stageItem = new StageGameObjectSingleItem();
            stageItem.StageName = "關卡w";
            stageItem.StageInfo = "關卡說明w";
            stageItem.Stage = stage;
            format.stageList.Add(stageItem);
        }
        */
       
        format.PlayTime = 150;
        format.winCondition = 1;
        format.limitStageTime = true;
        format.if_FailBackToFirstStage = false;//死掉可以待在同一關
        //format.difficulity= StageController.Difficulty.insame;//先從簡單開始
        //回傳
        return format;
    }

}
