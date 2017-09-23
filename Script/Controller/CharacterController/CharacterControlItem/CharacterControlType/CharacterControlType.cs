using UnityEngine;
using System.Collections;

//腳色控制的方法
//會搭配在 MotionJoystickControlType 跟 CharacterState 上面
//主要是用來紀錄手部動作

//雙手
//雙手在中間，表示要快速移動，或是要轉彎
//雙手重疊，表示換成重型武器
//雙手在外面伸直，然後內灣90度，表示要重型武器2

public class CharacterControlType {

    //左手資訊
    private CharacterControlHandType _leftHandType;
    //右手資訊
    private CharacterControlHandType _rightHandType;
    //雙手是否重疊
    private bool _handIsCross;
    //是否為第二種攻擊模式
    private bool _isAllHandRotate90Degree;

   

    //============public=================

    //表示快速移動
    public bool FastMoveMode
    {
        get
        {
            if (_leftHandType.HandIsInMiddle)
                if (_rightHandType.HandIsInMiddle)
                    return true;
            return false;
        }
        set
        {
            //設定左右手都是在腰部
            _leftHandType.HandIsInMiddle = true;
            _rightHandType.HandIsInMiddle = true;
        }
    }

    //表示雙手重疊，表示換成重型武器
    public bool HandIsCross
    {
        get
        {
            return _handIsCross;
        }
        set
        {
            _handIsCross = value;
        }
    }

    //設定是否為攻擊模式
    //要兩隻手都在中間，而且角度一樣
    public bool IsAllHandRotate90Degree
    {
        get
        {
            return _isAllHandRotate90Degree;
        }
        set
        {
            _isAllHandRotate90Degree = value;
        }
    }
}
