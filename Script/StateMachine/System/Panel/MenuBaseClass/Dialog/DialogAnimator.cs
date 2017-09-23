using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//顯示對話框
public class DialogAnimator : BaseMenuStateMachineBehaviour
{
    //逐一顯示要對話的框框
    public List<string> _dialogContext;
    //一直按下OK後最後會觸發到 trigger，例如isOK之類的，就會跳到下一個狀態機
    public string _triggerName;

    //按下OK會切換到顯示下一句

    //直到最後沒有東西時，按下OK，就會切到下一個場景
	
}
