using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//用來儲存角色位置
public class CharacterPrefabManager : MonoBehaviour {

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
                info.MapName = "城市";
                info.Map = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 2:
                info.MapName = "城市02";
                info.Map = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 3:
                info.MapName = "城市03";
                info.Map = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 4:
                info.MapName = "城市04";
                info.Map = (GameObject)Resources.Load(_mapPath + "map001");
                break;
            case 5:
                info.MapName = "城市05";
                info.Map = (GameObject)Resources.Load(_mapPath + "map001");
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
        public string MapName;
        public GameObject Map;
    }

}
