using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//顯示文字的Dialog
public class TextDialogUI : PanelUI{

    //設定Text
    public string _contextText;
    //UI
    public Text _textUI;
    
	// Use this for initialization
	void Start () {
        //設定文字
        SetText(_contextText);
        //初始化
        Initialize();
        //然後對子物件進行監聽
        //SetListenerToChildPanel(_childObject);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //如果要設定文字
    public override void SetValue(object obj)
    {
        SetText((string)obj);
    }

    //設定顯示文字
    public void SetText(string str)
    {
        _contextText = str;
        _textUI.text = _contextText;
    }

    //有些物件因為沒有反應，所以會對子物件做監聽
    protected virtual void SetListenerToChildPanel(GameObject childObject)
    {
        /*
        try
        {
            if (childObject != null)
            {
                childObject.GetComponent<PanelUI>()._modelChanged += new PanelUI.ModelChangedEventHandler(OnChildMenuNotifiedChange);
                //選擇選單監聽
                childObject.GetComponent<PanelUI>()._modelPressSelect += new PanelUI.ModelPressSelect(OnChildMenuNotifiedSelect);
                //退出選ㄉ監聽
                childObject.GetComponent<PanelUI>()._modelPressCancel += new PanelUI.ModelPressCancel(OnChildMenuNotifiedCancel);
                //子選單有沒有被Hover到
                childObject.GetComponent<PanelUI>()._modelHovered += new PanelUI.ModelHovered(OnChildMenuNotifiedHover);
            }
        }
        catch (Exception ex)
        {
            Debug.Log("SetListenerToChildPanel Error" + ex.Message);
        }
        */
    }

}
