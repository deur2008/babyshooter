using UnityEngine;
using System.Collections;

//Vive搖桿的資訊
//主要有上下左右
//還有Dpad
//還有一顆實體按鈕
//一個發射(兩段式)


public class ViveJoystick : MonoBehaviour {
    //左手資訊
    JoystickItem _leftHandJoystickItem;
    //右手資訊 
    JoystickItem _rightHandJoystickItem;
    //配接器
    //或許裡面會包含角度吧，kinect那些class就先不要管它了
    ViveJoystickAdapter _adapter;
    //把頭的配接器一併導入好了
    //ViveHeadPositionDetector _detector;
    //目前手部位置模式
    CharacterControlType _type;

    // Use this for initialization
    void Start () {
	    //初始化
	}
	
	// Update is called once per frame
	void Update () {
        //左手
        _leftHandJoystickItem = ProcessJoystickItem();
        //右手
        _rightHandJoystickItem = ProcessJoystickItem();
    }

    //把Date Loading 近來
    //跟 處裡左右手的資訊
    //可能會一併處理搖桿的角度，位置
    //還有目前位置對應模式
    private JoystickItem ProcessJoystickItem()
    {
        JoystickItem item = new JoystickItem();
        //
        //..................
        //
        return item;
    }

    //取得左手資訊
    public JoystickItem GetLeftHandJoystickInfo()
    {
        return _leftHandJoystickItem;
    }

    //取得右手資訊
    public JoystickItem GetRightHandJoystickInfo()
    {
        return _rightHandJoystickItem;
    }
}
