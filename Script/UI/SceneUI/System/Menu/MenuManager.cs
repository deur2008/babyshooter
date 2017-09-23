using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;

//用來管理一個主要選單裡面的所有選單
//目前用在主選單，遊戲選單跟腳色選單，還有具場或是商店等等
//如果要get角色參數要從 List<GameObject> 裡面自己撈

public class MenuManager : PanelUI
{
    //選單list
    protected List<GameObject> _menuList = new List<GameObject>(); //之後改成從 _viewContect 自動抓取
    //顯示選單的物件((所有的選單物件都要放在那邊
    //然後會抓底下的 Meni 到 _menuList 上面
    public GameObject _viewContect;
    //選單是橫的還是直的
    public bool _vertical; //垂直
    //要觀看的Index
    public int _index;
    //上一個index
    protected int _lastIndex;
    //設定多少個選單一排或是一列，如果是99代表都是一排或是一列
    public int _numberInRow = 99;
    //在按下上下鍵時自動選擇，如果是一般選單模式是要自己按下"選擇"後才能夠操作子選單
    public bool _autoSelect = false;

    //index Change
    public event ModelChangedEventHandler _indexChanged;


    void Start()
    {
        Initialize();
    }

    //是否要刷新View，如果再updateindexPisition跟strollBar都更新完就會變成false;
    
    void Update()
    {
        if (_lastIndex !=_index)
        {
            UpdateIndex();
        }

    }



    //=========================public ======================
    //如果Child有倍增加，可以從外部呼叫重新整理
    public void IntialView()
    {
        InitialMenuList();
    }

    //選左
    public override void PressLeft()
    {
       
        MoveLeft();
        Debug.Log("nowIndex=" + _index + "_lastIndex=" + _lastIndex);
    }

    //選右
    public override void PressRight()
    {
       
        MoveRight();
        Debug.Log("nowIndex=" + _index + "_lastIndex=" + _lastIndex);

    }

    //選上
    public override void PressUp()
    {
        //控制自己
        MoveUp();
        Debug.Log("nowIndex=" + _index + "_lastIndex=" + _lastIndex + " Name = " + _menuList[_index].name);
    }

    //選下
    public override void PressDown()
    {
        
        MoveDown();
        Debug.Log("nowIndex=" + _index + "_lastIndex=" + _lastIndex);
    }

    //選擇
    public override void PressTrigger()
    {
        Debug.Log("PressSelect");
        //按下select
        if (_autoSelect == false)
        {
            SetMenuObjectSelected(_index, true);
        }
        else
        {
            //temp
            SetMenuObjectSelected(_index, true);
        }
    }

    //取消
    public override void PressGrab()
    {
        Debug.Log("PressGrab");
        //按下select
        if (_autoSelect == false)
        {
            //通知取消
            OnNotifiedCancel();
        }
        else
        {
            //通知取消
            OnNotifiedCancel();
        }
    }

    //選擇目前被按到的按鈕
    public override void SetValue(object index)
    {

    }

    //設定轉換方向
    public void MoveToIndex(int index)
    {
        _index = index;
        Debug.Log("nowIndex=" + _index + "total =" + _menuList.Count);
        //如果可以直接控制子物件
        if (_autoSelect)
        {
            SetMenuObjectSelected(_index, true);
        }
        else
        {
            SetMenuObjectHighLiget(_index, true);
        }
    }
    //=========================private ======================

    //初始化
    public override void Initialize()
    {
        //取得Menu
        InitialMenuList();
        Debug.Log("_menu.count= " + _menuList.Count);
        //設定控制權
    }

