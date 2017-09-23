using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//對話框
//有外部框框(panel)，裡面有標題跟內容(可以滑動的框框跟文字)
//可以設定直接滑到最下面
//設定文字顯示完了
//設定文字顯示速度
//設定內文，標題大小
public class DialogUI : PanelUI
{
    //目前位置
    public int _index = 0;
    public List<string> _dialogString;
    public Text _showText;
    //初始化
    //從這邊去註冊事件，可以監聽
    public override void Initialize()
    {
        //設定顯示 0
        if (_dialogString.Count > 0)
        {
            _index = 0;
            UpdateText(_dialogString[_index]);
        }
    }

    //顯示
    public void UpdateText(string Text)
    {
        _showText.text = Text;
    }

    public override void PressTrigger()
    {
        _index++;
        //如果超出顯示，表示已經完成所有對話框顯示
        if (_index >= _dialogString.Count)
        {
            base.PressTrigger();
        }
        else
        {
            //顯示下一則
            UpdateText(_dialogString[_index]);
        }
        
    }

    //要把所有都點完才算真正完成任務
}


