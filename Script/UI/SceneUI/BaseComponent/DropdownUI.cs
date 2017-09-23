using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//下拉式選單
//文字部分也是使用 TextUI，目前是看能不能用，據說有點麻煩


public class DropdownUI : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //清理所有選項
    public bool CleanAllOption()
    {
        return false;
    }

    //增加一個選項
    public bool AddAnOption(string str)
    {
        return false;
    }

    //載入選項List
    public bool LoadAllOption(IList stringList)
    {
        return false;
    }

    //如果沒有選擇，就回傳-1
    public int GetSelectedIndex()
    {
        return -1;
    }

    //目前滑鼠所在的選項
    public int GetOnSelectIndex()
    {
        return -1;
    }

    //通知選項改變


    //通知目前選擇(滑鼠位置)


}
