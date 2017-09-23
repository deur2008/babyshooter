using UnityEngine;
using System.Collections;

public class CharacterController_Enum : MonoBehaviour {
    //設定雙點的時間
    //目前設定為0.5秒
    public float _doubleClickTime = 0.2f;
    //距離上一個按鈕按下去的時間
    private float _lastClick = 0;

    //指定要控制的腳色，ID跟list位置有關
    //目前設定第0隻
    public int _controlCharacterID=0;

    //確定要不要執行，如果物件有一個是null就不要執行
    private bool _execute;

    //設定目前要控制的腳色(GameObject)
    public GameObject _targetCharacter;
    //目前會控制的腳本

    //確認初始化
    private bool CheckInitialize()
    {
       
        if (CharacterGroup.Character.Count < _controlCharacterID)
        {
            DebugLog.Print(this, "(_group.Character.Count < _controlCharacterID)");
            return false;
        }
        return true;
    }

    //初始化
    void Start()
    {
        _execute = CheckInitialize();
        if (_execute)
        {
            //_targetCharacter = CharacterGroup.Character[_controlCharacterID];
        }
    }

    KeyCode key = KeyCode.S;
    // Update is called once per frame
    void Update () {
        //取得目前鍵盤 WSAD 的 key ，來有雙典籍
        //GetUpDownLeftRightKeyDown();

        TestVer01();
    }

    //只是用來做基本測試
    void TestVer01()
    {
        if (Input.anyKey)
        {
            TestRun();
            TestSlide();
        }
    }

    void TestRun()
    {
        
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            int press_X = 0;
            int press_y = 0;
            //表示單押的 上
            if (Input.GetKey("up"))
            {
                press_y++;
            }
            if (Input.GetKey("down"))
            {
                press_y--;
            }
            if (Input.GetKey("left"))
            {
                press_X--;
            }
            if (Input.GetKey("right"))
            {
                press_X++;
            }
            Vector2 ecteor = new Vector2(press_X, press_y);
            //_targetCharacter.GetComponent<Character>().Run(ecteor);
            //if (_runSreaight)
            //{
                
            //}
            //else
            //{
            //    _targetCharacter.GetComponent<Character>().RunStraight(press_X, press_y);
            //}
            
        }
    }

    bool _runSreaight = false;
    void RunStraight()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (_runSreaight)
            {
                _runSreaight = false;
            }
            else
            {
                _runSreaight = true;
            }
        }
    }

    void TestSlide()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            int press_X = 0;
            int press_y = 0;
            //表示單押的 上
            if (Input.GetKey(KeyCode.W))
            {
                press_y++;
            }
            if (Input.GetKey(KeyCode.S))
            {
                press_y--;
            }
            if (Input.GetKey(KeyCode.A))
            {
                press_X--;
            }
            if (Input.GetKey(KeyCode.D))
            {
                press_X++;
            }
            Vector2 vector = new Vector2(press_X, press_y);
           // _targetCharacter.GetComponent<Character>().FastRun(vector);
        }
    }

    //還沒寫完
    void GetUpDownLeftRightKeyDown()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                //表示按到上一個鍵
                if (Input.GetKey(key))
                {

                    if (_lastClick < _doubleClickTime)
                    {
                        DebugLog.Print(this, "PressUp_doubleClick  " + _lastClick);
                    }
                }
                else
                {
                    key = KeyCode.W;
                    DebugLog.Print(this, "PressUp");

                }

            }

            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                //表示按到上一個鍵
                if (Input.GetKey(key))
                {
                    if (_lastClick < _doubleClickTime)
                    {
                        DebugLog.Print(this, "PressDown_doubleClick");
                    }
                }
                else
                {
                    key = KeyCode.S;
                    DebugLog.Print(this, "PressDonw");

                }
            }

            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                //表示按到上一個鍵
                if (Input.GetKey(key))
                {
                    if (_lastClick < _doubleClickTime)
                    {
                        DebugLog.Print(this, "PressLeft_doubleClick");
                    }
                }
                else
                {
                    key = KeyCode.A;
                    DebugLog.Print(this, "PressLeft");

                }
            }

            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                //表示按到上一個鍵
                if (Input.GetKey(key))
                {
                    if (_lastClick < _doubleClickTime)
                    {
                        DebugLog.Print(this, "PressRight_doubleClick");
                    }
                }
                else
                {
                    key = KeyCode.D;
                    DebugLog.Print(this, "PressRight");

                }
            }

            _lastClick = 0;
        }

        _lastClick = _lastClick + Time.deltaTime;

        //目前有任何案件按下去
        if (Input.anyKey)
        {
            //if()


        }
    }

}
