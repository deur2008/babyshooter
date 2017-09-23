using UnityEngine;
using System.Collections;

//一筆紀錄格式
public class RecordItem : MonoBehaviour {
    //索引
    string _index;
    //對應的值
    string _value;

    //紀錄的Tag
    public string Index
    {
        get
        {
            return _index;
        }
        set
        {
            _index = value;
        }
    }

    //紀錄裡面的內容
    public string Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }
}
