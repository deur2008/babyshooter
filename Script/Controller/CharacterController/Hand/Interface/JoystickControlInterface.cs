using UnityEngine;
using System.Collections;

//所有物件如果想要被控制都要繼承這個物件
//如果是需要雙手控制的就兩隻手都附著就OK了
public class JoystickControlInterface : MonoBehaviour {

    //物件的教學
    public JoystickHint _hint;

    //如果手把被按到，剛好這個選項排序在最前面，就會被呼叫到
    //ApplicationMenu
    public virtual void OnApplicationMenuPressDown()
    {

    }

    public virtual void OnApplicationMenuPress()
    {

    }

    public virtual void OnApplicationMenuPressUp()
    {

    }

    //Grip
    public virtual void OnGripPressDown()
    {

    }

    public virtual void OnGripPress()
    {

    }

    public virtual void OnGripPressUp()
    {

    }

    //Touchpad
    public virtual void OnTouchpadPressDown()
    {

    }

    public virtual void OnTouchpadPress()
    {

    }

    public virtual void OnTouchpadPressUp()
    {

    }

    //Trigger
    public virtual void OnTriggerPressDown()
    {

    }

    public virtual void OnTriggerPress()
    {

    }

    public virtual void OnTriggerPressUp()
    {

    }

    //觸控板按下去，按下的位置是落在第幾個區塊，可以用來做武器選單和
    public virtual void OnTouchpadPressDown(int part)
    {

    }

    public virtual void OnTouchpadPress(int part)
    {

    }

    public virtual void OnTouchpadPressUp(int part)
    {

    }

    //觸控板按下去，按下的位置是落在第幾個區塊，可以用來做武器選單和
    public virtual void OnTouchpadPressDown(Vector2 position)
    {

    }

    public virtual void OnTouchpadPress(Vector2 position)
    {

    }

    public virtual void OnTouchpadPressUp(Vector2 position)
    {

    }

    //觸控板按下去，按下的位置是落在第幾個區塊，可以用來做武器選單和
    public virtual void OnTouchpadTouchDown(int part)
    {

    }

    public virtual void OnTouchpadTouch(int part)
    {

    }

    public virtual void OnTouchpadTouchUp(int part)
    {

    }

    //觸控板按下去，按下的位置是落在第幾個區塊，可以用來做武器選單和
    public virtual void OnTouchpadTouchDown(Vector2 position)
    {

    }

    public virtual void OnTouchpadTouch(Vector2 position)
    {

    }

    public virtual void OnTouchpadTouchUp(Vector2 position)
    {

    }
}
