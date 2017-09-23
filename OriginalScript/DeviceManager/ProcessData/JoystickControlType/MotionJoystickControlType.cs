using UnityEngine;
using System.Collections;

//用來偵測手部(或是身體)動作，用來判定手上的搖桿應該是哪一種模式

//目前搭配搖桿模式有

//單手
//手在中間，表示要控制腳色移動
//手在外面，腳色要切換武器或是射擊
//雙手在外面伸直，然後內灣90度，表示瞄準
//手在下面，按下板機表示跳躍
//手在上面，按下板機表示要往下降
//如果手是面對中心點，表示手伸直，按下上加板機為噴射移動
//如果不是就代表是在抵擋

//雙手
//雙手在中間，表示要快速移動，或是要轉彎
//雙手重疊，表示換成重型武器
//雙手在外面伸直，然後內灣90度，表示要重型武器2

public class MotionJoystickControlType : MonoBehaviour {

    //載入 BaseBodyPositionDetector
    //public BaseBodyPositionDetector _body;
    //然後腳色控制種類(Item)
    public CharacterControlType _type;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //從這邊去判段 收到的  BodyPositionDetector 裡面的資料
    private void JudgeMotion()
    {

    }
   
}
