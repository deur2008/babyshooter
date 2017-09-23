using UnityEngine;
using System.Collections;

//一個手把的Base資訊
public class JoystickItem : MonoBehaviour {
    //一個搖桿裡面有一個蘑菇頭(2 anix)
    //兩個發射鍵(R1 R2)
    //跟一個暫停

    private int _anix_X = 0;
    private int _anix_Y = 0;
    private bool _anix_Button=false;

    private int _shooterButton1 = 0;
    private int _shooterButton2 = 0;

    private bool _startButton=false;

    //((如果有必要的話
    //然後提供Event可以註冊，用來提醒那些事件發生了

    //moveAnix_X

    //moveAnix_Y

    //PresssAnixButton

    //PressshooterButton1

    //PressshooterButton2


}
