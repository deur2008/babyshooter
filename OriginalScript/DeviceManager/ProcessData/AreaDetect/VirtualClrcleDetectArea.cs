using UnityEngine;
using System.Collections;

//假裝某一點圓心有顆球，例如身體中心
//有球形環狀選單使用

public class VirtualClrcleDetectArea : MonoBehaviour {

    //載入手部位置
    //public BaseBodyPositionDetector _handPosition;

    //設定一個區域(kinect感應手部區域)
    //一個元的半徑
    public float _radius;

    //一個座標(預設是Kinecy 機器中心點)
    public Vector3 _canterPosition;//這個是相對Kinect位置

    //設定中界點(分開感應區(表示守在那格位置，會顯示游標)跟 觸控區 (表示手已經觸控到了))


    //感應區厚度
    public float _detectAreaHeight;

    //觸控區厚度
    public float _selectAreaHeight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    ////讀取左手座標 _handPosition 撈到的座標
    //public MotionAimInfoItem GetLeftHandValue()
    //{
    //    return _handPosition.GetLeftHandValue();
    //}

    //左手手部是否在感應區內
    public bool IsLeftHandInDetectArea()
    {
        return false;
    }

    //左手手部是否在觸碰區內
    public bool IsLeftHandInSSelectArea()
    {
        return false;
    }

    ////讀取右手座標
    //public MotionAimInfoItem GetRightHandValue()
    //{
    //    return _handPosition.GetRightHandValue();
    //}

    //右手手部是否在感應區內
    public bool IsRightHandInDetectArea()
    {
        return false;
    }

    //右手手部是否在觸碰區內
    public bool IsRightHandInSSelectArea()
    {
        return false;
    }
}
