using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//這是一筆紀錄
//可以把他直接變成實體檔案做儲存
[SerializeField]
public class SceneRecordManager : MonoBehaviour {
    //完成基本教學
    public static bool FinishBasicTutorial=false;

    //目前記錄索引
    public static int nowRecordIndex;

    //目前金不
    public static int NowEN;

    //遊玩時間
    public static DateTime NowPlayTime;

    //TimeTotalPlayTime
    public static DateTime TotalPlayTime;

    //地圖解鎖
    public static List<BasicUnlockRecord> MapUnlock;

    //腳色解鎖
    public static List<BasicUnlockRecord> CharacterUnlock;

    //武器解鎖
    public static List<BasicUnlockRecord> WeaponUnlock;

    //腳色升級清單? //也可能跟 腳色解鎖 合併?
    public List<CharacterRecord> CharacterRecordList;

    //朋友列表 之後應該會改成 FrinedListItem
    public static List<string> friendList;

    //劇情解鎖進度
    public static List<BasicUnlockRecord> StoryUnlock;

    //設定
    public static SystemRecord SystemRecord;

}
