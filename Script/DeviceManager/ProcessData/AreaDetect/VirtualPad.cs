using UnityEngine;
using System.Collections;

//是用來抓取人物在kinect 上面壓取的位置，感覺就像是身體前面有塊平行的板子，可以針對板子去做操作
//主要用途是 互動性武器招式
//還有遊戲選單
//可以設定感應長，寬，中心相對某個點(可能是)
//還有傾斜角
//然後可以感應到是否碰到pad，是否在前方或是是否搓過pad

public class VirtualPad : MonoBehaviour {

    //載入手部位置
    //public BaseBodyPositionDetector _handPosition;

    //設定一個區域(kinect感應手部區域)

    //設定一個對應區域

    //設定是否讓兩邊長寬同比例

    //設定中界點(分開感應區(表示守在那格位置，會顯示游標)跟 觸控區 (表示手已經觸控到了))

    //感應區厚度

    //觸控區厚度

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //讀取座標

    //手部是否在感應區內

    //手部是否在觸碰區內
}
