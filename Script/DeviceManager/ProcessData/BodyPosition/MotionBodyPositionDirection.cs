using UnityEngine;
using System.Collections;

//抓取 BodyMotion資料
//判定身體前後左右跟左右傾斜

public class MotionBodyPositionDirection : MonoBehaviour {

    //從這邊去讀取 BaseBodyPositionDetector
    //public BaseBodyPositionDetector _adapter;


    //儲存 身體資訊
    private CharacterMoveItem _bodyInfo;

    // Use this for initialization
    void Start () {
	
	}
	
	//撈資料
    //然後判斷移動方位
	void Update () {
	
	}

    //通知往前

    //通知往後

    //通知往左

    //通知往右

    //通知左轉

    //通知右轉

    //通知跳(目前用不到)

    //主要是回傳相對正中心的位置

    //取得目前身體控制
    public CharacterMoveItem GetCharacterMoveItem()
    {
        return _bodyInfo;
    }
}
