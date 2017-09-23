using UnityEngine;
using System.Collections;
using System;

//所有顯示UI的都要繼承
public class BasePanelStateMachineBehaviour : BaseStateMachineBehaviour
{
    //prefab物件
    public GameObject _roomUIObject;
    //prefab物件
    public GameObject _roomSmallUIObject;
    //prefab物件
    public GameObject _headUIObject;
    //prefab物件
    public GameObject _leftHandUIObject;
    //prefab物件
    public GameObject _rightHandUIObject;

    //目前物件
    protected GameObject _roomUIOnSceneObject;
    //目前物件
    protected GameObject _roomSmallUISceneObject;
    //目前物件
    protected GameObject _headUISceneObject;
    //目前物件
    protected GameObject _leftHandUISceneObject;
    //目前物件
    protected GameObject _rightHandUISceneObject;

    //誤記上的腳本，做控制和取得狀態用
    protected PanelUI _ui;

    protected Animator _animator;

    //在進入狀態
    //把StartMenuLoad近來
    //把控制權附上去
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialize(animator);
        //把 PanelUI 榜上去
        BindPanel();
        //把操作權限設定到目前的 PanelUI 上豔
        UpdateUIToRoomUI();
        //(預設)給予控制權
        SetRoomUIAsTarget();
    }

    //Loop
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //離開
    //加上黑色背景
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //全部unbind
        UnbindAll();
       
    }

    public void Initialize(Animator animator)
    {
        _animator = animator;
    }

    //把所有UI都榜上去
    public void BindPanel()
    {
        try
        {
            //綁定物件到場警上面
            BindPanelUI(ref _roomUIOnSceneObject, _roomUIObject);
            BindPanelUI(ref _roomSmallUISceneObject, _roomSmallUIObject);
            BindPanelUI(ref _headUISceneObject, _headUIObject);
            BindPanelUI(ref _leftHandUISceneObject, _leftHandUIObject);
            BindPanelUI(ref _rightHandUISceneObject, _rightHandUIObject);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
  
    //單獨綁上一個UI
    public void BindPanelUI(ref GameObject bindObject, GameObject SourceObject)
    {
        if (SourceObject != null)//如果Source有東西
        {
            if (bindObject == null)//表示要建構
            {
                //把物件綁到仔物件底下
                BindPanelToManagerGameObject(ref bindObject, SourceObject);
            }
            else
            {
                bindObject.SetActive(true);
            }
        }
    }


    //把GameObject物件綁到 目前的 Manager 物件底下
    public void BindPanelToManagerGameObject(ref GameObject bindObject, GameObject SourceObject)
    {
        //如果panel不是null，舊只要把disable 變回enable
        if (bindObject != null)
        {
            bindObject.SetActive(true);
        }
        else
        {
            //取得物件
            bindObject = (GameObject)Instantiate(SourceObject);
            Debug.Log("Add");
            
            //_object.transform.position = Vector3.zero;
            //把位置設定到0
        }
    }

    //把所有物件都Unbind掉
    public void UnbindAll()
    {
        UnBindPanelUI(ref _roomUIOnSceneObject);
        UnBindPanelUI(ref _roomSmallUISceneObject);
        UnBindPanelUI(ref _headUISceneObject);
        UnBindPanelUI(ref _leftHandUISceneObject);
        UnBindPanelUI(ref _rightHandUISceneObject);
    }

    //把所有物件的控制權拿掉
    public void UnbindAllControl()
    {
        CancelControl(ref _roomUIOnSceneObject);
        CancelControl(ref _roomSmallUISceneObject);
        CancelControl(ref _headUISceneObject);
        CancelControl(ref _leftHandUISceneObject);
        CancelControl(ref _rightHandUISceneObject);
    }


    //取消繫節panel
    protected virtual void UnBindPanelUI(ref GameObject gameobject)
    {
        try
        {
            //掩藏
            gameobject.SetActive(false);
            //取消監聽
            CancelControl(ref gameobject);
        }
        catch
        {

        }
    }

    //設定控制
    public void SetControl(ref GameObject bindObject)
    {
        try
        {
            _ui = bindObject.GetComponent<PanelUI>();
            //內部改變的監聽
            _ui._modelChanged += new PanelUI.ModelChangedEventHandler(OnMenuNotifiedChange);
            //選擇選單監聽
            _ui._modelPressSelect += new PanelUI.ModelPressSelect(OnMenuNotifiedSelect);
            //退出選ㄉ監聽
            _ui._modelPressCancel += new PanelUI.ModelPressCancel(OnMenuNotifiedCancel);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    //取消控制
    public void CancelControl(ref GameObject bindObject)
    {
        try
        {
            _ui = bindObject.GetComponent<PanelUI>();
            //內部改變的監聽取消
            _ui._modelChanged -= new PanelUI.ModelChangedEventHandler(OnMenuNotifiedChange);
            //選擇選單監聽取消
            _ui._modelPressSelect -= new PanelUI.ModelPressSelect(OnMenuNotifiedSelect);
            //退出選ㄉ監聽取消
            _ui._modelPressCancel -= new PanelUI.ModelPressCancel(OnMenuNotifiedCancel);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    //把目前要顯示的Panel 顯示到Room UI上面
    protected virtual void UpdateUIToRoomUI()
    {
        UpdateSingleUI(ref _roomUIOnSceneObject);
        UpdateSingleUI(ref _roomSmallUISceneObject);
        UpdateSingleUI(ref _headUISceneObject);
        UpdateSingleUI(ref _leftHandUISceneObject);
        UpdateSingleUI(ref _rightHandUISceneObject);
    }

    //更新單一UI
    void UpdateSingleUI(ref GameObject gameObject)
    {
        if (gameObject != null)
        {
            if (PanelControllerStaticAdapter.GetRoomUI() != null)
                gameObject.transform.parent = PanelControllerStaticAdapter.GetRoomUI().transform;
                //_object.transform.parent = FindStateMachineManager(animator)._dialogUIDisplayArea.transform;
                gameObject.transform.localPosition = Vector3.zero;
        }
    }

    //設定控制權
    protected void SetRoomUIAsTarget()
    {
        Debug.Log(_roomUIOnSceneObject.name);
        UnbindAllControl();
        SetControl(ref _roomUIOnSceneObject);
        PanelControllerStaticAdapter.SetCurrentControlTarget(_roomUIOnSceneObject);
    }

    //設定控制權
    protected void SetRoomSmallUIAsTarget()
    {
        Debug.Log(_roomSmallUISceneObject.name);
        UnbindAllControl();
        SetControl(ref _roomSmallUISceneObject);
        PanelControllerStaticAdapter.SetCurrentControlTarget(_roomSmallUISceneObject);
    }

    //設定控制權
    protected void SetHeadUIAsTarget()
    {
        Debug.Log(_headUISceneObject.name);
        UnbindAllControl();
        SetControl(ref _headUISceneObject);
        PanelControllerStaticAdapter.SetCurrentControlTarget(_headUISceneObject);
    }

    //設定控制權
    protected void SetLeftUIAsTarget()
    {
        Debug.Log(_leftHandUISceneObject.name);
        UnbindAllControl();
        SetControl(ref _leftHandUISceneObject);
        PanelControllerStaticAdapter.SetCurrentControlTarget(_leftHandUISceneObject);
    }

    //設定控制權
    protected void SetRightHandUIAsTarget()
    {
        Debug.Log(_rightHandUISceneObject.name);
        UnbindAllControl();
        SetControl(ref _rightHandUISceneObject);
        PanelControllerStaticAdapter.SetCurrentControlTarget(_rightHandUISceneObject);
    }

    //如果被通知選擇了
    protected virtual void OnMenuNotifiedSelect()
    {

    }

    //如果被通知取消了
    protected virtual void OnMenuNotifiedCancel()
    {

    }

    //通知內容改變
    protected virtual void OnMenuNotifiedChange()
    {

    }

    //用panelUI來把值設定到Panel上面
    public void CreatePanelByRecordItem(PanelUI UI, RecordItem item)
    {

    }

}
