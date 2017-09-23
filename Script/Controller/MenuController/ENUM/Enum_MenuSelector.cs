using UnityEngine;
using System.Collections;

//用鍵盤模擬選單
public class Enum_MenuSelector : MonoBehaviour {

    //模擬Panel被選擇
    public PanelUI _panelUI;

    //是否要控制 PanelControllerStaticAdapter
    public bool _controlPanelControllerStaticAdapter = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //表示單押的 上
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Input.GetKeyDown(up)");
            if (_controlPanelControllerStaticAdapter)
            {
                PanelControllerStaticAdapter.PressUp();
            }
            else
            {
                _panelUI.PressUp();
            }

        }
        if (Input.GetKeyDown("down"))
        {
            Debug.Log("Input.GetKeyDown(donw)");
            if (_controlPanelControllerStaticAdapter)
            {
                PanelControllerStaticAdapter.PressDown();
            }
            else
            {
                _panelUI.PressDown();
            }
        }
        if (Input.GetKeyDown("left"))
        {
            Debug.Log("Input.GetKeyDown(left)");
            if (_controlPanelControllerStaticAdapter)
            {
                PanelControllerStaticAdapter.PressLeft();
            }
            else
            {
                _panelUI.PressLeft();
            }
        }
        if (Input.GetKeyDown("right"))
        {
            Debug.Log("Input.GetKeyDown(right)");
            if (_controlPanelControllerStaticAdapter)
            {
                PanelControllerStaticAdapter.PressRight();
            }
            else
            {
                _panelUI.PressRight();
            }
        }
        //select
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Input.GetKeyDown(PressSelect)");
            if (_controlPanelControllerStaticAdapter)
            {
                PanelControllerStaticAdapter.PressSelect();
            }
            else
            {
                _panelUI.PressTrigger();
            }
        }
        //cancel
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Input.GetKeyDown(Escape)");
            if (_controlPanelControllerStaticAdapter)
            {
                PanelControllerStaticAdapter.PressCancel();
            }
            else
            {
                _panelUI.PressApplicationMenu();
            }
        }
    }
}
