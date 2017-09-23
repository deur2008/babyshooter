using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//有指定的string list，可以做選擇，然後會回傳index，但是是全部顯示出來
public class SelectShowAllTextMenuUI : PanelUI {

    public GameObject _placeTextGameObject;
    //可以被選擇的string List;
    public List<GameObject> _selectStringList;
    public int _selectIndex;

    //設定有沒有被選到的文字顏色
    public Color _onSelectedTextColor=Color.yellow;
    public Color _notSelectedTextColor=Color.white;


    // 初始化
    void Start()
    {
        UpdateListGameObjectFrom_PlaceTextGameObject();
        UpdateValue();
    }

    //從某個區塊上面去取得
    void UpdateListGameObjectFrom_PlaceTextGameObject()
    {
        _selectStringList = new List<GameObject>();
        Transform[] ts = _placeTextGameObject.GetComponentsInChildren<Transform>();

        if (ts.Length > 1)
        {
            for (int i = 1; i < ts.Length; i++)
            {
                GameObject gameObject = ts[i].gameObject;
                if (gameObject != null)
                {
                    _selectStringList.Add(gameObject);
                }
            }
        }
    }

    //初始化選單
    void UpdateValue()
    {
        for (int i = 0; i < _selectStringList.Count; i++)
        {
            if (i == _selectIndex)
            {
                _selectStringList[i].GetComponent<Text>().color = _onSelectedTextColor;
            }
            else
            {
                _selectStringList[i].GetComponent<Text>().color = _notSelectedTextColor;
            }
        }
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
        if (_selectIndex > 0)
        {
            _selectIndex--;
            UpdateValue();
        }
    }

    //當正在操作這個選單時網上按
    public override void PressRight()
    {
        if (_selectIndex < _selectStringList.Count - 1)
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
