using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//階段任務裡面的一個步驟
//是base class
public class SingleMissionStep : MonoBehaviour {

    //要顯示的說明
    //如果info是0就代表不用顯示了w
    public List<string> _info;

    //思考一下如顯示 _info 裡面的資訊

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //通知是不是完成


    //顯示類別
    public string GetType()
    {
        return this.name;
    }

    //目前類別，作對比用?
    public virtual string Type()
    {
        return this.name;
    }
}
