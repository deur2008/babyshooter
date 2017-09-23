using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//
public class AnimationMenuManager : MenuManager
{
    //用來設定strollRect百分比
    ScrollRect _strollRect;
    //要不要focus在選到的選單
    public bool _focusViewToIndex;
    //當移到最右邊或是最左邊時，按下右會不會到下一排
    //或是跳回 0
    public bool _switchToNextRow = false;

    //移動曲線
    public AnimationCurve _moveCurve;//x0~1對應時間(sec)，Y對應距離
    //放大曲線
    public AnimationCurve _scaleCurve;//x0~1對應時間(sec)，Y對應大小
    //視角移動速度
    public AnimationCurve _viewCurve;

    //兩個物件之間的距離(垂直)
    public float _menuVerticalDistance;
    //兩個物件之間的距離(水平)
    public float _menuHorizontalDistance;

    //不是index到index之間的距離
    public float _verticalDistenceBetweenIndexToMenu;
    //不是index到index之間的距離
    public float _horizontalDistenceBetweenIndexToMenu;
    //放大大小
    public float _scale;
    //左上角距離左邊位置
    public int _leftPosition;
    //左上角距離上面位置
    public int _upPosition;



    //目前應該要觀看位置
    Vector2 _shouldViewPosition;
    //上次觀看位置
    Vector2 _lastViewPosition;


    void Start()
    {
        //先把基本的初始化
        Initialize();
        //把位置對上
        InitializeMenuPositino();
        _strollRect = GetComponent<ScrollRect>();
    }

    //是否要刷新View，如果再updateindexPisition跟strollBar都更新完就會變成false;
    bool _updateView = true;
    void Update()
    {
        if (_updateView)
        {
            UpdateAnimate();
        }

    }

    //=================public==============
    //目前啥都沒有ww

    //=================private===============
    //設定註冊事件
    void SetAllOnClickEvent()
    {
        foreach (GameObject gameObject in _menuList)
        {
            getSingleMenuUI(gameObject).OnClicked += MenuListOnClickEvent;
        }
    }

    //初始化(幫List都排好位置
    void InitializeMenuPositino()
    {
        //把List都拉進某個
        UpdateAnimate();
    }

    //從GameObject 裡面取得 SingleMenuUI 這個script
    SingleMenuUI getSingleMenuUI(GameObject gameObject)
    {
        return gameObject.GetComponent<SingleMenuUI>();
    }

    //被Button按下去的事件
    void MenuListOnClickEvent(SingleMenuUI ui)
    {
        //取得UI的ID
    }

    

    //算出目前
    Vector2 GetIndexPosition()
    {
        Vector2 vector = new Vector2();
        int row = _index % _numberInRow;
        int column = _index / _numberInRow;
        //然後再算出位置
        return vector;
    }



    //在update裡面更新的
    //如果有要呼叫動畫(表示移動)就會呼叫這個，撥放完後就會return false;
    float _nowAnimateTime = 0;//更新動畫時間
    float _nowUpdateViewTime = 0;//更新視角時間
    bool UpdateAnimate()
    {
        //更新UI移動
        if (_lastIndex != _index)
        {
            UpdateMenuPosition(_nowAnimateTime);
            UpdateScale(_nowAnimateTime);
            _nowAnimateTime = _nowAnimateTime + Time.deltaTime;
            //如果時間到惹
            if (_nowAnimateTime >= AnimationCurveManager.GetDifferenceTime(_moveCurve))
            {
                _lastIndex = _index;
                _nowAnimateTime = 0;
            }
        }
        //更新視角
        if (_focusViewToIndex)
        {

            //if (_lastViewPosition != _shouldViewPosition)
            if (_lastIndex != _index)
            {
                //更新位置，index，ladtIndex，Time?
                CalculatePrecentageOfWidthAndHeight(_index);
                _nowUpdateViewTime++;
            }
            //如果時間到了
        }
        return false;
    }

