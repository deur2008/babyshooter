using UnityEngine;
using System.Collections;

//顯示敵人相關資料
public class ShowEnemyBar : MonoBehaviour {
    //敵人寫條
    public GameObject _enemyBar;
    //玩家
    public GameObject _target;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //要把血量資訊面向玩家
        this.transform.LookAt(_target.transform);
	}

    //=========================public=====================
    //設定目前
    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    //設定HP
    public void SetHP(float max,float now)
    {

    }
}
