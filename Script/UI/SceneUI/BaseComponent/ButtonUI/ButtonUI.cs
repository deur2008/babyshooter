using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ButtonGUI 控制
//可以設定沒有按，按下，跟選擇的Button背景
//然後有事件可以註冊
//還有Hover問題，應該可以在 PanelUI 裡面解決
public class ButtonUI : PanelUI {
    public Color _focusColor = Color.yellow;
    public Color _selectedColor = Color.black;
    public Color _originalColor = Color.white;
    Button _button;
    //自動通知點擊和選擇

    //設定圖片
    public Image _backgroundImage;

    // Use this for initialization
    void Start() {
        try
        {
            _button = this.GetComponent<Button>();
            //增加被案到時的監聽是件
            _button.onClick.AddListener(() => { ButtonOnClick(); });
            _originalColor = _backgroundImage.color;
            _originalColor = Color.white;
        }
        catch
        {
            _originalColor = Color.white;
        }
    }

    //如果被啟用
    void OnEnable()
    {
        SetIsOnSelected(false);
        SetHighLight(false);
    }

    // Update is called once per frame
    void Update() {

    }

    //如果按鈕被(例如滑鼠)按到
    void ButtonOnClick()
    {
        Debug.Log("Button on Click! + Tag : " + _tag);
        SetIsOnSelected(true);
    }

    public override void SetIsOnSelected(bool selected)
    {
        base.SetIsOnSelected(selected);
        UpdateButtonSelectColor();
        
    }

    public override void SetHighLight(bool highLight)
    {
        base.SetHighLight(highLight);
        UpdateButtonFocusColor();
    }

    //設定 Focus 的顏色
    void UpdateButtonFocusColor()
    {
        if (!_highLight)
        {
            SetImageColor(_originalColor);
        }
        else
        {
            SetImageColor(_focusColor);
        }
    }

    void UpdateButtonSelectColor()
    {
        if (!_thisIsOnselected)
        {
            SetImageColor(_originalColor);
        }
        else
        {
            SetImageColor(_selectedColor);
        }
    }

    //設定圖片顏色
    protected void SetImageColor(Color color)
    {
        try
        {
            _backgroundImage.color = color;
        }
        catch
        {

        }
    }

}
