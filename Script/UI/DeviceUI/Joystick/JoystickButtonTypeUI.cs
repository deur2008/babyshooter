using UnityEngine;
using System.Collections;

//用來管理顯示哪一種UI
//還有Buttno按下去後的反應
public class JoystickButtonTypeUI : MonoBehaviour {

    //要不要顯示
    public bool display = true;
    //顯示上下左右
    public GameObject _upDownLeftRightButton;
    //顯示OK
    public GameObject _okButton;

    //ShowUpDownLeftRightButton
    bool _upDownLeftRightButtonMode;
    //ShowOKButton
    bool _oKButtonMode;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //顯示OK
    public void ShowOKButton()
    {
        _upDownLeftRightButtonMode = false;
        _oKButtonMode = true;
        RefreshButtonUI();
    }

    //顯示上下左右
   
    public void ShowUpDownLeftRightButton()
    {
        _upDownLeftRightButtonMode = true;
        _oKButtonMode = false;
        RefreshButtonUI();
    }

    //更新成不同UI
    void RefreshButtonUI()
    {

    }

    int lastDisplay = -1;
    int none = -1;
    int up = 0;
    int down = 1;
    int left = 2;
    int right = 3;
    int OK = 4;
    
    //如果按下"上"
    public void PressUpButton(bool press)
    {
        
        if (_upDownLeftRightButtonMode)
        {
            if (press)
            {

            }
            else //如果是false
            {
                lastDisplay = none;
            }
        }
    }

    //如果按下"下"
    //下的按鍵就會發亮或是變色
    public void PressDownButton(bool press)
    {
        if (_upDownLeftRightButtonMode)
        {
            if (press)
            {

            }
            else //如果是false
            {
                lastDisplay = none;
            }
        }
    }

    //如果按下"左"
    public void PressLeftButton(bool press)
    {
        if (_upDownLeftRightButtonMode)
        {
            if (press)
            {

            }
            else //如果是false
            {
                lastDisplay = none;
            }
        }
    }

    //如果按下"右"
    public void PressRightButton(bool press)
    {
        if (_upDownLeftRightButtonMode)
        {
            if (press)
            {

            }
            else //如果是false
            {
                lastDisplay = none;
            }
        }
    }

    //如果釋放按鈕
    public void ReleaseButton()
    {
        lastDisplay = none;
    }

    //如果按下"OK"
    public void PressOKButton(bool press)
    {
        if (_upDownLeftRightButtonMode)
        {
            if (press)
            {
                //pressOK
            }
            else //如果是false
            {
                //releaseOK
            }
        }
        else if (_oKButtonMode)
        {
            if (press)
            {
                //pressOK
            }
            else //如果是false
            {
                //releaseOK
            }
        }
    }

    //顯示發亮
    void HighLightUpDownLeftRightButton(int index)
    {

    }

    //顯示OK的發亮
    void HighLightOKButton(bool light)
    {

    }
}
