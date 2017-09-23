using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//用來管理單一Menu
//會設定裡面的一些動作，主要是做選單加強顯示的動作之類的
//如果menu裡面有選單會在底下的childObject裡面放置
public class SingleMenuUI : PanelUI {
    //按鈕
    //Button _button;
    //底下物件，裡面通常包含panel
    public GameObject _panelObject;

    //Image部分
    public GameObject _onfocusBackgroundImage;//正常，控制方是用GameObject 的Enable Disable ?
    public GameObject _onselectBackgroundImage;//正常，控制方是用GameObject 的Enable Disable ?
    public GameObject _normalBackgroundImage;//正常，控制方是用GameObject 的Enable Disable ?
    public GameObject _highlightBackgroundImage;//醒目背景
    public GameObject _newMessageBackgroundImage;//新信息(顯示New?)
    public GameObject _disableBackgroundImage;//禁止操作

    
    //指說可以被游標選擇到
    public bool _clickable = false;
    //或者是可以被展開
    public bool _expand = true;
    //目前Menu是被Focus到的，也就是可以對上面做操作
    //一組Menu裡面只會有一個被Focus
    public bool _focus = false;

    //是直接被鼠標按到
    public delegate void ClickAction(SingleMenuUI ui);
    public event ClickAction OnClicked;

    
    //初始化?
    void Start()
    {
        //初始化控制對象
        Initialize();
        //然後對子物件進行監聽
        //SetListenerToChildPanel(_childObject);
    }

    //更新
    void Update()
    {
        //DetectHover();
    }

    //===============public======================= 

    //設定選單是不是被鎖定的
    //如果被鎖定就代表不能操作
    public override void SetAsDisable(bool disable)
    {
        base.SetAsDisable(disable);
        SelectBackGround(_disableBackgroundImage, _disable);
    }

    //設定是不是要醒目
    public override void SetHighLight(bool highLight)
    {
        base.SetHighLight(highLight);
        SelectBackGround(_highlightBackgroundImage, _disable);
    }

    //設定目前是不是被選擇
    public override void SetIsOnSelected(bool selected)
    {
        base.SetIsOnSelected(selected);
        SelectBackGround(_onselectBackgroundImage, _disable);
    }

    //目前選單被focus
    public virtual void OnFocus(bool focua)
    {
        _focus = focua;
        SelectBackGround(_onfocusBackgroundImage, _disable);
    }

    //設定值進去
    public override void SetValue(object obj)
    {

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

    //設定背景圖片要不要顯示
    protected virtual void SelectBackGround(GameObject gameobject, bool enable)
    {
        try
        {
            //讓背景的渲染取消
            gameobject.GetComponent<Image>().GetComponent<Renderer>().enabled = enable;
        }
        catch
        {

        }
    }

}