    //更新Menu縮放
    void UpdateMenuPosition(float time)
    {
        //先弄出一個陣列，然後算出相對上一個的距離
        Vector3[,] array;
        if (_menuList.Count < _numberInRow)
        {
            array = new Vector3[1, _menuList.Count];//設定陣列範圍
        }
        else
        {
            array = new Vector3[(_menuList.Count / _numberInRow) + 1, _numberInRow];
        }

        for (int i = 0; i <= (_menuList.Count / _numberInRow); i++) //如果是單行，i就只會是0
        {
            for (int k = 0; k < _numberInRow; k++)
            {
                int nowIndex = i * _numberInRow + k;
                if (nowIndex < _menuList.Count)
                {

                    float horizontalPosition = 0;//距離左邊位置
                    float verticlPosition = 0;//距離上方位置

                    //如果是index那行或是+1，就表示要放大(或是跑動畫)
                    if (IsInIndexColumn(nowIndex))
                    {
                        //表示是剛剛是往上下移動才會有動畫
                        if (IndexMovePosition().left == true || IndexMovePosition().right == true)
                        {
                            horizontalPosition = AnimationCurveManager.GetValueBetweenTwoParameter(_menuHorizontalDistance, _horizontalDistenceBetweenIndexToMenu, _moveCurve, time);
                        }
                        else
                        {
                            horizontalPosition = _horizontalDistenceBetweenIndexToMenu;
                        }
                    }
                    else
                    {
                        horizontalPosition = _menuHorizontalDistance;//正常大小
                    }
                    //計算出橫的的距離，表示目前index為橫的
                    if (IsInIndexRow(nowIndex))
                    {
                        //如果是index那一列或是+1，就表示要放大(或是跑動畫)
                        if (IndexMovePosition().up == true || IndexMovePosition().down == true)
                        {
                            verticlPosition = AnimationCurveManager.GetValueBetweenTwoParameter(_menuVerticalDistance, _verticalDistenceBetweenIndexToMenu, _moveCurve, time);
                        }
                        else
                        {
                            verticlPosition = _verticalDistenceBetweenIndexToMenu;
                        }
                    }
                    else
                    {
                        //正常大小
                        verticlPosition = _menuVerticalDistance;
                    }

                    array[i, k].x = horizontalPosition;//水平
                    array[i, k].y = verticlPosition;
                }
            }
        }


        float nowTotlWidth = 0;//距離左邊的距離 (( horizontalPosition
        float nowTotalHeight = 0;//距離上面的距離 (( verticlPosition
        if (!_vertical)
        {
            //然後填入位置
            for (int i = 0; i <= (_menuList.Count / _numberInRow); i++) //如果是單行，i就只會是0
            {
                nowTotlWidth = 0;
                for (int k = 0; k < _numberInRow; k++)
                {
                    int nowIndex = i * _numberInRow + k;
                    if (nowIndex < _menuList.Count)
                    {
                        if (_focusViewToIndex)
                        {
                            //設定位置
                            SetMenuPosition(nowIndex, nowTotlWidth + array[i, k].x - array[_index/ _numberInRow, _index % _numberInRow].x, nowTotalHeight + array[i, k].y - array[_index / _numberInRow, _index % _numberInRow].y);
                            //幫下一個加好
                            nowTotlWidth = nowTotlWidth + array[i, k].x;
                        }
                        else
                        {
                            //設定位置
                            SetMenuPosition(nowIndex, nowTotlWidth + array[i, k].x, nowTotalHeight + array[i, k].y);
                            //幫下一個加好
                            nowTotlWidth = nowTotlWidth + array[i, k].x;
                        }
                    }
                }
                nowTotalHeight = nowTotalHeight + array[i, 0].y;
            }
        }
        else
        {
            //然後填入位置
            for (int i = 0; i <= (_menuList.Count / _numberInRow); i++) //如果是單行，i就只會是0
            {
                nowTotalHeight = 0;
                for (int k = 0; k < _numberInRow; k++)
                {
                    int nowIndex = i * _numberInRow + k;
                    if (nowIndex < _menuList.Count)
                    {
                        if (_focusViewToIndex)
                        {
                            Debug.Log("_focusViewToIndex" + array[_index / _numberInRow, _index % _numberInRow].y);
                            //設定位置
                            SetMenuPosition(nowIndex, nowTotlWidth + array[i, k].x - array[_index / _numberInRow, _index % _numberInRow].x, nowTotalHeight + array[i, k].y - array[_index / _numberInRow, _index % _numberInRow].y);
                            //設定大小
                            SetMenuScale(nowIndex, array[i, k].z);
                            //幫下一個加好
                            nowTotalHeight = nowTotalHeight + array[i, k].y;
                        }
                        else
                        {
                            //設定位置
                            SetMenuPosition(nowIndex, nowTotlWidth + array[i, k].x, nowTotalHeight + array[i, k].y);
                            //設定大小
                            SetMenuScale(nowIndex, array[i, k].z);
                            //幫下一個加好
                            nowTotalHeight = nowTotalHeight + array[i, k].y;
                        }
                       
                    }
                }
                nowTotlWidth = nowTotlWidth + array[i, 0].x;
            }
        }

    }

