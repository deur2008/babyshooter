using UnityEngine;
using System.Collections;
using System;

//BaseClass//目前使用不到多型了
//但和AI 操作人物方式一樣，目前是改用一個專焚放參數，已經整理好的指令，例如上，下，發射等等指定
//目前在思考要要不要改成使用人物裡面提供的function(例如UP，DOWN等等)，去驅動人物
//如果要驅動人物，要讓Character套用在這個Class上面
//
//或許用不到多型，但估計會用到繼承吧?
//宣告上比較好宣告

//這個腳本目前依附在 [controlRig] 上面
public class SteamVR_CharacterController : MonoBehaviour {

    //目前模式，要控制選單還是玩遊戲
    //如果玩遊戲就要把指標功能鎖住
    public enum ControlMode { ControlMenu,PlayGame,PauseMode };
    public ControlMode _nowMode;

    //玩家會取得目前在的Stage
    public StageController _nowOnStage;

    //指定要控制的腳色ID
    //腳色本身
    //如果是守塔遊戲就會把腳色換掉
    public Character _character;

    //相機
    public GameObject _cameraPosition;

    //可不可以移動
    public bool _enableMove;

    //然後有一些事件可以提供
    //時間快到了
    public delegate void PlayerTimeOut(int remainTime = 0);
    public event PlayerTimeOut _playerTimeOut;

    //HP沒了
    public delegate void PlayerHPEmpty();
    public event PlayerHPEmpty _playerHPEmpty;


    // Use this for initialization
    void Start() {

        //更新顯示狀態
        SetCharacter(_character);

        //更新操作狀態
        SetMode(_nowMode);
    }

    bool _initialTargetList = false;

    // Update is called once per frame
    void Update() {

        //還有要把Hand位置複製到 CollisonArea 上面
        MoveCharacterCollisonDetectArea();

    }

    //移動位置OK
    void MoveCharacterCollisonDetectArea()
    {
        try
        {
            _cameraPosition.transform.localPosition = new Vector3(GetComponent<SteamVR_ControllerManager>().head.transform.localPosition.x, 0.0f, GetComponent<SteamVR_ControllerManager>().head.transform.localPosition.z);
            _cameraPosition.transform.localRotation = Quaternion.Euler(0, GetComponent<SteamVR_ControllerManager>().head.transform.localRotation.eulerAngles.y, 0);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        
    }

    //設定腳色
    public void SetCharacter(Character character)
    {
        _character = character;
        //更新腳色定義
        GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>()._characterInfoGUI.SetCharacter(_character);
    }

    //顯示選單
    //目前只顯示頭部
    public void ShowUI(GameObject menu)
    {
        if (GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>() == null)
            Debug.Log("Handset is null");

        //Debug.Log(menu.name);
        GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>().SetUI(menu);
    }

    //設定目前模式
    public void SetMode(ControlMode mode)
    {
        _nowMode = mode;

        GetComponent<SteamVR_ControllerManager>().left.GetComponent<SteamVR_CharacterHandController>().SetControlMode(_nowMode);
        GetComponent<SteamVR_ControllerManager>().right.GetComponent<SteamVR_CharacterHandController>().SetControlMode(_nowMode);
        GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>().SetControlMode(_nowMode);

        //左右手更新模式
        try
        {
            
        }
        catch (Exception ex)
        {

        }
    }

    //============================= stage =========================
    //如果是一般的模式
    void SetStageController(StageController nowOnStage)
    {
        /*
        //先把之前的事件清掉
        nowOnStage._playerFinishStage -= new StageController.PlayerFinishStage(ShowStageFinishGoal);
        nowOnStage._playerFinishStage -= new StageController.PlayExitGame(FinsiahStage);
        nowOnStage._playerRestartGame -= new StageController.PlayerRestartGame(TimeOut);
        //然後增加事件
        nowOnStage._playerFinishStage += new StageController.PlayerFinishStage(ShowStageFinishGoal);
        nowOnStage._playerFinishStage += new StageController.PlayExitGame(FinsiahStage);
        nowOnStage._playerRestartGame += new StageController.PlayerRestartGame(TimeOut);
        */
    }

    //==========================public======================

    //設定目前在的Stage
    public void SetNowAtStageController(StageController nowOnStage)
    {
        _nowOnStage = nowOnStage;
        //然後取得共通參數，和一些事件
        SetStageController(_nowOnStage);
    }

    //設定武器
    //把左右手的武器都設定上去
    public void SetWeaponSelector(WeaponGameObjectSelector weaponSelector)
    {
        //把武器設定在腳色裡面
        //_character.SetWeapon(weaponSelector);
        //然後指定使用第一個武器
    }

    //把目前要用的UI掛載上去
    //先不實做
    public void UploadStandardUI(GameObject UI)
    {
        //把UI丟進去
        GetComponent<SteamVR_ControllerManager>().head.GetComponent<SteamVRCharacterHeadController>().SetUI(UI);
    }

    /*
    //關卡一開始
    public void SetStartStage(int totalGoal = 1, int finishGoal_index = 0)
    {
        //人物要從關卡那邊取得時間，並自動計時
        _infoGUI._inGameSystemUI.ShowStartStage(totalGoal, finishGoal_index);
    }

    //設定Finish
    public void FinsiahStage(float remainTime)
    {
        _infoGUI._inGameSystemUI.ShowFinish(remainTime);
    }

    //顯示失敗畫面
    public void SetFall(float remainTime=0)
    {
        _infoGUI._inGameSystemUI.ShowFallUI(remainTime);
    }

    //顯示結果
    public void ShowResult()
    {
        _infoGUI._inGameSystemUI.ShowResultUI();
    }

    //顯示目前完成第幾階段，共多少階段
    public void ShowStageFinishGoal()
    {
        int totalGoal = 1;
        int finishGoal_index = 0;
        _infoGUI._inGameSystemUI.ShowFinishtStage(totalGoal, finishGoal_index);
    }

    //提示到達指定地點
    public void ShowHintGoToStageFinishArea(int remainTime = 0)
    {
        _infoGUI._inGameSystemUI.ShowHintGoToStageFinishArea(remainTime);
    }

    //設定敵人進度
    //0~100
    public void SetEnemyProgress(float progress=50)
    {
        _infoGUI.SetEnemyProgress(progress);
    }

    //設定本身的進度
    //0~100
    public void SetMineProgress(float progress=50)
    {
        _infoGUI.SetEnemyProgress(progress);
    }

    //顯示
    public void TimeOut(float remainTime)
    {
        _infoGUI._inGameSystemUI.TimeOut(remainTime);
    }

    */
}
