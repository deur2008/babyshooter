using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//顯示目前根敵人的戰力
//在A B隊會用到

public class TeamEnemyBar : GameComponentUI
{
    //目前血條
    public Scrollbar _teamHpBar;
    //敵人血條
    public Scrollbar _enemyHpBar;
    //目前數字表(顯示百分比)
    public GameObject _teamHpPrecentage;
    //敵人數字表(顯示百分比)
    public GameObject _enemyHpPrecentage;

    //目前最大HP
    public float _teamMaxHP=100;
    //敵方最大HP
    public float _enemyMaxHP=100;
    //目前HP
    public float _newTeamHP=50;
    //敵人目前HP
    public float _nowEnemyHP=50;
    //是否要顯示百分比
    public bool _showPrecentage=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //=================public ================
    public void SetTeamMaxProgress(float number=100)
    {
        _teamMaxHP = number;
        UpdateView();
    }

    public void SetEnemyMaxProgress(float number=100)
    {
        _enemyMaxHP = number;
        UpdateView();
    }

    public void SeTeamProgress(float number)
    {
        _newTeamHP = number;
        UpdateView();
    }

    public void SetEnemyProgress(float number)
    {
        _nowEnemyHP = number;
        UpdateView();
    }

    //設定要不要顯示
    public void ShowPrecentage(bool show)
    {
        _showPrecentage = show;
    }


    //================private==================
    
    //整體更新
    void UpdateView()
    {
        UpdateBarPrecentage();
        if (_showPrecentage)
        {
            UpdateDigitalPrecentage();
        }
    }

    //更新百分比顯示
    void UpdateDigitalPrecentage()
    {

    }

    //更新條條顯示
    void UpdateBarPrecentage()
    {
        _teamHpBar.size = (_newTeamHP / _teamMaxHP);
        _enemyHpBar.size = (_nowEnemyHP / _enemyMaxHP);
    }
}
