using UnityEngine;
using System.Collections;

//在mainMenu中會出現的選項
public class MainMenuManagerString : StateMachineBehaviour
{

    //取得選單編號
    public static string isTurtorial = "isTurtorial";
    public static string isSinglePlay = "isSinglePlay";
    public static string isMultiplePlay = "isMultiplePlay";
    public static string isFriendList = "isFriendList";
    public static string isUnlock = "isUnlock";
    public static string isStoryMode = "isStoryMode";
    public static string isStore = "isStore";
    public static string isSetting = "isSetting";
    public static string isViewProfile = "isViewProfile";
    public static string isBack = "isBack";

    //確定要返回
    public static string BackOK = "BackOK";
}