    //更新放大大小
    void UpdateScale(float time)
    {
        for (int i = 0; i <= _menuList.Count; i++) //如果是單行，i就只會是0
        {
            float scale;
            if (i == _index)
            {
                //物件放大
                scale = AnimationCurveManager.GetValueBetweenTwoParameter(1, _scale, _scaleCurve, time);
            }
            else
            {
                //物件大小正常
                scale = 1;
            }
            //設定大小
            SetMenuScale(i, scale);
        }
    }

    //更新視角位置
    //要取得上一次的視角(lastIndex)位置跟這次的(nowIndex)
    void UpdateViewPosition(float time)
    {
        //取得_lastIndex跟目前index ，然後算出相對位置，做移動
        if (IndexMovePosition().up)
        {

        }
    }

    //設定物件位置
    void SetMenuPosition(int menuIndex, float x, float y)
    {
        if (_menuList.Count > menuIndex)
        {
            //_menuList[menuIndex].transform.localPosition = new Vector3(x - GetContextLeftUpPosition(_viewContect).x*2 + _menuHorizontalDistance ,
            //    -y  - GetContextLeftUpPosition(_viewContect).y  - _menuVerticalDistance , 0);
                _menuList[menuIndex].transform.localPosition = new Vector3(-x + _leftPosition,- y + _upPosition, 0);
            
            
        }
    }

