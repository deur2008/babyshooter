using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//存放武器
//實際武器名稱還是存在武器裡面好了
//方便存取
public class WeapomPrefabManager : MonoBehaviour {

    //儲存位置
    public static string _mapPath = "Assets/Prefab/InGame/Map/";

    //人物數量
    public static int GetMapNumber()
    {
        return 5;
    }

    //取得地圖
    public static MapInfo GetMapInfo(int index)
    {
        MapInfo info = new MapInfo();
        switch (index)
        {
            case 1:
                info.WeaponName = "城市";
                info.Weapon = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 2:
                info.WeaponName = "城市02";
                info.Weapon = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 3:
                info.WeaponName = "城市03";
                info.Weapon = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 4:
                info.WeaponName = "城市04";
                info.Weapon = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 5:
                info.WeaponName = "城市05";
                info.Weapon = (GameObject)Resources.Load(_mapPath + "map001");
                break;
        }

        return info;
    }

    //取得所有名稱
    public static List<string> GetAllMapString()
    {
        List<string> list = new List<string>();

        return list;
    }

    //地圖資訊
    public class MapInfo : MonoBehaviour
    {
        //武器名稱
        public string WeaponName;
        //符合角色代號
        public List<int> character;
        public GameObject Weapon;
    }


    //取得所有符合的武器
    public static void GetAllWeapomMatchCharacter(int index)
    {

    }
}
