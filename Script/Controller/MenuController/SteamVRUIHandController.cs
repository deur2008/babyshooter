using UnityEngine;
using System.Collections;
using VRTK;

//控制UI的
//綁在Controller(left Right) 底下
//然後可以從這裡取得按下按鈕狀態
public class SteamVRUIHandController : MonoBehaviour {

    
    //VRTK_ControllerTooltips 用來顯示 各個按鈕的功能

    //RadialMenu 用來顯示 圓盤，有幾個圓盤
    public RadialMenu _radialMenu;

    //丟進提示，會把提示顯示在UI上面
    public void SetToolTip(JoystickHint hint)
    {
        try
        {
           
            //更新是不是總是顯示
            AlwaysShowHint(hint._alwaysShow);
            //更新上面的文字
            _tooltips.SetTriggerText(hint.Trigger);
            _tooltips.SetGripText(hint.Grip);
            _tooltips.SetTouchpadText(hint.Touchpad);
            _tooltips.SetAppMenuText(hint.ApplicationMenu);
            //更新選單的分裂數目
            _radialMenu.SetButtonNumber(hint.TouchPadDivision);
        }
        catch
        {

        }
    }


    //總是顯示提示
    public bool _alwaysShow = true;
    public VRTK_ControllerTooltips _tooltips;
    private VRTK_ControllerActions actions;
    private VRTK_ControllerEvents events;

    //開始
    private void Start()
    {
        if (GetComponentInParent<VRTK_ControllerEvents>() == null)
        {
            Debug.LogError("VRTK_ControllerEvents_ListenerExample is required to be attached to a SteamVR Controller that has the VRTK_ControllerEvents script attached to it");
            return;
        }

        //取得是件
        events = GetComponentInParent<VRTK_ControllerEvents>();
        actions = GetComponentInParent<VRTK_ControllerActions>();
        _tooltips = GetComponent<VRTK_ControllerTooltips>();//取得

        //Setup controller event listeners
        events.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
        events.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

        events.ApplicationMenuPressed += new ControllerInteractionEventHandler(DoApplicationMenuPressed);
        events.ApplicationMenuReleased += new ControllerInteractionEventHandler(DoApplicationMenuReleased);

        events.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
        events.GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

        events.TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);
        events.TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);

        //是不是總是顯示提示
        AlwaysShowHint(_alwaysShow);
    }

    //總是顯示
    public void AlwaysShowHint(bool always)
    {
        _alwaysShow = always;
        try
        {
            //有時候會因為時間順序不同無法取得腳本
            _tooltips = GetComponentInChildren<VRTK_ControllerTooltips>();//取得
            _tooltips.ShowTips(_alwaysShow);
        }
        catch
        {

        }

    }

    //如果板機壓下去
    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        _tooltips.ShowTips(true, VRTK_ControllerTooltips.TooltipButtons.TriggerTooltip);
        actions.ToggleHighlightTrigger(true, Color.yellow, 0.5f);
        actions.SetControllerOpacity(0.8f);
    }


    //放開
    private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        if (!_alwaysShow)
        {
            _tooltips.ShowTips(false, VRTK_ControllerTooltips.TooltipButtons.TriggerTooltip);
            actions.ToggleHighlightTrigger(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }
    }

    private void DoApplicationMenuPressed(object sender, ControllerInteractionEventArgs e)
    {
        _tooltips.ShowTips(true, VRTK_ControllerTooltips.TooltipButtons.AppMenuTooltip);
        actions.ToggleHighlightApplicationMenu(true, Color.yellow, 0.5f);
        actions.SetControllerOpacity(0.8f);
    }

    private void DoApplicationMenuReleased(object sender, ControllerInteractionEventArgs e)
    {
        if (!_alwaysShow)
        {
            _tooltips.ShowTips(false, VRTK_ControllerTooltips.TooltipButtons.AppMenuTooltip);
            actions.ToggleHighlightApplicationMenu(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }
    }

    private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        _tooltips.ShowTips(true, VRTK_ControllerTooltips.TooltipButtons.GripTooltip);
        actions.ToggleHighlightGrip(true, Color.yellow, 0.5f);
        actions.SetControllerOpacity(0.8f);
    }

    private void DoGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        if (!_alwaysShow)
        {
            _tooltips.ShowTips(false, VRTK_ControllerTooltips.TooltipButtons.GripTooltip);
            actions.ToggleHighlightGrip(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }
    }

    private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        _tooltips.ShowTips(true, VRTK_ControllerTooltips.TooltipButtons.TouchpadTooltip);
        actions.ToggleHighlightTouchpad(true, Color.yellow, 0.5f);
        actions.SetControllerOpacity(0.8f);
    }

    private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
    {
        if (!_alwaysShow)
        {
            _tooltips.ShowTips(false, VRTK_ControllerTooltips.TooltipButtons.TouchpadTooltip);
            actions.ToggleHighlightTouchpad(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        actions.ToggleHighlightController(true, Color.yellow, 0.4f);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!_alwaysShow)
        {
            actions.ToggleHighlightController(false);
        }
    }
}
