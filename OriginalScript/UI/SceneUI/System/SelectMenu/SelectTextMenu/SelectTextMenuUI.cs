using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//有string list可以做選擇
public class SelectTextMenuUI : PanelUI {
    //可以被選擇的string List;
    public List<string> _selectStringList;
    public GameObject _text;
    public int _selectIndex;
	// Use this for initialization
	void Start () {
        UpdateValue();
    }

    //初始化選單
    void UpdateValue()
    {
        _text.GetComponent<Text>().text = _selectStringList[_selectIndex];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //當正在操作這個選單時網上按
    //表示取消選擇
    public override void PressUp()
    {
        //OnChildMenuNotifiedCancel();
    }

    //當正在操作這個選單時網上按
    //表示取消選擇
    public override void PressDown()
    {
        //OnChildMenuNotifiedCancel();
    }

    //當正在操作這個選單時網上按
    public override void PressLeft()
    {
        if (_selectIndex > 0)
        {
            _selectIndex--;
            UpdateValue();
        }
    }

    //當正在操作這個選單時網上按
    public override void PressRight()
    {
        if (_selectIndex < _selectStringList.Count-1)
        {
            _selectIndex++;
            UpdateValue();
        }
    }

    //如果在當下選單按選擇
    public override void PressTrigger()
    {
        OnNotifiedSelect();
    }

    //如果離開選單
    public override void PressGrab()
    {
        //OnChildMenuNotifiedCancel();
    }
}
