using UnityEngine;
using System.Collections;

//顯示 "是" 或是 "不是" 的Dialog

public class YesNoDialog : PanelUI {



    //如果顯示"對"
    //就相當於select
    public virtual void SelectYes()
    {
        
    }

    //如果顯示"不對"
    //就相當於cancel
    public virtual void SelectNo()
    {

    }
}
