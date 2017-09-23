using UnityEngine;
using System.Collections;

//遊戲中射擊判定
//基本上拿 kinectElbowPositionDetector 做判定
//因為之後射擊判定可能會加入其他參數，所以獨立出一個class

public class ShootDirection : MonoBehaviour {

    //載入 BaseBodyPositionDetector
    //public BaseBodyPositionDetector _body;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 //開始讀取資訊
	}

    //通知抓到右手

    //通知右手消失

    //通知抓到左手

    //通知左手消失

    //基本上內容跟 KinectElbowPositionDetector 差不多
    //左手是否存在
    public bool IsLeftHandAvailable()
    {
        return false;
    }

    //抓取左手的值 (KinectAimInfoItem)
    public MotionAimInfoItem GetLeftHandValue()
    {
        //瞄準資訊
        MotionAimInfoItem item = new MotionAimInfoItem();
        return item;
    }

    //右手是否存在
    public bool IsRightHandAvailable()
    {
        return false;
    }

    //抓取右手的值 (KinectAimInfoItem)
    public MotionAimInfoItem GetRightHandValue()
    {
        MotionAimInfoItem item = new MotionAimInfoItem();
        return item;
    }
}
