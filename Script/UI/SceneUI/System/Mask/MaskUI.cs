using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//主要是讓背景變黑
//因為VR是360度，所以需要一個正方體，然後控制Texture的透明度去改變背景的半透明
//然後可以用靜態去Call?
//然後要附著在Vive的Camera上面

public class MaskUI : MonoBehaviour {
    
    //UI位置
    public GameObject _UIGameObject;
    //設定Vive位置
    public GameObject _viveCaameraPosition;
    //設定Cube
    public List<SpriteRenderer> _maskGameObject; 
    //從亮到案的漸層
    public AnimationCurve _curve;

    //遮罩的顏色
    Color _maskColor;
    //時間
    public float _maskTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //把目前顏色更新到顯示上面
    void UpdateColor(Color color)
    {

    }

    //=======================public ====================

    public void SetMaskColor(Color color)
    {

    }

    public void SetMaskTime(float time)
    {

    }

    //如果要呼叫Mask，
    public void Mask(GameObject uiObject)
    {
        _UIGameObject = uiObject;
    }

    public void CancelMask()
    {

    }

    //設定附著目標
    public void SetTarget(GameObject target)
    {

    }
}
