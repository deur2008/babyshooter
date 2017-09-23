using UnityEngine;
using System.Collections;

//綁定一個image的GameObject，讓他可以從一個'方向到另外一個方向

public class FlowUI : MonoBehaviour {
    public bool _flow=true;
    //開始位置
    public float _startPosition;
    //結束位置
    public float _stopPosition;
    //速度，每秒單位
    public float _speed;
    //到終點後，間隔幾秒回到起點
    public float _waitSecond;

    //是不是由左到右
    public bool _leftToRight;
    //在停止後等待的時間
    float _onStopWaitSecond;

    // Use this for initialization
    void Start () {
        //表示 _startPosition 在右邊，_stopPosition 在左邊
	}
	
	// Update is called once per frame
	void Update () {
        if (_flow)
        {
            //判斷目前方向
            _leftToRight = LeftToRight();
            //表示目前在停止位置
            if (IsAtStopPosition())
            {
                _onStopWaitSecond = _onStopWaitSecond + Time.deltaTime;
                if (_onStopWaitSecond > _waitSecond)
                {
                    _onStopWaitSecond = 0;
                    this.transform.localPosition = new Vector3(_startPosition, this.transform.localPosition.y, this.transform.localPosition.z);
                }
            }
            else
            {
                //會因為比例尺(scale)跑掉=A=
                if (_leftToRight)
                {
                    //表示目前在移動中
                    this.transform.Translate(_speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    //由右到左
                    this.transform.Translate(-_speed * Time.deltaTime, 0, 0);
                }
            }
        }
    }

    //判斷是不是由左到右
    bool LeftToRight()
    {
        if (_startPosition - _stopPosition > 0)
        {
            return false;
        }
        return true;
    }

    //判斷目前是不是在終點
    bool IsAtStopPosition()
    {
        if (_leftToRight)
        {
            //表示由左到右
            if (this.transform.localPosition.x > _stopPosition)
            {
                return true;
            }
        }
        else
        {
            //表示由右到左
            if (this.transform.localPosition.x < _stopPosition)
            {
                return true;
            }
        }
        return false;
    }
}
