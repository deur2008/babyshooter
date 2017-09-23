using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//這裡管理各個場景用的代號
public class SceneIndex : MonoBehaviour {

    public static int BeforeStartMenuLogo = 0;//開始之前
    public static int StartMenu = 1;//開始選單
    public static int Setting = 2;//設定
    public static int LightSystem = 3;//設定燈光
    public static int AdjustVR = 4;//設定VR
    public static int BeforeGameTutorial = 5;//新開始遊戲前，要跑教學
    public static int MainMenu = 6;//主選單
    public static int Stage000 = 7;//Stage000
    public static int Stage001 = 8;//Stage001 SeveralShoot
    public static int Stage002 = 9;//Stage002 ZonBee
    public static int Stage003 = 10;//Stage003
    public static int Stage004 = 11;//Stage004 //直接修改成Tower Protect
    public static int Stage005 = 12;//Stage005 Castel
    public static int Stage006 = 13;//Stage006 FutuerCity
    public static int Stage007 = 14;//Stage007 
    public static int Stage008 = 15;//Stage008 Village

    //列舉
    //列舉目前項目
    public enum SceneTypes
    {
        BeforeStartMenuLogo,//0
        StartMenu,
        Setting,
        LightSystem,
        AdjustVR,//4
        BeforeGameTutorial,//5
        MainMenu,
        Stage000,
        Stage001,
        Stage002,//9
        Stage003,
        Stage004,
        Stage005,//12
        Stage006,
        Stage007,
        Stage008
    }

    //取得列舉結果
    public static int GetEnumItemTypesResult(SceneTypes itemType)
    {
        switch (itemType)
        {
            case SceneTypes.BeforeStartMenuLogo:
                return 0;

            case SceneTypes.StartMenu:
                return 1;

            case SceneTypes.Setting:
                return 2;

            case SceneTypes.LightSystem:
                return 3;

            case SceneTypes.AdjustVR:
                return 4;

            case SceneTypes.BeforeGameTutorial:
                return 5;

            case SceneTypes.MainMenu:
                return 6;

            case SceneTypes.Stage000:
                return 7;

            case SceneTypes.Stage001:
                return 8;

            case SceneTypes.Stage002:
                return 9;

            case SceneTypes.Stage003:
                return 10;

            case SceneTypes.Stage004:
                return 11;

            case SceneTypes.Stage005:
                return 12;

            case SceneTypes.Stage006:
                return 13;

            case SceneTypes.Stage007:
                return 14;

            case SceneTypes.Stage008:
                return 15;

        }
        return -1;
    }

    //取得list
    //或許用不到
    public static List<string> GetAllIndex()
    {
        List<string> returnList = new List<string>();
        returnList.Add(BeforeStartMenuLogo.GetType().ToString());//0
        returnList.Add(StartMenu.GetType().ToString());//1
        returnList.Add(Setting.GetType().ToString());//2
        returnList.Add(LightSystem.GetType().ToString());//3
        returnList.Add(AdjustVR.GetType().ToString());
        returnList.Add(BeforeGameTutorial.GetType().ToString());
        returnList.Add(MainMenu.GetType().ToString());
        returnList.Add(Stage000.GetType().ToString());
        returnList.Add(Stage001.GetType().ToString());
        returnList.Add(Stage002.GetType().ToString());
        returnList.Add(Stage003.GetType().ToString());
        returnList.Add(Stage004.GetType().ToString());
        returnList.Add(Stage005.GetType().ToString());
        returnList.Add(Stage006.GetType().ToString());
        returnList.Add(Stage007.GetType().ToString());
        returnList.Add(Stage008.GetType().ToString());
        return returnList;
    }

   
}
