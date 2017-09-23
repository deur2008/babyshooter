using UnityEngine;
using System.Collections;
using VRTK;

//可以使用指標，或是按下鍵盤可以控制目前瞄準的選單
public class SteamVRMenuController : MonoBehaviour {

    public bool togglePointerOnHit = false;
    public GameObject _nowSelectedObject;
    public JoystickHint _UIModeHint;


    //開始
    private void Start()
    {
        if (GetComponent<VRTK_UIPointer>() == null)
        {
            Debug.LogError("VRTK_ControllerUIPointerEvents_ListenerExample is required to be attached to a SteamVR Controller that has the VRTK_UIPointer script attached to it");
            return;
        }

        if (togglePointerOnHit)
        {
            GetComponent<VRTK_UIPointer>().activationMode = VRTK_UIPointer.ActivationMethods.Always_On;
        }

        //註冊碰到和放開的監聽
        GetComponent<VRTK_UIPointer>().UIPointerElementEnter += VRTK_ControllerUIPointerEvents_ListenerExample_UIPointerElementEnter;
        GetComponent<VRTK_UIPointer>().UIPointerElementExit += VRTK_ControllerUIPointerEvents_ListenerExample_UIPointerElementExit;
        //註冊案下板機和放開的監聽
        GetComponent<VRTK_ControllerEvents>().AliasGrabOn += new ControllerInteractionEventHandler(DoGrabObject);
        GetComponent<VRTK_ControllerEvents>().AliasGrabOff += new ControllerInteractionEventHandler(DoReleaseObject);
    }

    //顯示UI
    void OnEnable()
    {
        GetComponent<SteamVR_CharacterHandController>()._UIController.SetToolTip(_UIModeHint);
    }

    //指標碰到 Z
    //跟板機沒有關係
    private void VRTK_ControllerUIPointerEvents_ListenerExample_UIPointerElementEnter(object sender, UIPointerEventArgs e)
    {
        _nowSelectedObject = e.currentTarget;
        //會顯示物件名稱
        Debug.Log("UI Pointer entered " + e.currentTarget.name + " on Controller index [" + e.controllerIndex + "]");

        //如果裡面有Joystick Hint ，就叫出來顯示
        if (_nowSelectedObject.GetComponent<JoystickHint>() != null)
        {
            GetComponent<SteamVR_CharacterHandController>()._UIController.SetToolTip(_nowSelectedObject.GetComponent<JoystickHint>());
        }

        //如果裡面有音效也會撥放出來
        if (_nowSelectedObject.GetComponent<AudioParameter>() != null)
        {
            GetComponent<SteamVR_CharacterHandController>()._soundController.PlaySoundEffect(_nowSelectedObject.GetComponent<AudioParameter>());
        }
       
    }

    //指標離開
    private void VRTK_ControllerUIPointerEvents_ListenerExample_UIPointerElementExit(object sender, UIPointerEventArgs e)
    {
        //把物件清掉
        _nowSelectedObject = null;
        Debug.Log("UI Pointer exited " + e.previousTarget.name + " on Controller index [" + e.controllerIndex + "]");

        //顯示回來
        GetComponent<SteamVR_CharacterHandController>()._UIController.SetToolTip(_UIModeHint);
    }

    //如果握住手上的按鈕
    private void DoGrabObject(object sender, ControllerInteractionEventArgs e)
    {

        //表示選擇此物件
    }

    //放開握的按鈕
    private void DoReleaseObject(object sender, ControllerInteractionEventArgs e)
    {
        //就放開吧
    }

    //ControllerTarget
}
