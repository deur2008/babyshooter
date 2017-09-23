using UnityEngine;
using System.Collections;

//人物控制
//主要是檢MMotion 跟搖桿的數據，
//然後再去設定人物該移動的速度，方向和攻擊模式
//不直接附著在人物身上
//在遊戲場內才會使用

public class UserCharacterController : SteamVR_CharacterController {
    //參數設定
    //取得BaseBodyPositionDirection，身體位置
    public MotionBodyPositionDirection _bodyMotion;

    //取得JoystickController，搖桿資訊，或許還有手部位置?
    public JoystickController _controller;

    //KinectShootDirection，射擊位置
    //public ShootDirection _shootDirection;

    //手部位置
    public MotionJoystickControlType _type;

    //取得要控制的腳色，從裡面取得參數
    public CharacterGroup _group;

    //指定要控制的腳色，ID跟list位置有關
    public int _controlCharacterID;

    //確定要不要執行，如果物件有一個是null就不要執行
    private bool _execute;

    //確認初始化
    private bool CheckInitialize()
    {
        return false;
    }

    //初始化
    void Start () {
        _execute = CheckInitialize();
    }
	
    //根據
	//控制
	void Update () {
        if (_execute)
        {

        }
	}
}
