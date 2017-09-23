using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//敵人產生器
//會隨機產生敵人
//目前是隨機選一個
//然後隨機選位置
//然後出來
public class EnemyCreator : MonoBehaviour {

    public int _defeatedEnemyNumber = 0;
    //可以生成最大敵人數量
    public int _maxEnemyNumber = 1;
    //public int _maxEnemyNumber = 20;  /*原始碼*/
    //是不是生成敵人
    public bool _isTargetEnemy=true;
    //生成難度
    public StageController.Difficulty _difficulity=StageController.Difficulty.normal;

    //生成速度，一分鐘會有幾個人敵人，如果不希望在easy出現的敵人就把easy數量變成0
    public float _easyModeEnemyParMinut=5;
    public float _normalModeEnemyParMinut = 7;
    public float _hardModeEnemyParMinut = 12;
    public float _insameModeEnemyParMinut = 15;
    //生成速度，一分鐘會有幾個人敵人
    float _enemyParMinute;

    //是不是在時間內
    public bool _isVaild=false;

    //開始時間
    public float _startTime;
    public float _stopTime;
    float _nowTime = 0;
   
    
    //敵人
    public List<GameObject> _enemyTypeList;
    //權重
    //public List<float> _enemyTypeWeight;
    //生成位置
    public List<GameObject> _createEnemyPlaceList;
    //權重
    //public List<float> _createEnemyPlaceWeight;

    //生成方向，如果沒有就是隨便了
    //這個是給生成障礙物或是直線前進的敵人使用
    public List<Vector3> _Listposition;
    //產生出來的敵人
    public List<GameObject> _createdEnemyList;

    //玩家
    public GameObject _player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void CallUpdateCreateEnemy()
    {
        //更新時間
        _nowTime = _nowTime + Time.deltaTime;

        Cal_IsInCreateTime();

        if (_isVaild)
        {
            Cal_IsCreateEnemy();
        }
    }

    //計算目前腳本有沒有效
    void Cal_IsInCreateTime()
    {
        //如果是在時間內
        if (_nowTime > _startTime && _nowTime < _stopTime)
        {
            _isVaild = true;
        }
        else
        {
            _isVaild = false;
        }
    }

    //計算目前是不是要產生敵人
    //_enemyParMinute 一分鐘會有幾隻敵人
    float _lastCreateEnemyTime;
    void Cal_IsCreateEnemy()
    {
        if (_nowTime - _lastCreateEnemyTime > (60 / _enemyParMinute))
        {
            _lastCreateEnemyTime = _nowTime;
            if (_createdEnemyList.Count < _maxEnemyNumber)
            {
                //產生敵人
                CreateEnemy();
            }
        }
    }

    //產生敵人
    void CreateEnemy()
    {
        try
        {
            int createEnemyIndex = 0;
            if (_enemyTypeList.Count > 1)
            {
                createEnemyIndex = (int)Random.Range(0, _enemyTypeList.Count);
            }

            //產生敵人
            GameObject enemy = Instantiate(_enemyTypeList[createEnemyIndex]);
            //幫敵人設定難度
            enemy.GetComponent<Enemy>().SetDifficulty(_difficulity);
            enemy.GetComponent<Enemy>().SetTarget(_player);
            //然後設定報打敗的監聽是件
            enemy.GetComponent<Enemy>()._enemyDefeated += new Enemy.EnemyDefeated(EnemyCreatorEnemyDefeated);

            /* 把一個位置生成怪 改成 多個位置生成
            int createEnemyPlaceIndex = 0;
            if (_createEnemyPlaceList.Count > 0)
            {
                createEnemyPlaceIndex = (int)Random.Range(0, _createEnemyPlaceList.Count);   
                
            }
            //決定物件
            GameObject place = _createEnemyPlaceList[createEnemyPlaceIndex];*/
            int createEnemyPlaceIndex = 0;
            GameObject place;
            for (int i = 0; i < _createEnemyPlaceList.Count; i++)
            {
                createEnemyPlaceIndex = i;
                place = _createEnemyPlaceList[createEnemyPlaceIndex];

                //懶一點決定一個 place 裡面
                //避免Stage回收時敵人無法回收的問題
                enemy.transform.parent = place.transform;
                enemy.transform.localPosition = new Vector3(0, 0, 0);

                _createdEnemyList.Add(enemy);
            }
            //如果有指定角度
            if (_Listposition.Count > 0)
            {
                int rotationIndex = 0;
                if (_Listposition.Count > 1)
                {
                    rotationIndex = (int)Random.Range(0, _Listposition.Count);
                }
                //指定面相角度
                enemy.transform.localRotation = Quaternion.Euler(_Listposition[rotationIndex].x, _Listposition[rotationIndex].y, _Listposition[rotationIndex].z);
            }
            //增加敵人
            EnemyStaticPlaceList._listEnemy.Add(enemy);
        }
        catch
        {

        }
    }

    //如果敵人被打敗
    //可以取得一些參數
    void EnemyCreatorEnemyDefeated(SingleWeakPointParameter difficulty)
    {
        //通知整理陣列
        ResreshEnemyList();
        //目前敵人打敗數量+1;
        _defeatedEnemyNumber ++;
        //然後通知打敗敵人
        _enemyDefeated(difficulty);
    }

    void ResreshEnemyList()
    {
        //Debug.Log("REGRESH!");
        if(_createdEnemyList.Count>0)
        {
            for (int i = 0; i < _createdEnemyList.Count; i++)
            {
                if (_createdEnemyList[i] == null)
                {
                    _createdEnemyList.RemoveAt(i);
                }
            }
        }
    }

    //===============================public========================
    //事件，通知打到敵人死翹翹惹
    public delegate void EnemyDefeated(SingleWeakPointParameter difficulty);
    public event EnemyDefeated _enemyDefeated;

    //通知，如果敵人被攻擊了 : )
    public delegate void EnemyHitterd(SingleWeakPointParameter difficulty);
    public event EnemyHitterd _enemyHitted;

    //初始化
    //當遊戲重新開始時會執行這邊
    public void Initial()
    {
        _nowTime = 0;
        _isVaild = false;
    }

    //設定難度
    //目前只要設定敵人生產數量
    public void SetDifficulty(StageController.Difficulty difficulity)
    {
        //也會對應敵人的難度
        _difficulity = difficulity;
        //如果是簡單
        if (_difficulity == StageController.Difficulty.easy)
        {
            _enemyParMinute = _easyModeEnemyParMinut;
        }
        else if (_difficulity == StageController.Difficulty.normal)
        {
            _enemyParMinute = _normalModeEnemyParMinut;
        }
        else if (_difficulity == StageController.Difficulty.hard)
        {
            _enemyParMinute = _hardModeEnemyParMinut;
        }
        else if (_difficulity == StageController.Difficulty.insame)
        {
            _enemyParMinute = _insameModeEnemyParMinut;
        }
    }

    //設定玩家
    //設定Character上去
    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
}
