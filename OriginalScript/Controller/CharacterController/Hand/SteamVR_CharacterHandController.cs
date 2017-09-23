using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using VRTK;

//CharacterMoveStaticAdapter ? 

//存取手把上面的按鍵
public class SteamVR_CharacterHandController : MonoBehaviour {
    //設定好目前是哪一隻手
    public enum Hand{left,right};
    public Hand _nowHand;
    public SteamVR_CharacterController.ControlMode _nowControlMode;

    //身體控制器
    public SteamVR_CharacterController _characterController;
    //顯示UI
    public SteamVRUIHandController _UIController;
    //播放聲音
    public SteamVR_HandSoundController _soundController;

    void Start ()
    {
        
    }
    
    void Update ()
    {

    }

    //設定目前控制的模式
    public void SetControlMode(SteamVR_CharacterController.ControlMode mode)
    {
        _nowControlMode = mode;

        if (_nowControlMode == SteamVR_CharacterController.ControlMode.ControlMenu)//控制選單
        {
            SetControlMenuMode(true);
            SetControlGameMode(false);
            //哪種模式底下都可以抓取東西
            SetGrabMode(true);
            //不可以暫停
            SetPauseMode(false);
        }
        else if (_nowControlMode == SteamVR_CharacterController.ControlMode.PauseMode)//暫停模式
        {
            //不能行走，可以控制UI
            SetControlMenuMode(true);
            SetControlGameMode(false);
            //哪種模式底下都可以抓取東西
            SetGrabMode(true);
            //然後可以暫停
            SetPauseMode(true);
        }
        else //遊玩模式
        {
            SetControlMenuMode(false);
            SetControlGameMode(true);
            //哪種模式底下都可以抓取東西
            SetGrabMode(true);
            //可以暫停
            SetPauseMode(true);
        }
    }

    //控制選單
    private void SetControlMenuMode(bool enable)
    {
        this.GetComponent<SteamVRMenuController>().enabled = enable; //對選單本體做操作
        this.GetComponent<VRTK_SimplePointer>().enabled = enable;// 顯示指標
        this.GetComponent<VRTK_UIPointer>().enabled = enable; //對UI指標做處理，才可以指到東西
        
    }

    //暫停
    private void SetPauseMode(bool enable)
    {
        //因為只有右手有暫停，所以要try Catch
        try
        {
            this.GetComponent<SteamVR_PauseGame>().enabled = enable;
        }
        catch
        {

        }
    }

    //控制選單
    //就算是選單模式還是能夠抓取東西
    private void SetControlGameMode(bool enable)
    {
        
        this.GetComponent<VRTK_InteractUse>().enabled = enable;//使用
        if (_nowHand == Hand.left)
        {
            _characterController.GetComponent<VRTK_TouchpadWalking>().LeftController = enable;//左手
        }
        else
        {
            _characterController.GetComponent<VRTK_TouchpadWalking>().RightController = enable;//右手
        }
    }

    //設定能不能抓取東西
    private void SetGrabMode(bool enable)
    {
        this.GetComponent<VRTK_InteractGrab>().enabled = enable;//抓取
        this.GetComponent<VRTK_InteractTouch>().enabled = enable;//碰觸東西
    }

}
