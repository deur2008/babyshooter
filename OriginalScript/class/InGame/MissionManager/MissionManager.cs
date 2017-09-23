using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//用來管理一整套任務
//是base class
public class MissionManager : MonoBehaviour {

    //任務的GameObject，單一任務的腳本都會綁在 GameObject 的根目錄下面
    public List<GameObject> _missoin;

    //目前要執行的mission
    public GameObject _nowTargetMission;

	// 喵
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //通知完成一個任務

    //通知完成所有任務

    //時間到了不算是這邊處理
}
