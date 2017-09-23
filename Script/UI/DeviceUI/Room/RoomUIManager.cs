using UnityEngine;
using System.Collections;

//管理整個UI的Manager
public class RoomUIManager : MonoBehaviour {
    
    //room前方UI
    public  GameObject _roomUI;
    //room前方底下比較小的UI
    public  GameObject _roomSmallUI;
    //頭部顯示的UI
    public  GameObject _headUI;
   

    //右手手把按鈕UI
     GameObject _rightHandButtonUI;
    //左手手把UI
     GameObject _rightHandUI;

    //左手手把按鈕UI
     GameObject _leftHandButtonUI;

    //初始
    void Start()
    {
        //取得
        GetHandObject();
        //設定到static上面
        SetAllUIToRoomUIStsticAdapter();
    }

    //取得手部的UI
    void GetHandObject()
    {
        /*
        _leftHandButtonUI = this.GetComponent<SteamVR_ControllerManager>().left.GetComponent<SteamVRUIHandController>()._handJoystickButtonUI;
        _leftHandUI = this.GetComponent<SteamVR_ControllerManager>().left.GetComponent<SteamVRUIHandController>()._handJoystickUI;
        _rightHandButtonUI = this.GetComponent<SteamVR_ControllerManager>().right.GetComponent<SteamVRUIHandController>()._handJoystickButtonUI;
        _rightHandUI = this.GetComponent<SteamVR_ControllerManager>().right.GetComponent<SteamVRUIHandController>()._handJoystickUI;
        */
    }

    //把目前UI都給 RoomUIStsticAdapter ，方便之後做處理
    void SetAllUIToRoomUIStsticAdapter()
    {
        /*
        PanelControllerStaticAdapter.SetRoomUI(_roomUI);
        PanelControllerStaticAdapter.SetRoomSmallUI(_roomSmallUI);
        PanelControllerStaticAdapter.SetHeadUI(_headUI);
        PanelControllerStaticAdapter.SetRightHandButtonUI(_rightHandButtonUI);
        PanelControllerStaticAdapter.SetRightHandUI(_rightHandUI);
        PanelControllerStaticAdapter.SetLeftHandButtonUI(_leftHandButtonUI);
        PanelControllerStaticAdapter.SetLeftHandUI(_leftHandUI);
        */
    }

}
