using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//SelectNumberMenu : 有區間的數字，範圍，增加幅度，可以選擇
public class SelectNumberMenuUI : PanelUI
{
    public int _value=5000;
    public int _increaseInonePress = 100;
    public int _maxvalue = 10000;
    public int _minvalue = 0;
    public GameObject _text;
    // Use this for initialization
    void Start()
    {
        UpdateValue();
    }

    //初始化選單
    void UpdateValue()
    {
        _text.GetComponent<Text>().text = _value.ToString() ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //當正在操作這個選單時網上按
    //表示取消選擇
    public override void PressUp()
    {

    }

    //當正在操作這個選單時網上按
    //表示取消選擇
    public override void PressDown()
    {

    }

    //當正在操作這個選單時網上按
    public override void PressLeft()
    {
        if (_value > _minvalue)
        {
            _value= _value- _increaseInonePress;
            if (_value < _minvalue)
                _value = _minvalue;
            UpdateValue();
        }
    }

    //當正在操作這個選單時網上按
    public override void PressRight()
    {
        if (_value < _maxvalue)
        {
            _value = _value + _increaseInonePress;
            if (_value > _maxvalue)
                _value = _maxvalue;
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
