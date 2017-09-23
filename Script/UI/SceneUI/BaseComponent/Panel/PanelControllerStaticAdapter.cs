using UnityEngine;
using System.Collections;
using System;

//靜態變數，用來指定操作的panel時可以使用，之後可以修改成也可以控制Character?
//
public class PanelControllerStaticAdapter : MonoBehaviour {

    //要控制的PanelUI
    public static GameObject _roomUI;

    //room前方底下比較小的UI
    public static GameObject _roomSmallUI;

    //頭部顯示的UI
    public static GameObject _headUI;

    //左手手把UI
    public static GameObject _rightHandUI;

    //左手手把UI
    public static GameObject _leftHandUI;

    //設定
    public static void SetRoomUI(GameObject ui)
    {
        _roomUI = ui;
    }

    //取得
    public static GameObject GetRoomUI()
    {
        return _roomUI;
    }

    //設定
    public static void SetRoomSmallUI(GameObject ui)
    {
        _roomSmallUI = ui;
    }

    //取得
    public static GameObject GetRoomSmallUI()
    {
        return _roomSmallUI;
    }

    //設定
    public static void SetHeadUI(GameObject ui)
    {
        _headUI = ui;
    }

    //取得
    public static GameObject GetHeadUI()
    {
        return _headUI;
    }

    //設定
    public static void SetRightHandUI(GameObject ui)
    {
        _rightHandUI = ui;
    }

    //取得
    public static GameObject GetRightHandUI()
    {
        return _rightHandUI;
    }

    //設定
    public static void SetLeftHandUI(GameObject ui)
    {
        _leftHandUI = ui;
    }

    //取得
    public static GameObject GetLeftHandUI()
    {
        return _leftHandUI;
    }

    //設定目前的控制對象
    static GameObject controlTarget;

    //把要控制的Panel設定上去
    public static void SetCurrentControlTarget(GameObject target)
    {
        controlTarget = target;
    }

    //當正在操作這個選單時網上按
    public static void PressUp()
    {
        try
        {
            //如果是要控制child
            controlTarget.GetComponent<PanelUI>().PressUp();
        }
        catch(Exception ex)
        {
            Debug.Log("Error : " + ex.Message);
        }
    }

    //當正在操作這個選單時網上按
    public static void PressDown()
    {
        try
        {
            //如果是要控制child
            controlTarget.GetComponent<PanelUI>().PressDown();
        }
        catch
        {

        }
    }

    //當正在操作這個選單時網上按
    public static void PressLeft()
    {
        try
        {
            //如果是要控制child
            controlTarget.GetComponent<PanelUI>().PressLeft();
        }
        catch
        {

        }
    }

    //當正在操作這個選單時網上按
    public static void PressRight()
    {
        try
        {
            //如果是要控制child
            controlTarget.GetComponent<PanelUI>().PressRight();
        }
        catch
        {

        }
    }

    //如果在當下選單按選擇
    public static void PressSelect()
    {
        try
        {
            //如果是要控制child
            controlTarget.GetComponent<PanelUI>().PressTrigger();
        }
        catch
        {

        }
    }

    //如果離開選單
    public static void PressCancel()
    {
        try
        {
            //如果是要控制child
            controlTarget.GetComponent<PanelUI>().PressApplicationMenu();
        }
        catch
        {

        }
    }


}