    //設定物件大小
    void SetMenuScale(int menuIndex, float scale)
    {
        if (_menuList.Count > menuIndex)
        {
            _menuList[menuIndex].transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    //算出是不是位於index那一排的上下
    bool IsInIndexRow(int position)
    {
        //垂直
        if (!_vertical)
        {
            //行
            int nowRow = position / _numberInRow;
            if (_index / _numberInRow == nowRow || (_index / _numberInRow) + 1 == nowRow)
            {
                return true;
            }
        }
        else
        {
            int nowColumn = position % _numberInRow;
            if (_index % _numberInRow == nowColumn || (_index % _numberInRow) + 1 == nowColumn)
            {
                return true;
            }
        }

        return false;
    }

    //算出是不是位於index那一列的左右
    bool IsInIndexColumn(int position)
    {
        //垂直
        if (!_vertical)
        {
            int nowColumn = position % _numberInRow;
            if (_index % _numberInRow == nowColumn || (_index % _numberInRow) + 1 == nowColumn)
            {
                return true;
            }
        }
        else
        {
            int nowRow = position / _numberInRow;
            if (_index / _numberInRow == nowRow || (_index / _numberInRow) + 1 == nowRow)
            {
                return true;
            }
        }
        return false;
    }


    //算出垂直隨著時間距離改變
    float GetVerticalDistenceBetweenIndexToMenu(float time)
    {
        return 0;
    }



    //算出總寬跟高
    void CalculateTotalWidthAndHeight()
    {
        float width = 0;
        float height = 0;


        if (!_vertical)
        {
            //垂直
            if (_menuList.Count < _numberInRow)
            {
                width = 0 * _menuHorizontalDistance + 2 * _horizontalDistenceBetweenIndexToMenu;
                height = (_menuList.Count - 1) * _verticalDistenceBetweenIndexToMenu + _verticalDistenceBetweenIndexToMenu;

            }
            else
            {
                width = (_menuList.Count / _numberInRow) * _menuHorizontalDistance + 2 * _horizontalDistenceBetweenIndexToMenu;
                height = (_numberInRow - 1) * _verticalDistenceBetweenIndexToMenu + 2 * _verticalDistenceBetweenIndexToMenu;
            }
        }
        else
        {
            //水平
            if (_menuList.Count < _numberInRow)
            {
                width = (_menuList.Count - 1) * _menuHorizontalDistance + 2 * _horizontalDistenceBetweenIndexToMenu;
                height = 0 * _verticalDistenceBetweenIndexToMenu + 2 * _verticalDistenceBetweenIndexToMenu;

            }
            else
            {
                width = (_numberInRow - 1) * _menuHorizontalDistance + 2 * _horizontalDistenceBetweenIndexToMenu;
                height = (_menuList.Count / _numberInRow) * _verticalDistenceBetweenIndexToMenu + 2 * _verticalDistenceBetweenIndexToMenu;
            }
        }
        RectTransformManager.SetRectTransformWidthAndHeight(_viewContect, width, height);
    }


    //根據List Index 和 now index ，算出目前位置算出百分比
    void CalculatePrecentageOfWidthAndHeight(int index)
    {
        /*
        if (_vertical)
        {
            //取得垂直百分比
            float VertiaclPrecentage = 1- ((float)(index) / (float)(_menuList.Count % _numberInRow));
            //取得水平百分比
            float horizontalPrecentage = 1- ((float)(index) / (float)(_menuList.Count % _numberInRow));
            //更新
            Debug.Log("VertiaclPrecentage" + VertiaclPrecentage);
            _strollRect.verticalNormalizedPosition=VertiaclPrecentage;//垂直
            _strollRect.verticalScrollbar.value = VertiaclPrecentage;//垂直
            _strollRect.horizontalScrollbar.value = horizontalPrecentage;
        }
        else
        {

        }
        */
    }



    float _horizontalScrollRectPrecentage;
    float _verticalScrollRectPrecentage;

    //更新資料
    void UpdateScrollRectWidthAndHeightPrecentage()
    {
        _horizontalScrollRectPrecentage = GetScrollRectHorizontalPrecentage();
        _verticalScrollRectPrecentage = GetScrollRectVerticalPrecentage();
    }

    //============================access public=======================

    //取得水平百分比
    float GetScrollRectHorizontalPrecentage()
    {
        return this.GetComponent<ScrollRect>().horizontalScrollbar.value;
    }

    //取得目前垂直百分比
    float GetScrollRectVerticalPrecentage()
    {
        return this.GetComponent<ScrollRect>().verticalScrollbar.value;
    }

    //設定拉桿的百分比
    void SetScrollRectWidthAndHeightPrecentage(float width, float height)
    {
        //水平的值
        this.GetComponent<ScrollRect>().horizontalScrollbar.value = width;
        //垂直的值
        this.GetComponent<ScrollRect>().verticalScrollbar.value = width;
    }

    //取得Contect左上角位置
    //他是取得width 和 height，所以在

    Vector2 GetContextLeftUpPosition(GameObject contect)
    {
        Vector2 returnValue = new Vector2();
        returnValue.x = -contect.GetComponent<RectTransform>().sizeDelta.x / 2;
        returnValue.y = -contect.GetComponent<RectTransform>().sizeDelta.y / 2;
        //Debug.Log("X=" + returnValue.x + "Y=" + returnValue.y);
        return returnValue;
    }

    //取得scale
    Vector2 GetXYScale(GameObject contect)
    {
        return contect.GetComponent<RectTransform>().localScale;
        Debug.Log("llocal X=" + contect.GetComponent<RectTransform>().localScale.x);
    }
}
