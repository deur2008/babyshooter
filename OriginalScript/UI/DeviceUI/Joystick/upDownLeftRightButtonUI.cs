using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//搖桿上顯示上下左右按鈕的UI
public class upDownLeftRightButtonUI : MonoBehaviour {

    //按鈕物件
    public Image _upGameObject;
    public Image _downGameObject;
    public Image _leftGameObject;
    public Image _rightGameObject;

    //OKButton
    public Image _okButton;

    //cancelButton
    //在上面比較小的
    public Image _cancelButton;

    //然後是設定顏色
    public Color _touchColor = Color.gray;
    public Color _singleClickColor = Color.black;
    public Color _doubleClickColor = Color.red;
    public Color _releaseColor = Color.white;


    //顯示 上下左右的按鍵
    bool _showDpadButton = true;
    //顯示圓盤模式
    bool _showOKButton = false;

    //預設是 UpDownLeftRightButtonMode
    void Start () {
        UpDownLeftRightButtonMode();
    }

   

    //顯示上下左右按鈕
    void UpDownLeftRightButtonMode(bool display)
    {
        _showDpadButton = display;
        _upGameObject.enabled=display;
        _downGameObject.enabled = display;
        _leftGameObject.enabled = display;
        _rightGameObject.enabled = display;
    }

    //顯示OK
    void ShowOKButton(bool display)
    {
        _showOKButton = display;
        _okButton.enabled = display;
    }

    //=========================public ==========================

    //顯示上下左右按鈕
    public void UpDownLeftRightButtonMode()
    {
        UpDownLeftRightButtonMode(true);
        ShowOKButton(false);
    }

    //顯示OK模式
    public void ShowOKButton()
    {
        UpDownLeftRightButtonMode(false);
        ShowOKButton(true);
    }

    //選上
    public void PressUp(bool doubleClick=false)
    {
        if (_showDpadButton)
            if (doubleClick)
            {
                _upGameObject.color = _doubleClickColor;
            }
            else
            {
                _upGameObject.color = _singleClickColor;
            }
    }

    //選下
    public void PressDown(bool doubleClick = false)
    {
        if (_showDpadButton)
            if (doubleClick)
            {
                _downGameObject.color = _doubleClickColor;
            }
            else
            {
                _downGameObject.color = _singleClickColor;
            }
    }

    //選左
    public void PressLeft(bool doubleClick = false)
    {
        if (_showDpadButton)
            if (doubleClick)
            {
                _leftGameObject.color = _doubleClickColor;
            }
            else
            {
                _leftGameObject.color = _singleClickColor;
            }
    }

    //選右
    public void PressRight(bool doubleClick = false)
    {
        if (_showDpadButton)
            if (doubleClick)
            {
                _rightGameObject.color = _doubleClickColor;
            }
            else
            {
                _rightGameObject.color = _singleClickColor;
            }
    }

    //選上
    public void PressOK(bool doubleClick = false)
    {
        if (_showOKButton)
            if (doubleClick)
            {
                _okButton.color = _doubleClickColor;
            }
            else
            {
                _okButton.color = _singleClickColor;
            }
    }

    //選上
    public void PressBack(bool doubleClick = false)
    {
        if (doubleClick)
        {
            _cancelButton.color = _doubleClickColor;
        }
        else
        {
            _cancelButton.color = _singleClickColor;
        }
    }

    //把"上"鍵放開
    public void ReleaseUp()
    {
        if (_showDpadButton)
        {
            _upGameObject.color = _releaseColor;
        }
    }

    //把"上"鍵放開
    public void ReleaseDown()
    {
        if (_showDpadButton)
        {
            _downGameObject.color = _releaseColor;
        }
    }

    //把"左"鍵放開
    public void ReleaseLeft()
    {
        if(_showDpadButton)
        {
            _leftGameObject.color = _releaseColor;
        }
    }

    //把"右"鍵放開
    public void ReleaseRight()
    {
        if (_showDpadButton)
        {
            _rightGameObject.color = _releaseColor;
        }
    }


    //選上
    public void ReleaseOK()
    {
        if (_showOKButton)
        {
            _okButton.color = _releaseColor;
        }
    }


    //選上
    public void ReleaseBack()
    {
        _cancelButton.color = _releaseColor;
    }

    //選上
    public void TouchUp()
    {
        if (_showDpadButton)
            _upGameObject.color = _touchColor;
    }

    //選下
    public void TouchDown()
    {
        if (_showDpadButton)
            _downGameObject.color = _touchColor;
    }

    //選左
    public void TouchLeft()
    {
        if (_showDpadButton)
            _leftGameObject.color = _touchColor;
    }

    //選右
    public void TouchRight()
    {
        if (_showDpadButton)
            _rightGameObject.color = _touchColor;
    }

    //把"OK"鍵碰到
    public void TouchOK()
    {
        if (_showOKButton)
            _okButton.color = _touchColor;
    }


}
