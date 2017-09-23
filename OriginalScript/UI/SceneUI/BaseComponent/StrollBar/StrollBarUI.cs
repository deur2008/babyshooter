using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//拉桿
//可以設定目前拉感的位置(百分比或數值)
//最大值，最小值
//還有被拉時的背景改變，超過某個值得背景改變
//通知有 : 滑鼠按下 跟 正在被拉
public class StrollBarUI : PanelUI {

    //是不是水平
    public bool _horizontal=true;
    //最大
    public float _maximunValue = 100;
    //最大
    public float _minumumValue = 0;
    //目前
    public float _value=50;
    //增加速度，一秒鐘增加 30
    public float _increaseValue = 30;
    //物件
    public GameObject _slider;

    //控制目前對象
    void Start () {
        //控制自己
        //ControlChildObject(false);
        //初始化拉感
        InitialScrollBar();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //初始化拉感
    void InitialScrollBar()
    {
        _slider.GetComponent<Slider>().maxValue = _maximunValue;
        _slider.GetComponent<Slider>().minValue = _minumumValue;
        _slider.GetComponent<Slider>().value = _value;
    }

    //增加值
    void IncreaseScrollBarValue()
    {
        if (_slider.GetComponent<Slider>().value < _maximunValue)
        {
            _slider.GetComponent<Slider>().value = _slider.GetComponent<Slider>().value + _increaseValue * Time.deltaTime;
        }
        if (_slider.GetComponent<Slider>().value > _maximunValue)
        {
            _slider.GetComponent<Slider>().value = _maximunValue;
        }
        _value = _slider.GetComponent<Slider>().value;
    }

    //減少值
    void DesreaseScrollBarValue()
    {
        if (_slider.GetComponent<Slider>().value > _minumumValue)
        {
            _slider.GetComponent<Slider>().value = _slider.GetComponent<Slider>().value - _increaseValue * Time.deltaTime;
        }
        if (_slider.GetComponent<Slider>().value < _minumumValue)
        {
            _slider.GetComponent<Slider>().value = _minumumValue;
        }
        _value = _slider.GetComponent<Slider>().value;
    }


    //當正在操作這個選單時網上按
    //
    public override void PressUp()
    {
        //如果是水平模式
        if (_horizontal)
        {
           
        }
        else
        {
            IncreaseScrollBarValue();
            //OnNotifiedChange();
        }
    }

    //當正在操作這個選單時網上按
    public override void PressDown()
    {
        if (_horizontal)
        {
           
        }
        else
        {
            DesreaseScrollBarValue();
            //OnNotifiedChange();
        }
    }

    //當正在操作這個選單時網上按
    public override void PressLeft()
    {
        if (_horizontal)
        {
            DesreaseScrollBarValue();
            //OnNotifiedChange();
        }
        else
        {

        }
    }

    //當正在操作這個選單時網上按
    public override void PressRight()
    {
        if (_horizontal)
        {
            IncreaseScrollBarValue();
            //OnNotifiedChange();
        }
        else
        {
           
        }
    }

    //如果在當下選單按選擇
    public override void PressTrigger()
    {
        //通知監聽者已經按下Select
        OnNotifiedSelect();

    }

    //如果離開選單
    public override void PressGrab()
    {
        //通知外部已經Cancel了
        OnNotifiedCancel();
    }


}
