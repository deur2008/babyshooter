using UnityEngine;
using System.Collections;
using VRTK;

//顯示暫停選單的畫面
public class SteamVR_PauseGame : MonoBehaviour {

    //暫停
    //是不是要回到主畫面等等
    public TextDialogUI _showPausePrefab;

    public TextDialogUI _nowUsePaneUI;

    //如果切換到這邊就把Hint 載入進來
    public JoystickHint _hint;

    public bool _isPauseGame = false;

    //開始
    private void Start()
    {
        //註冊案下和放開的監聽
        GetComponent<VRTK_ControllerEvents>().ApplicationMenuPressed += new ControllerInteractionEventHandler(OnPressApplicationMenu);
        GetComponent<VRTK_ControllerEvents>().ApplicationMenuReleased += new ControllerInteractionEventHandler(OnReleaseApplicationMenu);
    }

    //顯示UI
    void OnEnable()
    {
        
    }

    //如果被禁止
    void OnDisable()
    {

    }

    //如果握住手上的按鈕
    private void OnPressApplicationMenu(object sender, ControllerInteractionEventArgs e)
    {
        
        
    }

    //放開握的按鈕
    private void OnReleaseApplicationMenu(object sender, ControllerInteractionEventArgs e)
    {
        //如果是按下選單，暫停
        if (_isPauseGame==false)
        {
            SetNowShowDialog(_showPausePrefab);
            ShowDialog();
            SetGameMode(SteamVR_CharacterController.ControlMode.PauseMode);

            //然後顯示目前設定
            GetComponent<SteamVR_CharacterHandController>()._UIController.SetToolTip(_hint);

            PauseGame(true);
        }
        else//暫停恢復
        {
            OnPanelCancel();
        }
    }

    //設定目前要顯示的Dialog
    //要複製到 _nowUsePaneUI 裡面，比較好處理
    protected void SetNowShowDialog(TextDialogUI indexpanel)
    {
        indexpanel.gameObject.SetActive(true);
        _nowUsePaneUI = Instantiate(indexpanel.gameObject).GetComponent<TextDialogUI>();
        indexpanel.gameObject.SetActive(false);
    }

    protected void SetDialogValue(object value)
    {
        _nowUsePaneUI.SetValue(value);
    }

    //顯示選單
    //透過Enemy選單傳到使用者前面
    protected void ShowDialog()
    {

        //傳送到頭盔前面
        GetComponent<SteamVR_CharacterHandController>()._characterController.ShowUI(_nowUsePaneUI.gameObject);
        //初始化
        _nowUsePaneUI.Initialize();
        //註冊事件
        _nowUsePaneUI._modelChanged += new DialogUI.ModelChangedEventHandler(OnPanelChange);
        _nowUsePaneUI._modelPressSelect += new DialogUI.ModelPressSelect(OnPanelSelect);
        _nowUsePaneUI._modelPressCancel += new DialogUI.ModelPressCancel(OnPanelCancel);
        //然後加上collison ，才能被感應到
        //AddPanel(_nowUsePaneUI.gameObject);
    }

    //如果要把選單隱藏起來
    protected void DestroyDialog()
    {

        //把傳送到頭盔前面的東西清掉
        //GetComponent<SteamVR_CharacterHandController>()._characterController.ShowUI(null);
        //把事件清掉
        _nowUsePaneUI.GetComponent<PanelUI>()._modelChanged -= new DialogUI.ModelChangedEventHandler(OnPanelChange);
        _nowUsePaneUI.GetComponent<PanelUI>()._modelPressSelect -= new DialogUI.ModelPressSelect(OnPanelSelect);
        _nowUsePaneUI.GetComponent<PanelUI>()._modelPressCancel -= new DialogUI.ModelPressCancel(OnPanelCancel);
        //然後把物件清掉
        Destroy(_nowUsePaneUI.gameObject, 0.1f);

    }

    //如果選單狀態改變
    protected virtual void OnPanelChange()
    {

    }

    //按下確定，表示要回到主畫面
    protected virtual void OnPanelSelect()
    {
        Application.LoadLevel(6);
    }

    //取消，表示繼續遊戲
    protected virtual void OnPanelCancel()
    {
        DestroyDialog();
        SetGameMode(SteamVR_CharacterController.ControlMode.PlayGame);
        PauseGame(false);
    }

    //設定遊戲模式
    void SetGameMode(SteamVR_CharacterController.ControlMode mode)
    {
        GetComponent<SteamVR_CharacterHandController>()._characterController.SetMode(mode);
    }

    //暫停遊戲
    void PauseGame(bool pause)
    {
        _isPauseGame = pause;
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