    //設定選單可以往哪些地方走
    public struct Position
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
    }

    //設定說哪邊可以過去
    private Position GetPositionCanGo()
    {
        Position position = new Position();
        position.up = false;
        position.down = false;
        position.left = false;
        position.right = false;

        //先過濾掉只有單排的選項
        if (!_vertical && _menuList.Count <= _numberInRow)
        {
            //單排 和 垂直，表示左右不行
            position.up = false;
            position.down = false;
            if (_index > 0)
            {
                position.left = true;
            }
            if (_index < _menuList.Count - 1)
            {
                position.right = true;
            }
        }
        else if (_vertical && _menuList.Count <= _numberInRow)
        {
            //單排 和 水平，表示左右不行
            position.left = false;
            position.right = false;
            if (_index > 0)
            {
                position.up = true;
            }
            if (_index < _menuList.Count - 1)
            {
                position.down = true;
            }
        }
        else
        {
            //表示多排，水平或是垂直
            if (_vertical)
            {
                //垂直
                if (_index - _numberInRow >= 0)
                {
                    position.left = true;
                }
                if (_index + _numberInRow < _menuList.Count)
                {
                    position.right = true;
                }
                if (_index % _numberInRow > 0)
                {
                    position.up = true;
                }
                if (_index % _numberInRow < _numberInRow - 1)
                {
                    position.down = true;
                }
            }
            else
            {
                //水平
                if (_index - _numberInRow >= 0)
                {
                    position.up = true;
                }
                if (_index + _numberInRow < _menuList.Count)
                {
                    position.down = true;
                }
                if (_index % _numberInRow > 0)
                {
                    position.left = true;
                }
                if (_index % _numberInRow < _numberInRow - 1)
                {
                    position.right = true;
                }
            }
        }
        return position;
    }

    //算出上一個index和這次的index是往哪個方向
    protected Position IndexMovePosition()
    {
        Position position = new Position();
        position.up = false;
        position.down = false;
        position.left = false;
        position.right = false;

        int upDown;
        int leftRight;

        leftRight = _index % _numberInRow - _lastIndex % _numberInRow;//算行數(左右)
        upDown = (int)(_index / _numberInRow) - (int)(_lastIndex / _numberInRow);//算列數(上下)

        if (!_vertical)//垂直
        {

            if (leftRight > 0)
            {
                position.right = true;
            }
            if (leftRight < 0)
            {
                position.left = true;
            }
            if (upDown > 0)
            {
                position.down = true;
            }
            if (upDown < 0)
            {
                position.up = true;
            }
        }
        else
        {
            //Vertical時
            if (leftRight > 0)
            {
                position.up = true;
            }
            if (leftRight < 0)
            {
                position.down = true;
            }
            if (upDown > 0)
            {
                position.right = true;
            }
            if (upDown < 0)
            {
                position.left = true;
            }
        }


        return position;
    }

    //往上
    protected bool MoveUp()
    {
        if (GetPositionCanGo().up == true)
        {
            SyneIndex();
            if (_vertical)
            {
                _index--;
            }
            else
            {
                _index = _index - _numberInRow;
            }
            return true;
        }
        return false;
    }

    //往下
    protected bool MoveDown()
    {
        if (GetPositionCanGo().down == true)
        {
            SyneIndex();
            if (_vertical)
            {
                _index++;
            }
            else
            {
                if (_menuList.Count < _numberInRow)//表示單行
                {

                }
                else
                {
                    _index = _index + _numberInRow;
                }

            }
            return true;
        }
        return false;
    }

    //往左
    protected bool MoveLeft()
    {
        if (GetPositionCanGo().left == true)
        {
            SyneIndex();
            if (_vertical)
            {
                _index = _index - _numberInRow;
            }
            else
            {
                _index--;
            }
            return true;
        }
        return false;
    }

    //往右
    protected bool MoveRight()
    {
        if (GetPositionCanGo().right == true)
        {
            SyneIndex();
            if (_vertical)
            {
                _index = _index + _numberInRow;
            }
            else
            {
                _index++;
            }
            return true;
        }
        return false;
    }

    //同步index
    protected void SyneIndex()
    {
        _lastIndex = _index;
        Debug.Log("sync index");
    }

    //把所有物件設定成focus
    private void SetAllMenuOnFocus(int index)
    {
        //在範圍內
        if (index < _menuList.Count && index >= 0)
        {
            try
            {
                _menuList[index].GetComponent<PanelUI>().SetHighLight(true);
            }
            catch 
            {

            }
        }
    }

    //把所有物件設定成not focus
    private void SetAllMenuOnNotFocus()
    {
        foreach (GameObject gameObject in _menuList)
        {
            try
            {
                gameObject.GetComponent<PanelUI>().SetHighLight(false);
            }
            catch
            {

            }
        }
    }

    //把物件設定成select
    protected void SetMenuOnSelected(int index)
    {
        //在範圍內
        if (index < _menuList.Count && index >= 0)
        {
            try
            {
                _menuList[index].GetComponent<PanelUI>().SetIsOnSelected(true);
            }
            catch
            {

            }
        }
    }

    //把所有物件設定成not focus
    private void SetAllMenuOnNotSelected()
    {
        foreach (GameObject gameObject in _menuList)
        {
            try
            {
                gameObject.GetComponent<PanelUI>().SetIsOnSelected(false);
            }
            catch
            {

            }
        }
    }

    //在index改變的時候
    void UpdateIndex()
    {
        //同步index
        SyneIndex();
        //指定選到的index
        SetSelectHighLight(_index);
    }

    //把focus到的HighLight起來
    protected void SetSelectHighLight(int index)
    {
        if (_menuList.Count > 0)
        {
            for (int i = 0; i < _menuList.Count; i++)
            {
                if (i == index)
                {
                    _menuList[i].GetComponent<PanelUI>().SetHighLight(true);
                }
                else
                {
                    _menuList[i].GetComponent<PanelUI>().SetHighLight(false);
                }
            }
        }
    }

    //選擇
    protected void SelectIndex()
    {
        SetAllMenuOnNotSelected();
        SetMenuOnSelected(_index);
    }

    //不選擇了
    protected void cancelMenu()
    {

    }


    //=========================Initialize========================
    //把 _viewContect 裡面的panel全部讀取到 _menuList 裡面
    void InitialMenuList()
    {
        _menuList = new List<GameObject>();
        /*
        Transform[] ts = _viewContect.GetComponentsInChildren<Transform>();
        //Debug.Log("Length : " + ts.Length);
        if (ts.Length > 1)
        {
            for (int i = 1; i < ts.Length; i++)
            {
                GameObject gameObject = ts[i].gameObject;
                if (gameObject != null)
                {
                    if (gameObject.GetComponent<PanelUI>() != null)
                    {
                        _menuList.Add(gameObject);
                    }
                }
            }
        }
        */

        for (int i = 0; i < _viewContect.transform.childCount; i++)
        {
            if (_viewContect.transform.GetChild(i) != null)
            {
                if (_viewContect.transform.GetChild(i).GetComponent<PanelUI>() != null)
                {
                    _menuList.Add(_viewContect.transform.GetChild(i).gameObject);
                }
            }
        }
    }

    //取得panel UI
    PanelUI GetMenuObjectPanelUIClass(GameObject gameObject)
    {
        return gameObject.GetComponent<PanelUI>();
    }

    //取得child物件裡面的  SingleMenuUI
    SingleMenuUI GetChildGameObjectClass(GameObject gameObject)
    {
        return gameObject.GetComponent<SingleMenuUI>();
    }


    //取得選單內得到的結果
    //會用json的方式傳遞
    public override object GetValue()
    {
        try
        {
            //把目前物件轉成json格式
            return JsonConvert.SerializeObject(GetPanelUIJsonFromat());
            //return "";
        }
        catch (Exception ex)
        {
            Debug.Log("Panel Error : +" + ex.Message);
            return "";
        }
    }

    //取得目前的狀態
    public override PanelUIJsonFromat GetPanelUIJsonFromat()
    {
        //建構
        PanelUIJsonFromat _panelUIJsonFromat = new MenuPanelUIJsonFromat();
        try
        {
            _panelUIJsonFromat.Index = _tag;
            _panelUIJsonFromat.Type = this.Type();
            _panelUIJsonFromat.Value = _index.ToString();
            ((MenuPanelUIJsonFromat)_panelUIJsonFromat).SelectIndex = _index;

            foreach (GameObject objecct in _menuList)
            {
                ((MenuPanelUIJsonFromat)_panelUIJsonFromat).MenuObject.Add(GetMenuObjectPanelUIClass(objecct).GetPanelUIJsonFromat());
            }
        }
        catch
        {

        }
        return _panelUIJsonFromat;

        //JsonConvert.SerializeObject(_panelUIJsonFromat)
    }

    //如果是Menu panel 的json格式
    public class MenuPanelUIJsonFromat : PanelUIJsonFromat
    {
        public List<PanelUIJsonFromat> MenuObject { get; set; }
        public int SelectIndex { get; set; }
    }

    //設定物件是highLight
    public virtual void SetMenuObjectHighLiget(int index,bool highLight)
    {
        if (_menuList.Count > 0)
        {
            for (int i = 0; i < _menuList.Count; i++)
            {
                if (i == index)
                {
                    SetChildFocus(_menuList[i], highLight);
                }
                else
                {
                    SetChildFocus(_menuList[i], false);
                }
            }
            
        }
    }

    //設定物件是highLight
    public virtual void SetMenuObjectSelected(int index, bool highLight)
    {

        //通知選擇
        OnNotifiedSelect();

        if (_menuList.Count > 0)
        {
            Debug.Log("Select Index! + " + _index);//是用排列順序
            for (int i = 0; i < _menuList.Count; i++)
            {
                if (i == index)
                {
                    SetChildOnSelect(_menuList[i], highLight);
                    //把控制權轉到child上面
                    //Debug.Log("Select Index! 2 " + _menuList[i].name);
                    //SetListenerToChildPanel(_menuList[i]);
                }
                else
                {
                    SetChildOnSelect(_menuList[i], false);
                }
            }
        }
       
    }

    //設定子物件要不要醒目
    public virtual void SetChildFocus(GameObject gameobject,bool highLight)
    {
        GetChildGameObjectClass(gameobject).OnFocus(highLight);
    }

    //設定子物件要不要被選擇
    public virtual void SetChildOnSelect(GameObject gameobject, bool select)
    {
        GetMenuObjectPanelUIClass(gameobject).SetIsOnSelected(select);
    }
}


