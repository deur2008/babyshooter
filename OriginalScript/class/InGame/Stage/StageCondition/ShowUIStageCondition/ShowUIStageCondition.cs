using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using VRTK;

//依序顯示完所有UI，然後所有UI都有回應後，才會 StageCondition Fill
public class ShowUIStageCondition : StageCondition
{
    //要顯示UI
    public List<PanelUI> _dialogUIList;

    //目前對話框進度
    public int _dialogIndex;

    public PanelUI _nowUsePaneUI;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //=============public virtual==============

    //設定值
    public override void SetVaule(object value)
    {

    }

    //初始化
    public override void Initialize()
    {

    }

    //動作被執行的一開始
    public override void OnConditionEnter()
    {
        if (_dialogUIList.Count > 0)
        {
            SetNowShowDialog(_dialogUIList[0]);
            ShowDialog();
        }
    }

    //動作正在被執行
    public override void OnConditionStay()
    {

    }

    //動作離開
    public override void OnConditionExit()
    {

    }

    //取得目前的值
    public override object GetValue()
    {
        return _dialogUIList;
    }

    //================private==========

    //設定目前要顯示的Dialog
    //要複製到 _nowUsePaneUI 裡面，比較好處理
    protected void SetNowShowDialog(PanelUI indexpanel)
    {
        indexpanel.gameObject.SetActive(true);
        _nowUsePaneUI = Instantiate(indexpanel.gameObject).GetComponent<PanelUI>();
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
        _stageController._cameraRig.GetComponent<SteamVR_CharacterController>().ShowUI(_nowUsePaneUI.gameObject);
        //初始化
        _nowUsePaneUI.Initialize();
        //註冊事件
        _nowUsePaneUI._modelChanged += new DialogUI.ModelChangedEventHandler(OnPanelChange);
        _nowUsePaneUI._modelPressSelect += new DialogUI.ModelPressSelect(OnPanelSelect);
        _nowUsePaneUI._modelPressCancel += new DialogUI.ModelPressCancel(OnPanelCancel);
        //然後加上collison ，才能被感應到
        AddPanel(_nowUsePaneUI.gameObject);
    }

    //如果要把選單隱藏起來
    protected void DestroyDialog()
    {

        //把傳送到頭盔前面的東西清掉
        //_stageController._cameraRig.GetComponent<SteamVR_CharacterController>().ShowUI(null);
        //把事件清掉
        _nowUsePaneUI.GetComponent<PanelUI>()._modelChanged -= new DialogUI.ModelChangedEventHandler(OnPanelChange);
        _nowUsePaneUI.GetComponent<PanelUI>()._modelPressSelect -= new DialogUI.ModelPressSelect(OnPanelSelect);
        _nowUsePaneUI.GetComponent<PanelUI>()._modelPressCancel -= new DialogUI.ModelPressCancel(OnPanelCancel);
        //然後把物件清掉
        Destroy(_nowUsePaneUI.gameObject,0.1f);

    }

    //如果選單狀態改變
    protected virtual void OnPanelChange()
    {

    }

    protected virtual void OnPanelSelect()
    {
        DialogFinish();
    }

    protected virtual void OnPanelCancel()
    {

    }

    //如果選單完成了
    protected void DialogFinish()
    {
        //Debug.Log("DialogFinish");
        //如果還有下一個
        if (_dialogIndex < (_dialogUIList.Count-1))
        {
            Debug.Log("_dialogIndex < (_dialogUIList.Count-1)");
            _dialogIndex = _dialogIndex + 1;
            //把目前使用的Dialog 清掉
            DestroyDialog();
            //顯示下一個選單
            SetNowShowDialog(_dialogUIList[_dialogIndex]);
            ShowDialog();
        }
        else
        {
            //Debug.Log("ConditionFinish");
            //把目前使用的Dialog 清掉
            //表示這個action完成了
            ConditionFinish();
            //
            DestroyDialog();
            
        }
    }

    //這邊會把所有的Canvas 通通都加上 Collider
    private void AddPanel(GameObject panel)
    {
        //找本身
        foreach (var canvas in panel.GetComponents<Canvas>())
        {
            SetWorldCanvas(canvas);
        }

        //找底下子目錄
        foreach (var canvas in panel.GetComponentsInChildren<Canvas>())
        {
            SetWorldCanvas(canvas);
        }
    }

    //在canvas 底下增加 collider
    //順邊加上rigidBody
    public void SetWorldCanvas(Canvas canvas)
    {
        if (canvas.renderMode != RenderMode.WorldSpace )
        {
            return;
        }

        //copy public params then disable existing graphic raycaster
        var defaultRaycaster = canvas.gameObject.GetComponent<GraphicRaycaster>();
        var customRaycaster = canvas.gameObject.GetComponent<VRTK_UIGraphicRaycaster>();
        //if it doesn't already exist, add the custom raycaster
        if (!customRaycaster)
        {
            customRaycaster = canvas.gameObject.AddComponent<VRTK_UIGraphicRaycaster>();
        }

        if (defaultRaycaster && defaultRaycaster.enabled)
        {
            customRaycaster.ignoreReversedGraphics = defaultRaycaster.ignoreReversedGraphics;
            customRaycaster.blockingObjects = defaultRaycaster.blockingObjects;
            defaultRaycaster.enabled = false;
        }

        //add a box collider and background image to ensure the rays always hit
        var canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        if (!canvas.gameObject.GetComponent<BoxCollider>())
        {
            var canvasBoxCollider = canvas.gameObject.AddComponent<BoxCollider>();
            canvasBoxCollider.size = new Vector3(canvasSize.x, canvasSize.y, 10f);
            canvasBoxCollider.center = new Vector3(0f, 0f, 5f);

            //andy840119 順便加上righidBody;
            var rigidbody = canvas.gameObject.AddComponent<Rigidbody>();
            //然後設定rigidBody 不要因為重力或是撞到東西偏移
            rigidbody.useGravity = false;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
             RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        }

        if (!canvas.gameObject.GetComponent<Image>())
        {
            canvas.gameObject.AddComponent<Image>().color = Color.clear;
        }
    }
}
