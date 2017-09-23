using UnityEngine;
using System.Collections;

//單手
//手在中間，表示要控制腳色移動
//手在外面，腳色要切換武器或是射擊
//雙手在外面伸直，然後內灣90度，表示瞄準
//手在下面，按下板機表示跳躍
//手在上面，按下板機表示要往下降

public class CharacterControlHandType : MonoBehaviour {

    //手是否在中間
    private bool _handIsInMiddle;
    //手的位置是否為射擊模式，表示手有沒有伸直
    private bool _handIsInAttackMode;
    //表示手部為抵擋模式
    private bool _handIsInDefenseMode;
    //手有沒有灣90度，表示瞄準模式
    private bool _handIsRotate90Degree;

    private void SetAllState(bool isTrue)
    {
        _handIsInMiddle = isTrue;
        _handIsInAttackMode = isTrue;
        _handIsInDefenseMode = isTrue;
        _handIsRotate90Degree = isTrue;
    }

    private void SetPartialState(bool isTrue)
    {
        _handIsInMiddle = isTrue;
        //_handIsInAttackMode = isTrue;
        _handIsInDefenseMode = isTrue;
        //_handIsRotate90Degree = isTrue;
    }

    //================public class==============

    //手在中間
    public bool HandIsInMiddle
    {
        get
        {
            return _handIsInMiddle;
        }
        set
        {
            if (value == true)
            {
                _handIsInAttackMode = false;
                _handIsInDefenseMode = false;
            }
            _handIsInMiddle = value;
        }
    }

    //手在外面
    public bool HandIsInAttackMode
    {
        get
        {
            return _handIsInAttackMode;
        }
        set
        {
            SetPartialState(false);
            _handIsInAttackMode = value;
        }
    }

    //守在防禦模式
    public bool HandIsInDefenseMode
    {
        get
        {
            return _handIsInDefenseMode;
        }
        set
        {
            SetAllState(false);
            _handIsInDefenseMode = value;
        }
    }

    //手手有沒有轉到90度
    public bool HandIsRotate90Degree
    {
        get
        {
            return _handIsRotate90Degree;
        }
        set
        {
            SetPartialState(false);
            _handIsRotate90Degree = value;
        }
    }

    //有瞄準
    //表示AttackMode
    //還有 _handIsRotate90Degree
    public bool HandIsInAimMode
    {
        get
        {
            if (HandIsInAttackMode)
                if (HandIsRotate90Degree)
                    return true;
            return false;
        }
        set
        {
            SetPartialState(false);
            HandIsInAttackMode = value;
            HandIsRotate90Degree = value;
        }
    }

   
}
