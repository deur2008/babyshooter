using UnityEngine;
using System.Collections;

//把資料透過序列化的方式保存
public class SerializeDataManager : MonoBehaviour {

    static string Path = "/userFile";

    //取得紀錄
    //因為 SceneRecordManager static ，所以只會回傳是否取得成功
    public static bool GetRecord(int index)
    {
        return false;
    }

    //保存紀錄，回傳是保存存成功
    public static bool SaveRecord()
    {
        return false;
    }

}
