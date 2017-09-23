using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//對於搖桿做提醒，可以對於不同的操作做提醒
public class JoystickHint : MonoBehaviour {

    //設定手部，左手，單手，雙手
    public enum Hand {left,right,both};
    //可以控制對象
    public Hand _controlHand = Hand.both;
    //顯示教學對象
    //如果是both 就會顯示在持有的手上
    public Hand _showHintHand = Hand.both;

    //要顯示的教學
    //如果是空的就不用顯示出來
    public string System = "";
    public string ApplicationMenu = "";
    public string Grip = "";
    public string Touchpad = "";
    public string Trigger = "";

    //總是顯示
    //如果是false就變成只有在按壓時才顯示
    public bool _alwaysShow = true;

    //要分成幾辦
    //例如分成兩半
    public int TouchPadDivision = 2;
    //每一半上面分別要顯示的東西
    public List<GameObject> ListTouchPadShowGameObject;
    //每一半上面分別要顯示的提示
    public List<string> ListTouchPadHint;

}
