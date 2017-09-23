using UnityEngine;
using System.Collections;

//儲存手部資訊
public class MotionAimInfoItem : MonoBehaviour {

    //手部(相對於kinect正中心)的位置
    private Vector3 _position;
    //手部(相對於_position)的旋轉X Y Z 角度
    private Vector3 _rotation;
    //是否存在，如果在沒有Detect到，要設定成False
    private bool _vailed;

    //設定座標
    public Vector3 Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
        }
    }
    
    //設定座標後相對的射出方位
    public Vector3 Rotation
    {
        get
        {
            return _rotation;
        }
        set
        {
            _rotation = value;
        }
    }

    //測定參數是否有效
    public bool Vailed
    {
        get
        {
            return _vailed;
        }
        set
        {
            _vailed = value;
        }
    }

}
