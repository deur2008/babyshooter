using UnityEngine;
using System.Collections;

//角色速度資訊

public class CharacterSpeed : MonoBehaviour {

    //固定資訊(參數)
    private float _runSpeed;
    private float _slideSpeed;
    private float _flySpeed;
    private float _jumpSpeed;//上升速度

    //設定跑步速度
    //當收到
    public float RunSpeed
    {
        get
        {
            return _runSpeed;
        }
        set
        {
            _runSpeed = value;
        }
    }

    //設定滑行速度
    public float SlideSpeed
    {
        get
        {
            return _slideSpeed;
        }
        set
        {
            _slideSpeed = value;
        }
    }

    //飛行速度
    public float FlySpeed
    {
        get
        {
            return _flySpeed;
        }
        set
        {
            _flySpeed = value;
        }
    }

    //設定跳躍速度
    public float JumpSpeed
    {
        get
        {
            return _jumpSpeed;
        }
        set
        {
            _jumpSpeed = value;
        }
    }
}
