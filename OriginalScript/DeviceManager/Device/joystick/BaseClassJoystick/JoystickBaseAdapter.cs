using UnityEngine;
using System.Collections;

//主要是定義Base Adapter
//如果有實體搖桿就要用多行去繼承
//這裡的Adapter主要是連接搖桿
//還有在搖桿按下按鍵的時候回傳資訊(其他Class可以Access近來)
//還有可以提供使用者做事件註冊
//左右搖桿是在同一個Adapter下
public class JoystickBaseAdapter : MonoBehaviour {

    //左手手把
    JoystickItem _leftJoystickItem;
    //右手手把
    JoystickItem _rightJoystickItem;

    //建構
    private void InitializeJoystickItem()
    {
        _leftJoystickItem = new JoystickItem();
        _rightJoystickItem = new JoystickItem();
    }


    // Use this for initialization
    void Start () {
        //建構
        InitializeJoystickItem();

    }
	
	// Update is called once per frame
	void Update () {
	    //讀取資訊

	}

    //取得左手手把資訊

    //取得右手手把資訊

}
