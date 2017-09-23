using UnityEngine;
using System.Collections;

//自動旋轉
public class AutoSpine : MonoBehaviour {
    //一秒鐘要轉幾度
    public float _angleParSecond;
    //可不可以旋轉
    public bool _canSpin = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //
        if (_canSpin)
        {
            //算出時間差
            float time = Time.deltaTime;
            //然後算出角度
            float angle = time * _angleParSecond;
            //
            this.gameObject.transform.Rotate(new Vector3(0, 0, angle));
        }
	}
}
